using System;
using System.Collections.Generic;
using System.Text;
using osuElements.Helpers;
using osuElements.Storyboards.Triggers;

namespace osuElements.Storyboards
{
    public class TriggerEvent : LoopEvent
    {
        public TriggerTypes TriggerType => Trigger.TriggerType;
        public TriggerBase Trigger;
        public override TransformTypes TransformType { get; } = TransformTypes.T;
        public int Group { get; set; } = 0;
        public override int EndTime { get; set; }

        public TriggerEvent(TriggerBase trigger, int starttime, int endtime) : base(starttime) {
            Trigger = trigger;
            StartTime = starttime;
            EndTime = endtime;
        }

        public override string ToString() {
            return $"{TransformType},{Trigger},{StartTime},{EndTime}" + (Group == 0 ? "" : "," + Group);
        }
        public static bool TryParse(string line, out TriggerEvent triggerEvent) {
            var parts = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            triggerEvent = null;

            if (parts.Length < 4 || parts[0].Trim() != "T") return false;
            TriggerBase trigger;
            if (!TriggerBase.TryParse(parts[1].TrimStart(), out trigger)) return false;
            int starttime, endtime;
            if (!int.TryParse(parts[2], out starttime)) return false;
            if (!int.TryParse(parts[3], out endtime)) return false;

            triggerEvent = new TriggerEvent(trigger, starttime, endtime);

            if (parts.Length <= 4) return true;
            int group;
            if (!int.TryParse(parts[4], out group)) return false;
            triggerEvent.Group = group;
            return true;
        }
        public new static TriggerEvent Parse(string line) {
            var parts = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            TriggerBase trigger;
            TriggerBase.TryParse(line, out trigger);
            var result = new TriggerEvent(trigger, int.Parse(parts[1]), int.Parse(parts[2]));
            if (parts.Length > 3) result.Group = int.Parse(parts[3]);
            return result;
        }
    }
}
