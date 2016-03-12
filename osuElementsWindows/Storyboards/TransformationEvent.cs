using System;
using System.Linq;
using System.Text;
using osuElements.Helpers;

namespace osuElements.Storyboards
{
    public class TransformationEvent : IComparable<TransformationEvent>
    {
        public virtual int EndTime { get; set; }
        public int Duration => EndTime - Starttime;

        public float[] StartValues { get; set; }
        public float[] EndValues { get; set; }
        public TransformTypes Transformtype { get; set; }
        public Easing Easing { get; set; }

        protected int Starttime;

        public virtual int StartTime
        {
            get { return Starttime; }
            set { Starttime = value; }
        }

        public float[] ValuesAt(float time) {
            var t = MathHelper.Clamp(time / Duration);
            var result = new float[ValueCount];
            for (int i = 0; i < ValueCount; i++) {
                var startValue = StartValues[i];
                result[i] = MathHelper.Lerp(t, StartValues[i], EndValues[i]);
            }
            return result;
        }

        public int ValueCount => StartValues.Length;

        public TransformationEvent(TransformTypes type, Easing easing, int starttime, int endtime, float[] startvalues)
            : this(type, easing, starttime, endtime, startvalues, startvalues) { }

        public TransformationEvent(TransformTypes type, Easing easing, int starttime, int endtime, float[] startvalues,
            float[] endvalues) {
            Transformtype = type;
            Easing = easing;
            StartTime = starttime;
            EndTime = endtime;
            StartValues = startvalues;
            EndValues = endvalues;
        }

        public int CompareTo(TransformationEvent other) {
            if (StartTime != other.StartTime)
                return StartTime.CompareTo(other.StartTime);
            if (EndTime != other.EndTime)
                return EndTime.CompareTo(other.EndTime);
            return Transformtype.CompareTo(other.Transformtype);
        }

        public override string ToString() {
            var result = new StringBuilder();
            result.Append(Transformtype + ",");
            result.Append((int)Easing + ",");
            result.Append(StartTime + ",");
            if (Duration > 0)
                result.Append(EndTime);

            var issame = true;

            var startValues = StartValues;
            var endValues = EndValues;

            for (var i = 0; i < ValueCount; i++) {
                switch (Transformtype) {
                    case TransformTypes.C:
                        startValues[i] = Math.Max(0, Math.Min(255, (int)startValues[i]));
                        endValues[i] = Math.Max(0, Math.Min(255, (int)endValues[i]));
                        break;
                    case TransformTypes.F:
                        startValues[i] = Math.Max(0, Math.Min(1, startValues[i]));
                        endValues[i] = Math.Max(0, Math.Min(1, endValues[i]));
                        break;
                }

                result.Append("," + startValues[i].ToString(Constants.CULTUREINFO));
                if (startValues[i] != EndValues[i]) issame = false;
            }
            if (issame) return result.ToString();

            foreach (var b in EndValues) {
                result.Append("," + b.ToString(Constants.CULTUREINFO));
            }
            return result.ToString();
        }

        public static bool TryParse(string s, out TransformationEvent[] t) {
            t = null;
            var parts = s.Trim().Split(',');
            var valuescount = parts.Length - 4; // type, easing, start and end not inculded

            if (valuescount < 0) return false;
            TransformTypes type;
            if (!Enum.TryParse(parts[0], out type)) return false;
            if (type == TransformTypes.T || type == TransformTypes.L) return false;
            t = Parse(s);
            return true;
        }

        public static TransformationEvent[] Parse(string s) {
            var parts = s.Trim().Split(',');

            var type = (TransformTypes)Enum.Parse(typeof(TransformTypes), parts[0]);
            var easing = (Easing)int.Parse(parts[1]);
            var start = int.Parse(parts[2]);
            int end;
            if (!int.TryParse(parts[3], out end)) end = start;

            if (type == TransformTypes.P) {
                return
                    new ParameterEvent(start, end, (ParameterTypes)Enum.Parse(typeof(ParameterTypes), parts[4]))
                        .AsArray<TransformationEvent>();
            }

            var values = parts.Skip(4).ToArray();
            //Magic number 4: the first four default elements of every transformation
            var valuecount = type == TransformTypes.C ? 3 : type == TransformTypes.M || type == TransformTypes.V ? 2 : 1;
            var sv =
                Enumerable.Range(0, valuecount).Select(i => float.Parse(values[i], Constants.CULTUREINFO)).ToArray();

            var count = values.Length / valuecount;

            if (count == 1) {
                return new TransformationEvent(type, easing, start, end, sv).AsArray();
            }

            var result = new TransformationEvent[--count];

            for (int i = 0; i < count; i++) {
                var ev =
                    Enumerable.Range((i + 1) * valuecount, valuecount)
                        .Select(j => float.Parse(values[j], Constants.CULTUREINFO))
                        .ToArray();
                result[i] = new TransformationEvent(type, easing, start, end, sv, ev);
                sv = ev;
            }
            return result;
        }
    }
}