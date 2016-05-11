using System.Linq;
using osuElements;
using osuElements.Beatmaps;

namespace SampleCode
{
    public class BeatmapExamples
    {
        private Beatmap beatmap;
        //reading, editing and writing a beatmap
        public void ReadingWriting() {
            //this constructor will automatically read the file, new Beatmap() wont.
            //Note that you only need to supply the beatmaps folder and the filenam
            beatmap =
                new Beatmap(@"1 Kenji Ninuma - DISCO PRINCE\Kenji Ninuma - DISCOüÜPRINCE (peppy) [Normal].osu");
            beatmap.Version = "THIS MAP IS GREAT";
            beatmap.DifficultyApproachRate = 9.5f;
            //Hitobject space has different coordinates that the rest of the game elements -> FromHitobject method
            var hitcircle = new HitCircle(Position.FromHitobject(10, 20), 200);
            beatmap.HitObjects.Add(hitcircle);
            beatmap.FileName = "Kenji Ninuma - DISCOüÜPRINCE (peppy) [Improved version].osu";
            beatmap.WriteFile();
        }

        //Beatmap member types
        public void HitObjectsAndTimingpoints() {
            var centerofscreen = Position.FromHitobject(256, 188);
            var hitcirlce = new HitCircle(centerofscreen, 100, true); //starts at 100ms and is a new combo

            var slider = new Slider(centerofscreen, 300);
            slider.ControlPoints = new[] { Position.Zero, centerofscreen, Position.Unit }; //add 3 control points
            slider.SliderType = SliderType.PerfectCurve; //make the slider the correct type

            var spinner = new Spinner(centerofscreen, 100, 200); //starts at 100, ends at 200

            var bpmTimingPoint = new TimingPoint(100, 128); //starttime 100 and 128bpm
            var sliderSpeedPoint = new TimingPoint(100, 0) { IsTiming = false, SliderVelocityMultiplier = 1.5 };

            beatmap.TimingPoints.Add(sliderSpeedPoint);
        }

        //BeatmapManager and slider
        public void BeatmapManager() {
            //this class supplies functions for the hitobjects, difficulty ...
            //the constructor will automatically calculate combocolors, combonumbers and difficulties (such as approachrate ms and timing300)
            var beatmapManager = new BeatmapManager(beatmap);
            var timing300 = beatmapManager.HitWindow300;
            var approachratems = beatmapManager.PreEmpt;
            beatmapManager.SetMods(Mods.HardRock | Mods.Hidden); //enables the mods hardrock and hidden
            beatmapManager.DifficultyCalculations(); //recalculate the difficulties
            var timing300Hr = beatmapManager.HitWindow300; //this will now be different than the previous timing300

            beatmapManager.SliderCalculations();
            //this will create curves for the sliders. As this is an intensive task, it's async -> wait
            //this will get the selected map's hitobjects (better to work this way, no need for a reference to the beatmap)
            var hitobjects = beatmapManager.GetHitObjects();
            //some LINQ to select the first slider in the list
            var firstslider = (Slider)hitobjects.First(ho => ho.IsHitObjectType(HitObjectType.Slider));
            var positionAt20Ms = firstslider.PositionAtTime(firstslider.StartTime + 20);
        }
    }
}