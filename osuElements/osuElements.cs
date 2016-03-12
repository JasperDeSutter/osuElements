using System;
using System.IO;
using osuElements.Api.Repositories;
using osuElements.Beatmaps;
using osuElements.IO;
using osuElements.Replays;
using osuElements.Skins;
using osuElements.Storyboards;

namespace osuElements
{
    public static class osuElements
    {
        #region Fields

        private static Func<string, Stream> _fileReaderFunc;
        private static Func<string, Stream> _fileWriterFunc;
        private static Func<byte[], byte[]> _decompressLzmaFunc1;
        private static Func<string, string> _md5Func;

        #endregion

        static osuElements() {
            StoryboardFileRepository = Storyboard.FileReader();
            SkinFileRepository = SkinFileReader.SkinReader();
            BeatmapFileRepository = BeatmapFileReader.BeatmapReader();
            ReplayFileRepository = Replay.FileReader();
            //using (RegistryKey osureg = Registry.ClassesRoot.OpenSubKey("osu\\DefaultIcon")) {
            //    if (osureg != null) {
            //        string osukey = osureg.GetValue(null).ToString();
            //        string osupath;
            //        osupath = osukey.Remove(0, 1);
            //        osuDirectory = osupath.Remove(osupath.Length - 11);
            //    }
            //}

        }

        #region Properties

        public static string osuDirectory { get; set; }

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
        /// <summary>
        /// IN: a compressed byte[], OUT: the decompressed byte[]
        /// </summary>
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

        /// <summary>
        /// IN: a filepath, OUT: the hash for that file
        /// </summary>
        public static Func<string, string> Md5Func {
            get
            {
                if (_md5Func == null)
                    throw new NullReferenceException("Supply a osuElements.Md5Func function before tring to decompress a replay");
                return _md5Func; }
            set { _md5Func = value; }
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