using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osuElements;
namespace osuElements
{
    public class HitObject:IComparable<HitObject>,IEquatable<HitObject>
    {
        public HitObject(Timing time, int x, int y,bool isNewcombo = false,HOTypes type = HOTypes.None,HitsoundTypes hitsound = HitsoundTypes.Normal)
        {
            StartTime = time;
            StartPosition = new Position(x, y);
            Additions = new int[4];
            SampleSet = SampleSets.None;
            AdditionSet = SampleSets.None;
            IsCustom = Custom.Default;
            CustomSet = 0;

            IsNewCombo = isNewcombo;
            Type = type;
            Hitsound = hitsound;
        }
        public HitObject(HitObject hObject)
        {
            StartTime = hObject.StartTime;
            Additions = hObject.Additions;
            IsNewCombo = hObject.IsNewCombo;
            StartPosition = hObject.StartPosition;
            Type = hObject.Type;
            Hitsound = hObject.Hitsound;

        }
        public float Duration =0;
        public int[] Additions { get; set; }
        public SampleSets SampleSet { get { return (SampleSets)Additions[0]; } set { Additions[0] = (int)value; } }
        public SampleSets AdditionSet { get { return (SampleSets)Additions[1]; } set { Additions[1] = (int)value; } }
        public Custom IsCustom { get { return (Custom)Additions[2]; } set { Additions[2] = (int)value; } }
        public int CustomSet { get { return Additions[3]; } set { Additions[3] = (int)value; } }
        public Position StartPosition { get; set; }
        protected bool IsNewCombo;
        public virtual int NewCombo
        {
            get
            {
                return  IsNewCombo ? 1 : 0; 
            } 
        }
        public Timing StartTime { get; set; }
        public float EndTime { get { return StartTime + Duration; } set { Duration = value - StartTime; } }
        public HOTypes Type { get; set; }
        public HitsoundTypes Hitsound { get; set; }
        public int CompareTo(HitObject other)
        {
            return this.StartTime.CompareTo(other.StartTime);
        }
        public override string ToString()
        {
            return StartPosition.GetX() + "," + StartPosition.GetY() + "," + StartTime.TimeMS + "," + (int)Type + "," + (int)Hitsound;
        }

        public bool Equals(HitObject other)
        {
            return (CompareTo(other) == 0);
        }
    }
}
