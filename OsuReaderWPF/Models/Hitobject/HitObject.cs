using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsuReaderWPF.Helpers;
namespace OsuReaderWPF.Models
{
    public class HitObject:IComparable<HitObject>
    {
        public HitObject(Timing time, int x, int y,bool isNewcombo = false,HOTypes type = HOTypes.None,HitsoundTypes hitsound = HitsoundTypes.Normal)
        {
            Time = time;
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
            Time = hObject.Time;
            Additions = hObject.Additions;
            IsNewCombo = hObject.IsNewCombo;
            StartPosition = hObject.StartPosition;
            Type = hObject.Type;
            Hitsound = hObject.Hitsound;

        }

        public int[] Additions { get; set; }
        public SampleSets SampleSet { get { return (SampleSets)Additions[0]; } set { Additions[0] = (int)value; } }
        public SampleSets AdditionSet { get { return (SampleSets)Additions[1]; } set { Additions[1] = (int)value; } }
        public Custom IsCustom { get { return (Custom)Additions[2]; } set { Additions[2] = (int)value; } }
        public int CustomSet { get { return Additions[3]; } set { Additions[3] = (int)value; } }
        public Position StartPosition { get; set; }
        public bool IsNewCombo { get; set; }
        public Timing Time { get; set; }
        public HOTypes Type { get; set; }
        public HitsoundTypes Hitsound { get; set; }
        public int CompareTo(HitObject other)
        {
            return this.Time.CompareTo(other.Time);
        }
        public override string ToString()
        {
            return StartPosition.GetX() + "," + StartPosition.GetY() + "," + Time.TimeMS + "," + (int)Type + "," + (int)Hitsound;
        }
    }
}
