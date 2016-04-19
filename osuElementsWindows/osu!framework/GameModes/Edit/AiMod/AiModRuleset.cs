using System;
using System.Collections.Generic;
using osu.GameplayElements;

namespace osu.GameModes.Edit.AiMod
{
    public abstract class AiModRuleset : MarshalByRefObject
    {
        public List<AiReport> Reports;

        /// <summary>
        /// Set a default type for reports returned by this ruleset.
        /// </summary>
        public abstract AiModType Type { get; }

        public AiModRuleset()
        {
            Reports = new List<AiReport>();
        }

        public List<AiReport> Run(HitObjectManagerBase hitObjectManager)
        {
            Reports.Clear();
            RunAllRules(hitObjectManager);
            return Reports;
        }

        /// <summary>
        /// Runs all rules for this ruleset and fills Reports.
        /// </summary>
        protected abstract void RunAllRules(HitObjectManagerBase hitObjectManager);
    }

    public enum BeatmapDifficulty
    {
        Easy,
        Normal,
        Hard,
        Insane,
        Expert
    }

    public enum AiModType
    {
        All = 0,
        Compose,
        Design,
        Timing,
        Meta,
        Mapset,
        Custom
    }
}