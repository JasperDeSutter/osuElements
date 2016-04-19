using osu.GameplayElements.HitObjects;

namespace osu.GameModes.Edit.AiMod.Reports
{
    public class AiReportOneObject : AiReport
    {
        public readonly HitObjectBase h1;

        public AiReportOneObject(HitObjectBase h,int time, BeenCorrectedDelegate corrected, Severity severity, string information, int weblink)
            : base(time, severity, information, weblink, corrected)
        {
            this.h1 = h;
            
            RelatedHitObjects.Add(h);
        }
    }
}
