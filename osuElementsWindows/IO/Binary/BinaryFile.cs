using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using osuElements.IO.File;

namespace osuElements.IO.Binary
{
    public class BinaryFile<T> : IFileRepository<T> where T : class
    {
        private readonly List<IBinaryFileLine<T>> _fileLines;

        public BinaryFile(params IBinaryFileLine<T>[] fileLines) {
            _fileLines = fileLines.ToList();
        }

        public void AddFileLine(IBinaryFileLine<T> fileLine) {
            _fileLines.Add(fileLine);
        }

        public void ReadFile(Stream inStream, T instance, ILogger logger = null) {
            using (var binaryReader = new BinaryReader(inStream)) {
                for (int line = 0; line < _fileLines.Count; line++) {
                    var fileLine = _fileLines[line];
                    try {
                        fileLine.ReadValue(binaryReader, ref instance);
                    }
                    catch (Exception ex) {
                        if (ex is EndOfStreamException) throw ex;
                        logger?.AddLog(new LogMessage(LogSeverity.Error, $"{line + 1}: {ex}"));
                        fileLine.SetDefaultValue(instance);
                    }
                }
            }
        }

        public void WriteFile(Stream outStream, T instance) {
            using (var writer = new BinaryWriter(outStream)) {
                foreach (var fileLine in _fileLines) {
                    fileLine.WriteValue(writer, instance);
                }
            }
        }
    }
}