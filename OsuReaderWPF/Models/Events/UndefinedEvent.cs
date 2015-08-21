using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace osuElements
{
    public class UndefinedEvent:Event
    {
        public string[] Lineparts;
        public UndefinedEvent(string[] lineparts)
        {
            Lineparts = lineparts;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Lineparts.Length-1; i++)
            {
                result.Append(Lineparts[i] + ",");
            }
            result.Append(Lineparts.Last()+Environment.NewLine);
            return result.ToString();
        }
    }
}
