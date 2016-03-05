using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using osuElements.Helpers;

namespace osuElements.Repositories.File
{
    public class FileSection<T> : IFileSection<T>
    {
        public string Section { get; set; }
        public virtual bool ReadLine(string line) {
            //var parts = line.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            //if (parts.Length < 2) return;
            return _fileLines.Any(f => f.Match(_model, line));
        }

        protected T _model;

        public virtual void SetModel(T model) {
            _model = model;
        }

        public virtual List<string> AllLines() {
            var result = new List<string>();
            if (!string.IsNullOrEmpty(Section)) result.Add($"[{Section}]");
            var lines = _fileLines.Where(property => property.WriteIfDefault || !property.IsDefault(_model));
            foreach (var fileLine in lines) {
                fileLine.GetLine(_model, result);
            }
            if (result.Count == 0) return new List<string>();
            result.Add("");
            return result;
        }

        public IFileSection<T> GetCopy() {
            return (IFileSection<T>)MemberwiseClone();
        }

        private readonly List<IFileLine<T>> _fileLines = new List<IFileLine<T>>();


        public FileSection(string section, params IFileLine<T>[] fileLines) {
            Section = section;
            foreach (var fileLine in fileLines) {
                _fileLines.Add(fileLine);
            }
        }

    }
}