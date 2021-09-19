using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using osuElements.Helpers;

namespace osuElements.IO.Binary
{
    public class BinaryFileLine<TClass, TValue> : IBinaryFileLine<TClass>
    {
        public TValue DefaultValue { get; set; }
        protected readonly PropertyInfo _property;

        public BinaryFileLine(Expression<Func<TClass, TValue>> propertySelector, TValue defaultValue = default(TValue)) {
            DefaultValue = defaultValue;
            _property = (propertySelector?.Body as MemberExpression)?.Member as PropertyInfo;
            Type = typeof(TValue);
        }

        public Func<BinaryReader, TClass, object> ReaderFunc { get; set; }
        public Action<BinaryWriter, TClass> WriterAction { get; set; }

        public Type Type { get; set; }
        public bool OsuFormat { get; set; }

        public void SetDefaultValue(TClass instance) {
            _property.SetValue(instance, DefaultValue);
        }
        private readonly Type _writer = typeof(BinaryWriter);

        public virtual void WriteValue(BinaryWriter writer, TClass instance) {
            if (OsuFormat) writer.Write((byte)0);
            if (WriterAction != null) {
                WriterAction.Invoke(writer, instance);
                return;
            }
            var value = _property.GetValue(instance);
            WriteObject(writer, value);
        }

        protected void WriteObject(BinaryWriter writer, object obj) {
            object t = obj;

            if (obj is Enum && Enum.GetUnderlyingType(obj.GetType()) != Type) {
                t = Convert.ChangeType(obj, Type);
            }

            if (Type == typeof(string)) {
                writer.WriteNullableString((string)t);
            }
            else if (Type == typeof(DateTime)) {
                writer.Write(((DateTime)t).Ticks);
            }
            else if (Type == typeof(byte[])) {
                writer.WriteByteArray((byte[])t);
            }
            else
                _writer.GetRuntimeMethod("Write", Type.AsArray())
                    ?.Invoke(writer, t.AsArray()); //reflection to use the correct write method for type
        }

        protected object ReadObject(BinaryReader reader) {
            if (OsuFormat) reader.ReadByte();
            if (Type == typeof(byte))
                return reader.ReadByte();
            if (Type == typeof(int)) return reader.ReadInt32();
            if (Type == typeof(uint)) return reader.ReadUInt32();
            if (Type == typeof(short)) return reader.ReadInt16();
            if (Type == typeof(ushort)) return reader.ReadUInt16();
            if (Type == typeof(long)) return reader.ReadInt64();
            if (Type == typeof(ulong)) return reader.ReadUInt64();
            if (Type == typeof(double)) return reader.ReadDouble();
            if (Type == typeof(float)) return reader.ReadSingle();
            if (Type == typeof(bool)) return reader.ReadBoolean();
            if (Type == typeof(DateTime)) {
                var ticks = reader.ReadInt64();
                return new DateTime(ticks, DateTimeKind.Utc);
            }
            if (Type == typeof(string)) return reader.ReadNullableString();
            if (Type == typeof(byte[])) return reader.ReadByteArray();
            return DefaultValue;
        }

        public virtual void ReadValue(BinaryReader binaryReader, ref TClass instance) {
            var value = ReaderFunc?.Invoke(binaryReader, instance) ?? ReadObject(binaryReader);
            if (DefaultValue is Enum)
                value = Enum.Parse(typeof(TValue), value.ToString()); //this way enum can be read as byte, short, int, long, and string
            _property.SetValue(instance, value);
        }
    }
}