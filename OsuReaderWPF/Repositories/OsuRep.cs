using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OsuReaderWPF.Models;
using OsuReaderWPF.Helpers;
namespace OsuReaderWPF.Repositories
{

    internal class OsuRep
    {
        //Defines methods directly related to an Osu instance, such as reading from the .osu file.
        public string Lijn { get; set; }

        public OsuRep(string lijn)
        {
            Lijn = lijn;
        }
        
        public static List<OsuRep> LeesBestand(string pad)
        {
            List<OsuRep> result = new List<OsuRep>();
            using (StreamReader sr = new StreamReader(pad))
            {
                string lijn = sr.ReadLine();
                while (lijn != null)
                {
                    OsuRep csv = new OsuRep(lijn);
                    result.Add(csv);
                    lijn = sr.ReadLine();
                }
            }
            return result;
        }


        public static void ReadFile(string path,Beatmap result)
        {
            string section = "";
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine();
                string[] parts;
                result.Version = Convert.ToInt32(line.Split(new char[] { 'v', Splitter.Space() }, StringSplitOptions.RemoveEmptyEntries)[3]);
                line = sr.ReadLine();
                List<HitObject> hitobjects = new List<HitObject>();
                List<TimingPoint> timingPoints = new List<TimingPoint>();
                while (line != null)
                {
                    if (line == "")
                    {
                        line = sr.ReadLine();
                        continue;
                    }
                    if (line.StartsWith(new string(Splitter.Bracket())))
                    {
                        section = line;
                        line = sr.ReadLine();
                        continue;
                    }
                    switch (section)
                    {
                        case "[TimingPoints]":
                            parts = line.Split(Splitter.Comma(), StringSplitOptions.RemoveEmptyEntries);
                            Timing offset = new Timing{TimeMS = Convert.ToInt32( parts[0])};
                            int signature = Convert.ToInt32(parts[2]);
                            SampleSets sampleSet = (SampleSets)Convert.ToInt32(parts[3]);
                            int customSet = Convert.ToInt32(parts[4]);
                            int volume = Convert.ToInt32(parts[5]);
                            bool isTiming = Convert.ToBoolean(Convert.ToInt32(parts[6]));
                            TimingPointOptions options = (TimingPointOptions)Convert.ToInt32(parts[7]);
                            double bpm = Convert.ToDouble(parts[1], Statics.CULTURE);
                            TimingPoint tp = new TimingPoint(offset, bpm, signature, sampleSet, customSet, volume, isTiming, options);
                            timingPoints.Add(tp);
                            break;
                        case "[HitObjects]":
                            parts = line.Split(Splitter.Comma(), StringSplitOptions.RemoveEmptyEntries);  //Start making HitObject
                            int x = Convert.ToInt32(parts[0]);
                            int y = Convert.ToInt32(parts[1]);
                            Timing time = new Timing { TimeMS = Convert.ToInt32(parts[2]) };
                            HOTypes type = (HOTypes)Convert.ToInt32(parts[3]);
                            bool isNewCombo = CompareFunctions.CompareObjectsTypes(type, HOTypes.NewCombo);
                            HitsoundTypes hitsound = (HitsoundTypes)Convert.ToInt32(parts[4]);

                            HitObject hObject = new HitObject(time, x, y, isNewCombo, type, hitsound);

                            if (CompareFunctions.CompareObjectsTypes(type, HOTypes.HitCircle))                            //Make HitCircle
                            {

                                HitCircle h = new HitCircle(hObject);
                                if (parts.Length > 5) h.Additions = GetAdditions(parts[5]);
                                hitobjects.Add(h);
                            }
                            if (CompareFunctions.CompareObjectsTypes(type, HOTypes.Slider))                               //Make Slider
                            {
                                Slider s = new Slider(hObject);
                                int repeat = Convert.ToInt32(parts[6]);
                                double length = Convert.ToDouble(parts[7], Statics.CULTURE);
                                s.Repeat = repeat;
                                s.Length = length;
                                string[] points = parts[5].Split(Splitter.Pipe());
                                SliderTypes sliderType;
                                switch (points[0])
                                {
                                    case "C":
                                        sliderType = SliderTypes.Catmull;
                                        break;
                                    case "B":
                                        sliderType = SliderTypes.Bezier;
                                        break;
                                    case "L":
                                        sliderType = SliderTypes.Linear;
                                        break;
                                    case "P":
                                        sliderType = SliderTypes.PerfectCurve;
                                        break;
                                    default: sliderType = SliderTypes.Linear;
                                        break;
                                }
                                s.SliderType = sliderType;
                                Position[] pointPositions = new Position[points.Length];
                                pointPositions[0] = s.StartPosition;
                                pointPositions[0].IsSliderPoint = true;
                                for (int i = 1; i < points.Length; i++)
                                {
                                    int[] p = points[i].Split(Splitter.Colon()).Select(int.Parse).ToArray();
                                    pointPositions[i] = new Position(p[0], p[1], true);
                                }
                                s.CurvePoints = pointPositions;
                                int[] sadditions;
                                int[][] pointadditions;
                                HitsoundTypes[] pointHitsounds;
                                if (parts.Length > 8)
                                {
                                    pointHitsounds = parts[8].Split(Splitter.Pipe()).Select(sel=>(HitsoundTypes)int.Parse(sel)).ToArray();
                                    sadditions = GetAdditions(parts[10]);
                                    string[]  pas = parts[9].Split(Splitter.Pipe());
                                    pointadditions = new int[pas.Length][];
                                    for (int i = 0; i < pas.Length; i++)
                                    {
                                        pointadditions[i] = GetAdditions(pas[i]);
                                    }
                                    
                                }
                                else
                                {
                                    sadditions = new int[4] { 0, 0, 0, 0 };
                                    pointHitsounds = new HitsoundTypes[points.Length];
                                    pointadditions=new int[points.Length][];
                                    for (int i = 0; i < points.Length; i++)
                                    {
                                        pointadditions[i] = new int[2] { 0, 0 };
                                    }
                                }
                                s.Additions = sadditions;
                                s.PointHisounds = pointHitsounds;
                                s.PointAdditions = pointadditions;
                                hitobjects.Add(s);
                            }
                            if (CompareFunctions.CompareObjectsTypes(type, HOTypes.Spinner))                               //Make Spinner
                            {
                                Spinner p = new Spinner(hObject);
                                if(parts.Length>6)p.Additions = GetAdditions(parts[6]);
                                p.EndTime = new Timing { TimeMS = Convert.ToInt32(parts[5]) };
                                hitobjects.Add(p);
                            }
                            break;
                    }
                    line = sr.ReadLine();
                }
                hitobjects.Sort();
                //Add radius to hitcircles and sliders
                result.TimingPoints = timingPoints;
                result.HitObjects = hitobjects;
            }

        }

        private static int[] GetAdditions(string part)
        {
            string[] a = part.Split(Splitter.Colon(), StringSplitOptions.RemoveEmptyEntries);
            int[] additions = a.Select(int.Parse).ToArray();
            return additions;
        }
    }
}

