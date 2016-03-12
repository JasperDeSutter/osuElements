using osuElements.Helpers;

namespace osuElements.Beatmaps.Base
{
    public abstract class HitObjectBase
    {
        /// <summary>
        /// The time at which the object is to be hit.
        /// </summary>
        public int StartTime { get; set; }

        /// <summary>
        /// For spannable objects, the time which the object is no longer valid.
        /// For non-spannable objects, equal to StartTime.
        /// </summary>
        public int EndTime { get; set; }

        /// <summary>
        /// Time length of this object.
        /// </summary>
        public int Duration => EndTime - StartTime;

        /// <summary>
        /// The type of this object.
        /// </summary>
        public HitObjectType Type { get; }

        public bool IsType(HitObjectType type) {
            return Type.HasFlag(type);
        }

        /// <summary>
        /// Hitsound data for this object.
        /// </summary>
        public HitObjectSoundType SoundType;

        public bool Whistle
        {
            get { return SoundType.HasFlag(HitObjectSoundType.Whistle); }
            set
            {
                if (value)
                    SoundType |= HitObjectSoundType.Whistle;
                else
                    SoundType &= ~HitObjectSoundType.Whistle;
            }
        }

        public bool Finish
        {
            get { return SoundType.HasFlag(HitObjectSoundType.Finish); }
            set
            {
                if (value)
                    SoundType |= HitObjectSoundType.Finish;
                else
                    SoundType &= ~HitObjectSoundType.Finish;
            }
        }

        public bool Clap
        {
            get { return SoundType.HasFlag(HitObjectSoundType.Clap); }
            set
            {
                if (value)
                    SoundType |= HitObjectSoundType.Clap;
                else
                    SoundType &= ~HitObjectSoundType.Clap;
            }
        }

        /// <summary>
        /// The number of segments in this object. As an example, a slider with one repeat arrow will have two segments.
        /// </summary>
        public int SegmentCount { get; set; } = 1;

        /// <summary>
        /// The length of a segment.
        /// </summary>
        public int SegmentLength => Duration / SegmentCount;

        /// <summary>
        /// The length of this object in gamefield pixels.
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// If this object has a New Combo marker, how many additional colours do we cycle by?
        /// </summary>
        public int ComboColourOffset { get; set; }

        /// <summary>
        /// The zero-based index for which combo colour to use.
        /// Needed where an RGB triple is insufficient.
        /// </summary>
        public int ComboColourIndex { get; set; }

        /// <summary>
        /// The raw colour value of this object (combo colour).
        /// </summary>
        public Colour Colour { get; set; }

        /// <summary>
        /// Gamefield position of this object.
        /// </summary>
        public Position StartPosition { get; set; }

        /// <summary>
        /// For spannable objects, the position at which this object ends.
        /// Note that in the case of repeat sliders, this will be the final position of the ball.
        /// </summary>
        public abstract Position EndPosition { get; set; }

        /// <summary>
        /// Current height in a stack of notes. Zero means no stack.
        /// </summary>
        public int StackCount { get; set; }

        /// <summary>
        /// The number displayed on this hitobject (one-based).
        /// </summary>
        public abstract int ComboNumber { get; set; }

        /// <summary>
        /// Is this object the last in a combo?
        /// </summary>
        public bool LastInCombo { get; set; }

        public override string ToString() {
            return Type + ": " + StartTime + "-" + EndTime + " stack:" + StackCount;
        }

        /// <summary>
        /// Find the centre of the clickable position at specified time. Useful for sliders, where this position changes.
        /// </summary>
        /// <param name="time"></param>
        /// <returns>Centre of clickable position.</returns>
        public virtual Position PositionAtTime(int time) {
            return StartPosition;
        }
    }
}
