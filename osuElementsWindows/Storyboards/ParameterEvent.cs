using System.Text;
using osuElements.Helpers;

namespace osuElements.Storyboards
{
    public class ParameterEvent : TransformationEvent
    {
        public ParameterTypes Parameter;
        public ParameterEvent(int starttime, int endtime, ParameterTypes parameter) : base(TransformTypes.P, Easing.None, starttime, endtime, null)
        {
            Parameter = parameter;
            StartTime = starttime;
            EndTime = endtime;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(Transformtype + ",");
            result.Append((int)Easing + ",");
            result.Append(StartTime + ",");
            if (Duration > 0)
                result.Append(EndTime);
            result.Append(",");
            result.Append(Parameter);
            return result.ToString();
        }
    }

}
