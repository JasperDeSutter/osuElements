// IMatchFinder.cs

using System.IO;

namespace osuElements.Helpers.LZMA
{
    internal interface IMatchFinder
	{
		void Create(uint historySize, uint keepAddBufferBefore,
				uint matchMaxLen, uint keepAddBufferAfter);
		uint GetMatches(uint[] distances);
		void Skip(uint num);
        void SetStream(Stream inStream);
        void Init();
        void ReleaseStream();
        byte GetIndexByte(int index);
        uint GetMatchLen(int index, uint distance, uint limit);
        uint GetNumAvailableBytes();
	}
}
