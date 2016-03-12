namespace osuElements.Helpers
{
    public interface IHitsound
    {
        SampleSet SampleSet { get; set; }
        SampleSet AdditionSampleSet { get; set; }
        HitObjectSoundType SoundType { get; set; }
        Custom Custom { get; set; }
    }
}