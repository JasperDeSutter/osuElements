using System;
using System.Collections.Generic;

namespace osuElements.IO.File
{
    public enum LogSeverity
    {
        Warning,
        Error,
        Message
    }
    public class LogMessage
    {
        public LogMessage(LogSeverity severity, string message) {
            Time = DateTime.Now;
            Severity = severity;
            Message = message;
        }

        public LogSeverity Severity { get; }
        public DateTime Time { get; }
        public string Message { get; }
        public override string ToString() {
            return $"{Time}: {Severity} - {Message}";
        }
    }

    public interface ILogger
    {
        void AddLog(LogMessage log);
       List<LogMessage> Errors { get; }
       List<LogMessage> Warnings { get; }
       List<LogMessage> Messages { get; }
    }
    public class BasicLogger : ILogger
    {
        public BasicLogger() {
            Errors = new List<LogMessage>();
            Warnings = new List<LogMessage>();
            Messages = new List<LogMessage>();
        }

        public void AddLog(LogMessage log) {
            switch (log.Severity) {
                case LogSeverity.Error:
                    Errors.Add(log);
                    break;
                case LogSeverity.Warning:
                    Warnings.Add(log);
                    break;
                case LogSeverity.Message:
                    Messages.Add(log);
                    break;
            }
        }

        public List<LogMessage> Errors { get; }
        public List<LogMessage> Warnings { get; }
        public List<LogMessage> Messages { get; }
    }
}