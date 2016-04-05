using System;
using osuElements.Storyboards.Triggers;

namespace osuElements.Storyboards
{
    public class TriggerEvent : LoopEvent
    {
        public TriggerEvent(TriggerBase trigger, int starttime, int endtime, int group = 0) : base(starttime) {
            Trigger = trigger;
            StartTime = starttime;
            EndTime = endtime;
            Group = group;
        }
        public TriggerEvent(TriggerTypes trigger, int starttime, int endtime, int group = 0)
            : this(TriggerBase.FromType(trigger), starttime, endtime, group) { }

        public TriggerTypes TriggerType => Trigger.TriggerType;
        public TriggerBase Trigger { get; set; }
        public override TransformTypes TransformType { get; } = TransformTypes.T;
        public int Group { get; set; }

        public override void OptimizeLoop() { }

        public override string ToString() {
            return $"{TransformType},{Trigger},{StartTime},{EndTime}" + (Group == 0 ? "" : "," + Group);
        }

        public static bool TryParse(string line, out TriggerEvent triggerEvent) {
            var parts = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            triggerEvent = null;

            if (parts.Length < 4 || parts[0].Trim() != TransformTypes.T.ToString()) return false;
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
            TriggerBase.TryParse(parts[1], out trigger);
            var result = new TriggerEvent(trigger, int.Parse(parts[2]), int.Parse(parts[3]));
            if (parts.Length > 4) result.Group = int.Parse(parts[4]);
            return result;
        }
    }
}