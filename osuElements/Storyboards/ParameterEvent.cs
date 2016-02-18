using System;
using System.Text;

namespace osuElements.Storyboards
{
    public class ParameterEvent : TransformationEvent
    {
        public ParamTypes Parameter;
        public ParameterEvent(int starttime, int endtime, ParamTypes param) : base(TransformTypes.P, Easing.None, starttime, endtime, null)
        {
            Parameter = param;
            StartTime = starttime;
            EndTime = endtime;
        }
        public override bool CurrentValues(double time, ref TransformationModel transform)
        {
            var dontusevalue = time > EndTime && StartTime != EndTime; //Dont draw when start!=end and time>end
            switch (Parameter)
            {
                case ParamTypes.A:
                    transform.AdditiveColor = !dontusevalue;
                    break;
                case ParamTypes.H:
                    transform.FlipHorizontal = !dontusevalue;
                    break;
                case ParamTypes.V:
                    transform.FlipVertical = !dontusevalue;
                    break;
                default: return false;
            }
            return time >= StartTime && time <= EndTime;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(Transformtype.ToString() + ",");
            result.Append((int)Easing + ",");
            result.Append(StartTime + ",");
            result.Append(Duration == 0 ? "," : EndTime + ",");
            result.Append(Parameter.ToString());
            result.Append(Environment.NewLine);
            return result.ToString();
        }
    }

}
