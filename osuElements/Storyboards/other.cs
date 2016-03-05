using System.Collections.Generic;

namespace osuElements.Storyboards
{
    public interface ITransformable
    {
        //bool currentvalues(float time, ref TransformationModel transform);
        void AddTransformation(TransformationEvent transform);
        List<TransformationEvent> Transformations { get; set; }
    }
    public class UndefinedEvent:EventBase
    {
        public string[] Lineparts;
        public UndefinedEvent(string[] lineparts)
        {
            Lineparts = lineparts;
        }
        public override string ToString()
        {
            return string.Join(",", Lineparts);
        }
    }
    /*public class TransformationModel
    {
        public double Opacity;
        public double PositionX;
        public double PositionY;
        public double ScaleX;
        public double ScaleY;
        public ComboColour Colour;
        public double Angle;
        public bool FlipVertical;
        public bool FlipHorizontal;
        public bool AdditiveColor;
        public TransformationModel()
        {
            SetParametersFalse();
        }
        public TransformationModel(float x, float y) : this()
        {
            PositionX = x;
            PositionY = y;
            ScaleY = ScaleX = 1;
            Colour = new ComboColour(255, 255, 255);
            Opacity = 1;
            Angle = 0;
        }
        public void SetParametersFalse()
        {
            FlipVertical = false;
            FlipHorizontal = false;
            AdditiveColor = false;
        }
    }*/
}
