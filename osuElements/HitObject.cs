using System;
using osuElements.Helpers;
using osuElements.Other_Models;

namespace osuElements
{
    public class HitObject : IComparable<HitObject>, IEquatable<HitObject>
    {
        public HitObject(Timing time, float x, float y, bool isNewcombo = false, HitObjectType type = HitObjectType.None, HitsoundType hitsound = HitsoundType.Normal) {
            StartTime = time;
            StartPosition = Position.FromHitobject(x, y);
            Additions = new int[4];
            SampleSet = SampleSet.None;
            AdditionSet = SampleSet.None;
            IsCustom = Custom.Default;
            CustomSet = 0;
            IsNewCombo = isNewcombo;
            Type = type;
            Hitsound = hitsound;
        }
        public HitObject(HitObject hObject) {
            StartTime = hObject.StartTime;
            Additions = hObject.Additions;
            IsNewCombo = hObject.IsNewCombo;
            StartPosition = hObject.StartPosition;
            Type = hObject.Type;
            Hitsound = hObject.Hitsound;
        }
        public float Duration{get; set;}
        public int[] Additions { get; set; }
        public SampleSet SampleSet { get { return (SampleSet)Additions[0]; } set { Additions[0] = (int)value; } }
        public SampleSet AdditionSet { get { return (SampleSet)Additions[1]; } set { Additions[1] = (int)value; } }
        public Custom IsCustom { get { return (Custom)Additions[2]; } set { Additions[2] = (int)value; } }
        public int CustomSet { get { return Additions[3]; } set { Additions[3] = value; } }
        public Position StartPosition { get; set; }
        public bool IsNewCombo { get; set; }
        public virtual int NewCombo => IsNewCombo ? 1 : 0;
        public int ComboNumber { get; set; }
        public ComboColor ComboColor { get; set; }
        public virtual int Repeat { get; set; } = 1;
        public Timing StartTime { get; set; }
        public virtual float EndTime { get { return StartTime + Duration; } set { Duration = value - StartTime; } }
        public HitObjectType Type { get; protected set; }
        public HitsoundType Hitsound { get; set; }
        public int CompareTo(HitObject other) {
            if (other == this) return 0;
            return StartTime == other.StartTime ?
                Type.CompareTo(other.Type) : StartTime.CompareTo(other.StartTime);
        }
        public bool IsHitObjectType(HitObjectType type) {
            return Type.Compare(type);
        }
        public override string ToString() => $"{StartPosition.ToHitObjectString()},{StartTime.TimeMs},{(int)Type},{(int)Hitsound}";

        public bool Equals(HitObject other) => (CompareTo(other) == 0);
    }
}
