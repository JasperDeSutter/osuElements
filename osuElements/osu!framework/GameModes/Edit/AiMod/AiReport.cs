using System.Collections.Generic;
using osu.GameplayElements.HitObjects;
using System;

namespace osu.GameModes.Edit.AiMod
{
    public class AiReport : MarshalByRefObject
    {
        public readonly string Information;
        public readonly Severity Severity;
        public int Time;
        public readonly string WebLink;
        public readonly List<HitObjectBase> RelatedHitObjects = new List<HitObjectBase>();
        public readonly BeenCorrectedDelegate corrected;

        public AiReport(Severity severity, string information)
            : this(-1, severity, information, 0, null)
        {

        }

        public AiReport(int time, Severity severity, string information, int weblink, BeenCorrectedDelegate corrected)
        {
            Time = time;
            Severity = severity;
            Information = information;
            WebLink = "http://osu.ppy.sh/web/osu-gethelp.php?p=" + weblink;
            this.corrected = corrected;
        }

        /// <summary>
        /// Draws this instance.
        /// </summary>
        public virtual void Draw()
        {

        }

        public bool Check()
        {
            if (corrected == null) return false;
            return corrected();
        }
    }

    public enum Severity
    {
        Info,
        Warning,
        Error
    }

    /// <summary>
    /// Delegate method should return true when the issue related to the report has been corrected.
    /// </summary>
    public delegate bool BeenCorrectedDelegate();
}