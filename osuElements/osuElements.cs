using System;
using System.IO;
using osuElements.Replays;
using osuElements.Repositories;
using osuElements.Repositories.Api;
using osuElements.Repositories.File;
using osuElements.Skins;
using osuElements.Storyboards;

namespace osuElements
{
    public static class osuElements
    {
        #region Fields

        private static Func<string, Stream> _fileReaderFunc;
        private static Func<string, Stream> _fileWriterFunc;
        private static Action<Stream, Stream> _decompressLzmaFunc;
        private static Func<byte[], byte[]> _decompressLzmaFunc1;

        public static Func<byte[], byte[]> DecompressLzmaFunc
        {
            get
            {
                if (_decompressLzmaFunc1 == null)
                    throw new NullReferenceException("Supply a osuElements.DecompressLzmaFunc function before tring to decompress a replay");
                return _decompressLzmaFunc1;
            }
            set { _decompressLzmaFunc1 = value; }
        }

        #endregion

        static osuElements() {
            //BeatmapFileRepository = new BeatmapFileRepository();
            //StoryboardFileRepository = new StoryboardFileRepository();
            StoryboardFileRepository = Storyboard.FileReader();
            SkinFileRepository = Skin.FileReader();
            BeatmapFileRepository = Beatmap.FileReader();
            ReplayFileRepository = new ReplayFileRepository();
            //SkinFileRepository = new SkinFileRepository();
            //ApiBeatmapRepository = new ApiBeatmapRepository();
            //ApiMultiplayerRepository = new ApiMultiplayerRepository();
            //ApiReplayRepository = new ApiReplayRepository();
            //ApiUserRepository = new ApiUserRepository();
        }

        #region Properties

        public static Func<string, Stream> FileReaderFunc
        {
            get
            {
                if (_fileReaderFunc == null)
                    throw new NullReferenceException("Supply a osuElements.FileReaderFunc function before tring to read a file");
                return _fileReaderFunc;
            }
            set { _fileReaderFunc = value; }
        }

        public static Func<string, Stream> FileWriterFunc
        {
            get
            {
                if (_fileWriterFunc == null)
                    throw new NullReferenceException("Supply an osuElements.FileWriterFunc before tring to write to a file");
                return _fileWriterFunc;
            }
            set { _fileWriterFunc = value; }
        }

        public static Action<Stream, Stream> DecompressLzmaAction
        {
            get
            {
                if (_decompressLzmaFunc == null)
                    throw new NullReferenceException("Supply a osuElements.DecompressLzmaFunc function before tring to decompress a replay");
                return _decompressLzmaFunc;
            }
            set { _decompressLzmaFunc = value; }
        }

        //Custom kind of dependency injection (DI)
        public static IFileRepository<Beatmap> BeatmapFileRepository { get; set; }
        public static IFileRepository<Storyboard> StoryboardFileRepository { get; set; }
        public static IFileRepository<Replay> ReplayFileRepository { get; set; }
        public static IFileRepository<Skin> SkinFileRepository { get; set; }

        //Not necessary right now
        //public static IApiBeatmapRepository ApiBeatmapRepository { get; set; }
        //public static IApiReplayRepository ApiReplayRepository { get; set; }
        //public static IApiUserRepository ApiUserRepository { get; set; }
        //public static IApiMultiplayerRepository ApiMultiplayerRepository { get; set; }
        public static string ApiKey
        {
            set { ApiRepositoryBase.Key = value; }
        }

        public static int LatestBeatmapVersion { get; set; } = 14;
        public static float LatestSkinVersion { get; set; } = 2.5f;

        #endregion

    }
}