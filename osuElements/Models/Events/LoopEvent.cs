using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace osuElements.Events
{
    public class LoopEvent : TransformationEvent, ITransformable //acts like a transform element, but holds multiple which are looped over time
    {
        public List<TransformationEvent> Transformations;
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(Transformtype + ",");
            result.Append(Starttime + ",");
            result.Append(Loopcount);
            foreach (var t in Transformations) result.Append("  " + t);
            return result.ToString();
        }
        public int Loopcount;
        public LoopEvent(int starttime, int loopcount) : base(TransformTypes.L, Easing.None, starttime, starttime, null)
        {
            this.Loopcount = loopcount;
            Transformations = new List<TransformationEvent>();
        }

        public override int EndTime
        {
            get {
                return LoopedTransformations.Count < 1 ? Starttime : LoopedTransformations.Max(t => t.EndTime);
            }
        }
        /*public override int StartTime
        {
            get
            {
                return firsttime + starttime;
            }
        }*/

        private int _firsttime;

        private int _lasttime;

        private int _actualDuration => (_lasttime - _firsttime);
        List<TransformationEvent> _lts;
        List<TransformationEvent> LoopedTransformations
        {
            get
            {
                if (_lts != null) return _lts;
                _lts = new List<TransformationEvent>();
                for (int i = 0; i < Loopcount; i++)
                {
                    foreach (var te in Transformations)
                    {
                        _lts.Add(new TransformationEvent(te.Transformtype, te.Easing,
                            te.StartTime + _actualDuration * i,
                            te.EndTime + _actualDuration * i,
                            te.StartValues, te.EndValues));
                    }
                }
                return _lts;
            }
        }

        public override bool IsActive(double time)
        {
            time -= Starttime;
            if (time < _firsttime) return false;
            if (time > _firsttime + _actualDuration * Loopcount) return false;
            return LoopedTransformations.Any(te => te.IsActive(time));
        }
        public override bool CurrentValues(double time, ref TransformationModel transform)
        {
            if (time < StartTime) return false;
            time -= Starttime; //Events in loop are 0-based
            foreach(var te in LoopedTransformations)
            {
                if (te.StartTime<=time) te.CurrentValues(time, ref transform);
            }
            return time <= EndTime;
        }

        public void AddTransformation(TransformationEvent e)
        {
            if (e.EndTime > EndTime) EndTime = e.EndTime;
            Transformations.Add(e);
            Transformations.Sort();
            _firsttime = Transformations.Min(t => t.StartTime);
            _lasttime = Transformations.Max(t => t.EndTime);
            _lts = null;
        }
    }
}
