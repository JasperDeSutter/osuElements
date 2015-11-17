using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using osuElements.Helpers;

namespace osuElements.Events
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

        public TransformationEvent(TransformTypes type, Easing easing, int starttime, int endtime, double[] startvalues, double[] endvalues)
        {
            Transformtype = type;
            Easing = easing;
            StartTime = starttime;
            EndTime = endtime;
            StartValues = startvalues;
            EndValues = endvalues;
        }

        public virtual bool IsActive(double time)
        {
            return (time >= StartTime && time <= EndTime);
        }

        public virtual bool CurrentValues(double time, ref TransformationModel transform)
        {
            var count = StartValues.Count();
            var result = new double[count];
            var t = (time - StartTime) / Duration;

            if (t > 1) t = 1;
            if (t < 0) t = 0;

            if (Easing == Easing.In) t = 1 - ((1 - t) * (1 - t)); // 1- (1-t)squared
            if (Easing == Easing.Out) t = t * t; //t squared

            for (int i = 0; i < count; i++)
            {
                result[i] = StartValues[i] * (1 - t) + EndValues[i] * t;
            }
            switch (Transformtype)
            {
                case TransformTypes.F:
                    transform.Opacity = result[0];
                    break;
                case TransformTypes.M:
                    transform.PositionX = result[0];
                    transform.PositionY = result[1];
                    break;
                case TransformTypes.MX:
                    transform.PositionX = result[0];
                    break;
                case TransformTypes.MY:
                    transform.PositionY = result[0];
                    break;
                case TransformTypes.S:
                    transform.ScaleX = result[0];
                    transform.ScaleY = result[0];
                    break;
                case TransformTypes.V:
                    transform.ScaleX = result[0];
                    transform.ScaleY = result[1];
                    break;
                case TransformTypes.R:
                    transform.Angle = result[0];
                    break;
                case TransformTypes.C:
                    transform.Color.Red = (int)result[0]; //= new ComboColor((int)result[0], (int)result[1], (int)result[2]);
                    transform.Color.Green = (int)result[1];
                    transform.Color.Blue = (int)result[2];
                    break;
            }
            return time >= StartTime && time <= EndTime;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(Transformtype.ToString() + ",");
            result.Append((int)Easing + ",");
            result.Append(StartTime + ",");
            result.Append(Duration == 0 ? "" : "" + EndTime);

            bool issame = true;

            for (int i = 0; i < StartValues.Length; i++)
            {
                result.Append("," + StartValues[i].ToString(Constants.CULTUREINFO));
                if (StartValues[i] != EndValues[i]) issame = false;
            }

            if (!issame)
            {
                foreach (double b in EndValues)
                {
                    result.Append("," + b.ToString(Constants.CULTUREINFO));
                }
            }
            result.Append(Environment.NewLine);
            return result.ToString();
        }

        public int CompareTo(TransformationEvent other)
        {
            if (StartTime != other.StartTime)
                return StartTime.CompareTo(other.StartTime);
            if (EndTime != other.EndTime)
                return EndTime.CompareTo(other.EndTime);
            return Transformtype.CompareTo(other.Transformtype);
        }
        public static bool TryParse(string s, out TransformationEvent t)
        {
            t = null;
            string[] parts = s.Trim().Split(Splitter.Comma);
            int valuescount = parts.Count() - 4; // type, easing, start and end not inculded

            //if (valuescount < 0) return false;
            TransformTypes type;
            if (!Enum.TryParse(parts[0], out type)) return false;
            Easing easing;
            if (!Enum.TryParse(parts[1], out easing)) return false;
            int start;
            if (!int.TryParse(parts[2], out start)) return false;
            t = Parse(s);
            return true;

        }
        public static TransformationEvent Parse(string s)
        {

            string[] parts = s.Trim().Split(Splitter.Comma);

            TransformTypes type = (TransformTypes)Enum.Parse(typeof(TransformTypes), parts[0]);

            if (type == TransformTypes.L) return new LoopEvent(int.Parse(parts[1]), int.Parse(parts[2]));
            if (type == TransformTypes.T) return new TriggerEvent((TriggerTypes)Enum.Parse(typeof(TriggerTypes), parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));

            Easing easing = (Easing)int.Parse(parts[1]);
            int start = int.Parse(parts[2]);
            int end;
            if (!int.TryParse(parts[3], out end)) end = start;

            if (type == TransformTypes.P)
                return new ParameterEvent(start, end, (ParamTypes)Enum.Parse(typeof(ParamTypes), parts[4]));

            int actualcount = parts.Count() - 4;
            int valuecount = (type == TransformTypes.C ? 3 : (type == TransformTypes.M || type == TransformTypes.V) ? 2 : 1);
            List<double> sv = new List<double>();

            for (int i = 0; i < valuecount; i++)
            {
                sv.Add(double.Parse(parts[4 + i], Constants.FORMATPROVIDER));
            }

            if (valuecount == actualcount)
            {
                return new TransformationEvent(type, easing, start, end, sv.ToArray());
            }

            List<double> ev = new List<double>();

            for (int i = 0; i < valuecount; i++)
            {
                double temp;
                if (double.TryParse(parts[4 + i + valuecount], System.Globalization.NumberStyles.Any, Constants.FORMATPROVIDER, out temp))
                    ev.Add(temp);
                else ev.Add(sv[i]);
            }

            return new TransformationEvent(type, easing, start, end, sv.ToArray(), ev.ToArray());

        }
    }
}
