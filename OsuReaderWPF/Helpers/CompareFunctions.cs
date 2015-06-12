using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsuReaderWPF.Models;

namespace OsuReaderWPF.Helpers
{
    public static class CompareFunctions
    {
        public static bool CompareObjectsTypes(this HOTypes a, HOTypes b)
        {
            return (a & b) > (HOTypes)0;
        }
    }
}
