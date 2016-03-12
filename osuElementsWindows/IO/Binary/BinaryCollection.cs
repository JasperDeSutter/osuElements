using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace osuElements.IO.Binary
{
    public class BinaryCollection<TClass, TMember> : IBinaryFileLine<TClass> where TMember : new()
    {
        private readonly List<IBinaryFileLine<TMember>> _fileLines;
        private readonly PropertyInfo _property;

        public BinaryCollection(Expression<Func<TClass, ICollection<TMember>>> propertySelector,
            params IBinaryFileLine<TMember>[] fileLines) {
            _fileLines = fileLines.ToList();
            _property = (propertySelector.Body as MemberExpression).Member as PropertyInfo;
        }

        public void AddFileLine(IBinaryFileLine<TMember> fileLine) {
            _fileLines.Add(fileLine);
        }

        public void ReadValue(BinaryReader binaryReader, ref TClass instance) {
            var count = binaryReader.ReadInt32();
            var collection = (ICollection<TMember>)_property.GetValue(instance);
            for (var i = 0; i < count; i++) {
                var member = new TMember();
                foreach (var binaryFileLine in _fileLines) {
                    try {
                        binaryFileLine.ReadValue(binaryReader, ref member);
                    }
                    catch (Exception ex) {
                        if (ex is EndOfStreamException) throw ex;
                        binaryFileLine.SetDefaultValue(member);
                    }
                }
                collection.Add(member);
            }
        }

        public void SetDefaultValue(TClass instance) { }

        public void WriteValue(BinaryWriter writer, TClass instance) {
            var collection = (ICollection<TMember>)_property.GetValue(instance);
            writer.Write(collection.Count);
            foreach (var member in collection) {
                foreach (var binaryFileLine in _fileLines) {
                    binaryFileLine.WriteValue(writer, member);
                }
            }
        }
    }
}