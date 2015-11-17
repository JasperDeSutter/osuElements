using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace osuElements.Events
{
    public interface ITransformable
    {
        //bool currentvalues(float time, ref TransformationModel transform);
        void AddTransformation(TransformationEvent transform);
    }
    public class UndefinedEvent:Event
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
    public class TransformationModel
    {
        public double Opacity;
        public double PositionX;
        public double PositionY;
        public double ScaleX;
        public double ScaleY;
        public ComboColor Color;
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
            Color = new ComboColor(255, 255, 255);
            Opacity = 1;
            Angle = 0;
        }
        public void SetParametersFalse()
        {
            FlipVertical = false;
            FlipHorizontal = false;
            AdditiveColor = false;
        }
    }
}
