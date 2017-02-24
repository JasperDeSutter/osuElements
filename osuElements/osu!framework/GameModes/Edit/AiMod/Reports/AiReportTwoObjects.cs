using osu.GameplayElements.HitObjects;

namespace osu.GameModes.Edit.AiMod.Reports
{
    public class AiReportTwoObjects : AiReport
    {
        public readonly HitObjectBase h1;
        public readonly HitObjectBase h2;

        public AiReportTwoObjects(HitObjectBase h1, HitObjectBase h2, BeenCorrectedDelegate corrected, Severity severity, string information, int weblink)
            : base((h1.EndTime - h2.StartTime) / 2 + h2.StartTime, severity, information, weblink, corrected)
        {
            this.h1 = h1;
            this.h2 = h2;

            RelatedHitObjects.Add(h1);
            RelatedHitObjects.Add(h2);
        }
    }
}
