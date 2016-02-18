using System.Collections.Generic;
using System.Text;

namespace osuElements.Storyboards
{
    public class TriggerEvent : TransformationEvent, ITransformable
    {
        public List<TransformationEvent> Transformations;

        public TriggerTypes TriggerType;
        public TriggerEvent(TriggerTypes trigger, int starttime, int endtime) : base(TransformTypes.T, Easing.None, starttime, endtime, null)
        {
            Transformations = new List<TransformationEvent>();
            TriggerType = trigger;
            StartTime = starttime;
            EndTime = endtime;
        }

        public override bool CurrentValues(double time, ref TransformationModel transform)
        {
            if (!IsActive(time)) return false;
            time -= StartTime;

            foreach (TransformationEvent te in Transformations)
            {
                te.CurrentValues(time, ref transform);
            }
            return true;
        }

        public void AddTransformation(TransformationEvent e)
        {
            if (e.EndTime > EndTime) EndTime = e.EndTime;
            Transformations.Add(e);
            Transformations.Sort();
        }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(" " + Transformtype + ",");
            result.Append(TriggerType + ",");
            result.Append(StartTime + ",");
            result.Append(EndTime);
            foreach (var t in Transformations) result.Append("/r/n  " + t);
            return result.ToString();
        }
    }
}
