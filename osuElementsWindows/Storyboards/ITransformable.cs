using System.Collections.Generic;

namespace osuElements.Storyboards
{
    public interface ITransformable
    {
        void AddTransformation(params TransformationEvent[] transforms);
        void RemoveTransformation(params TransformationEvent[] transforms);
        List<TransformationEvent> Transformations { get; set; }
    }
}