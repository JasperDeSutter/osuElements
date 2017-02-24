using osu.GameplayElements.HitObjects;

namespace osu.GameModes.Edit.AiMod.Reports
{
    public class AiReportDifficulty : AiReport
    {
        public AiReportDifficulty(BeatmapDifficulty difficulty, string condition)
            : base(Severity.Info, difficulty + " criteria: " + condition)
        {
        }
    }

    public class AiReportDifficultyOneObject : AiReportOneObject
    {
        public AiReportDifficultyOneObject(BeatmapDifficulty difficulty, string condition, HitObjectBase h1)
            : base(h1, h1.StartTime, null, Severity.Info, difficulty + " criteria: " + condition, 0)
        {
        }
    }

    public class AiReportDifficultyTwoObjects : AiReportTwoObjects
    {
        public AiReportDifficultyTwoObjects(BeatmapDifficulty difficulty, string condition, HitObjectBase h1, HitObjectBase h2)
            : base(h1, h2, null, Severity.Info, difficulty + " criteria: " + condition, 0)
        {
        }
    }
}
