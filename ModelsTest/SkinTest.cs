using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using osuElements;
using osuElements.IO.File;
using osuElements.Skins;
using TestContent;
namespace ModelsTest
{
    [TestClass]
    public class SkinTest
    {
        private Skin _skin;


        [TestMethod]
        public void ReadTask() {
            var skinReader = SkinFileReader.SkinReader();
            _skin = new Skin { FullPath = Paths.SongFolder + @"\skin.ini" };
            var logger = new BasicLogger();
            _skin.ReadFile(logger);
            foreach (var log in logger.Errors) {
                Debug.WriteLine("_skin.ini - " + log);
            }
        }
    }
}
