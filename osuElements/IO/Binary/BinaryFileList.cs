using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace osuElements.IO.Binary
{
    public class BinaryFileList<TClass, TValue> : BinaryFileLine<TClass, ICollection<TValue>>
    {
        public BinaryFileList(Expression<Func<TClass, ICollection<TValue>>> propertySelector) : base(propertySelector) {
            Type = typeof (TValue);
        }

        public override void WriteValue(BinaryWriter writer, TClass instance) {
            var collection = (ICollection<TValue>) _property.GetValue(instance);
            writer.Write(collection.Count);
            foreach (var value in collection) {
                WriteObject(writer, value);
            }
        }

        public override void ReadValue(BinaryReader binaryReader, ref TClass instance) {
            var count = binaryReader.ReadInt32();
            var collection = (ICollection<TValue>) _property.GetValue(instance);
            for (var i = 0; i < count; i++) {
                collection.Add((TValue) ReadObject(binaryReader));
            }
        }
    }

    public class BinaryFileDictionary<TClass, TKey, TValue> : BinaryFileList<TClass, KeyValuePair<TKey, TValue>>
    {
        public BinaryFileDictionary(Expression<Func<TClass, ICollection<KeyValuePair<TKey, TValue>>>> propertySelector)
            : base(propertySelector) {
            ValueType = typeof (TValue);
            KeyType = typeof (TKey);
        }

        public Type KeyType { get; set; }
        public Type ValueType { get; set; }

        public override void ReadValue(BinaryReader binaryReader, ref TClass instance) {
            var count = binaryReader.ReadInt32();
            var collection = (IDictionary<TKey, TValue>) _property.GetValue(instance);
            for (var i = 0; i < count; i++) {
                binaryReader.ReadByte();
                Type = KeyType;
                var key = (TKey) ReadObject(binaryReader);
                binaryReader.ReadByte();
                Type = ValueType;
                collection[key] = (TValue) ReadObject(binaryReader);
            }
        }

        public override void WriteValue(BinaryWriter writer, TClass instance) {
            //NYI
        }
    }
}