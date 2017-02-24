using System.IO;
using Microsoft.Win32;
using osuElements.Api.Repositories;
using osuElements.Beatmaps;
using osuElements.Db;
using osuElements.IO;
using osuElements.Replays;
using osuElements.Skins;
using osuElements.Storyboards;

namespace osuElements
{
    public static class osuElements
    {
        private static string _osuDirectory;

        public static Stream WriteStream(string path) {
            if (File.Exists(path)) File.Delete(path);
            return new FileStream(path, FileMode.Create);
        }

        static osuElements() {
            StoryboardFileRepository = Storyboard.FileReader();
            SkinFileRepository = SkinFileReader.SkinReader();
            BeatmapFileRepository = BeatmapFileReader.BeatmapReader();
            ReplayFileRepository = Replay.FileReader();
            CollectionDbRepository = CollectionDb.FileReader();
            OsuDbRepository = OsuDb.FileReader();
            ScoresDbRepository = ScoresDb.FileReader();

            ApiReplayRepository = new ApiReplayRepository();
            ApiBeatmapRepository = new ApiBeatmapRepository();
            ApiReplayRepository = new ApiReplayRepository();
            ApiUserRepository = new ApiUserRepository();

#if !STANDARD

            using (var osureg = Registry.ClassesRoot.OpenSubKey("osu\\DefaultIcon")) {
                if (osureg == null) return;
                var osukey = osureg.GetValue(null).ToString();
                var osupath = osukey.Remove(0, 1);
                OsuDirectory = osupath.Remove(osupath.Length - 11);
            }
#endif
        }

        #region Properties


        public static string OsuDirectory
        {
            get { return _osuDirectory; }
            set
            {
                _osuDirectory = value;
                OsuSongDirectory = Path.Combine(value, "Songs");
                OsuSkinsDirectory = Path.Combine(value, "Skins");
                OsuReplaysDirectory = Path.Combine(value, "Replays");
            }
        }

        public static string OsuSongDirectory { get; set; }
        public static string OsuSkinsDirectory { get; set; }
        public static string OsuReplaysDirectory { get; set; }

        //Custom kind of dependency injection (DI)
        public static IFileRepository<Beatmap> BeatmapFileRepository { get; set; }
        public static IFileRepository<Storyboard> StoryboardFileRepository { get; set; }
        public static IFileRepository<Replay> ReplayFileRepository { get; set; }
        public static IFileRepository<Skin> SkinFileRepository { get; set; }
        public static IFileRepository<CollectionDb> CollectionDbRepository { get; set; }
        public static IFileRepository<OsuDb> OsuDbRepository { get; set; }
        public static IFileRepository<ScoresDb> ScoresDbRepository { get; set; }

        //Not necessary right now
        public static IApiBeatmapRepository ApiBeatmapRepository { get; set; }
        public static IApiReplayRepository ApiReplayRepository { get; set; }
        public static IApiUserRepository ApiUserRepository { get; set; }
        public static IApiMultiplayerRepository ApiMultiplayerRepository { get; set; }
        public static string ApiKey
        {
            set { ApiRepositoryBase.Key = value; }
        }
        public static int LatestBeatmapVersion { get; set; } = 14;
        public static float LatestSkinVersion { get; set; } = 2.5f;

        #endregion

        public static Stream ReadStream(string path) {
            return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        }
    }
}