using System;
using System.Collections.Generic;
using System.Text;
using osuElements.Helpers;

namespace osuElements.Storyboards
{
    public class TransformationEvent : IComparable<TransformationEvent>
    {
        public virtual int EndTime { get; set; }
        public int Duration => EndTime - Starttime;

        public double[] StartValues { get; set; }
        public double[] EndValues { get; set; }
        public TransformTypes Transformtype { get; set; }
        public Easing Easing { get; set; }

        protected int Starttime;

        public virtual int StartTime
        {
            get { return Starttime; }
            set { Starttime = value; }
        }


        public TransformationEvent(TransformTypes type, Easing easing, int starttime, int endtime, double[] startvalues) : this(type, easing, starttime, endtime, startvalues, startvalues) { }

        public TransformationEvent(TransformTypes type, Easing easing, int starttime, int endtime, double[] startvalues, double[] endvalues) {
            Transformtype = type;
            Easing = easing;
            StartTime = starttime;
            EndTime = endtime;
            StartValues = startvalues;
            EndValues = endvalues;
        }

        public virtual bool IsActive(double time) {
            return (time >= StartTime && time <= EndTime);
        }
        
        public override string ToString() {
            var result = new StringBuilder();
            result.Append(Transformtype + ",");
            result.Append((int)Easing + ",");
            result.Append(StartTime + ",");
            if (Duration > 0)
                result.Append(EndTime);

            var issame = true;

            for (var i = 0; i < StartValues.Length; i++) {
                result.Append("," + StartValues[i].ToString(Constants.IO.CULTUREINFO));
                if (StartValues[i] != EndValues[i]) issame = false;
            }
            if (issame) return result.ToString();

            foreach (var b in EndValues) {
                result.Append("," + b.ToString(Constants.IO.CULTUREINFO));
            }
            return result.ToString();
        }

        public int CompareTo(TransformationEvent other) {
            if (StartTime != other.StartTime)
                return StartTime.CompareTo(other.StartTime);
            if (EndTime != other.EndTime)
                return EndTime.CompareTo(other.EndTime);
            return Transformtype.CompareTo(other.Transformtype);
        }
        public static bool TryParse(string s, out TransformationEvent t) {
            t = null;
            var parts = s.Trim().Split(Constants.Splitter.Comma);
            var valuescount = parts.Length - 4; // type, easing, start and end not inculded

            //if (valuescount < 0) return false;
            TransformTypes type;
            if (!Enum.TryParse(parts[0], out type)) return false;
            if (type == TransformTypes.T || type == TransformTypes.L) return false;
            t = Parse(s);
            return true;

        }
        public static TransformationEvent Parse(string s) {

            var parts = s.Trim().Split(Constants.Splitter.Comma);

            var type = (TransformTypes)Enum.Parse(typeof(TransformTypes), parts[0]);
            
            var easing = (Easing)int.Parse(parts[1]);
            var start = int.Parse(parts[2]);
            int end;
            if (!int.TryParse(parts[3], out end)) end = start;

            if (type == TransformTypes.P)
                return new ParameterEvent(start, end, (ParamTypes)Enum.Parse(typeof(ParamTypes), parts[4]));

            var actualcount = parts.Length - 4;
            var valuecount = (type == TransformTypes.C ? 3 : (type == TransformTypes.M || type == TransformTypes.V) ? 2 : 1);
            var sv = new List<double>();

            for (var i = 0; i < valuecount; i++) {
                sv.Add(double.Parse(parts[4 + i], Constants.IO.CULTUREINFO));
            }

            if (valuecount == actualcount) {
                return new TransformationEvent(type, easing, start, end, sv.ToArray());
            }

            var ev = new List<double>();

            for (var i = 0; i < valuecount; i++) {
                double temp;
                ev.Add(double.TryParse(parts[4 + i + valuecount], Constants.IO.NUMBER_STYLE,
                    Constants.IO.CULTUREINFO, out temp)
                    ? temp
                    : sv[i]);
            }

            return new TransformationEvent(type, easing, start, end, sv.ToArray(), ev.ToArray());

        }
    }
}
