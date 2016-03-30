using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace osuElements.IO.File
{
    public class FileReader<T> : IFileRepository<T> where T : class
    {
        private readonly IFileSection<T>[] _sections;
        public FileReader(params IFileSection<T>[] sections) {
            _sections = sections;
        }

        //Dont't use, very slow
        public async Task WriteFileAsync(Stream outStream, T instance) {
            var tasks = GetInstances(instance).Select(fileSection => Task.Factory.StartNew(fileSection.AllLines)).ToList();
            using (var sw = new StreamWriter(outStream)) {
                for (var i = 0; i < tasks.Count; i++) {
                    var task = tasks[i];
                    var lines = await task;
                    for (var j = 0; j < lines.Count; j++) {
                        if (i != tasks.Count - 1 || j != lines.Count - 1)
                            await sw.WriteLineAsync(lines[j]);
                    }
                }
            }
        }

        private IEnumerable<IFileSection<T>> GetInstances(T model) {
            return _sections.Select(s => {
                var r = s.GetCopy();
                r.SetModel(model);
                return r;
            });
        }


        public void WriteFile(Stream outStream, T instance) {
            using (var sw = new StreamWriter(outStream)) {
                var lines = GetInstances(instance).SelectMany(fileSection => fileSection.AllLines()).ToList();
                for (var i = 0; i < lines.Count - 1; i++) {
                    var line = lines[i];
                    sw.WriteLine(line);
                }
            }
        }

        //Dont't use, very slow
        public async Task ReadFileAsync(Stream inStream, T instance, ILogger logger = null) {
            var tasklist = new List<Task>();
            using (var streamReader = new StreamReader(inStream)) {
                var lineTask = Task.Factory.StartNew(streamReader.ReadLineAsync);
                var lineNr = 1;
                string line;
                var section = "";
                var filesection = _sections.FirstOrDefault(s => string.IsNullOrEmpty(s.Section))?.GetCopy();
                filesection?.SetModel(instance);
                while ((line = await lineTask.Result) != null) {
                    lineTask = Task.Factory.StartNew(streamReader.ReadLineAsync);
                    if (string.Empty != line && !line.StartsWith("//")) {
                        if (line.StartsWith("[")) {
                            section = line.Trim('[', ' ', ']');
                            filesection = _sections.FirstOrDefault(s => string.Equals(s.Section, section, StringComparison.CurrentCultureIgnoreCase))?.GetCopy();
                            filesection?.SetModel(instance);
                        }
                        else if (filesection != null) {
                            var l = line;
                            var ln = lineNr;
                            var fs = filesection;

                            tasklist.Add(Task.Run(() => {
                                try { fs.ReadLine(l); }
                                catch (Exception ex) {
                                    logger?.AddLog(new LogMessage(LogSeverity.Error, $"line {ln} ({l}): {ex.Message}"));
                                }
                            }));
                        }
                        else logger?.AddLog(new LogMessage(LogSeverity.Warning, $"Line {lineNr} ({line}) was read in undefined section {section}"));
                    }
                    lineNr++;
                }
                await Task.WhenAll(tasklist);
            }
            //await WhenAll(tasklist);
        }

        public void ReadFile(Stream inStream, T instance, ILogger logger = null) {
            using (var streamReader = new StreamReader(inStream)) {
                var line = streamReader.ReadLine();
                var lineNr = 1;
                var section = "";
                var filesection = _sections.FirstOrDefault(s => string.IsNullOrEmpty(s.Section))?.GetCopy();
                filesection?.SetModel(instance);
                while (line != null) {
                    if (string.Empty != line && !line.StartsWith("//")) {
                        if (line.StartsWith("[")) {
                            section = line.Trim('[', ' ', ']');
                            filesection = _sections.FirstOrDefault(s => string.Equals(s.Section, section, StringComparison.CurrentCultureIgnoreCase))?.GetCopy();
                            filesection?.SetModel(instance);
                        }
                        else {
                            try {
                                if (filesection == null) logger?.AddLog(new LogMessage(LogSeverity.Warning, $"Line {lineNr} ({line}) was read in undefined section {section}"));
                                else filesection.ReadLine(line);
                            }
                            catch (Exception ex) {
                                logger?.AddLog(new LogMessage(LogSeverity.Error, $"line {lineNr} ({line}): {ex.Message}"));
                            }
                        }
                    }
                    lineNr++;
                    line = streamReader.ReadLine();
                }
            }
        }
    }
}


