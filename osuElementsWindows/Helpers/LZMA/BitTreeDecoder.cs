namespace osuElements.Helpers.LZMA
{
    internal struct BitTreeDecoder
    {
        private readonly BitDecoder[] Models;
        private readonly int NumBitLevels;

        public BitTreeDecoder(int numBitLevels)
        {
            NumBitLevels = numBitLevels;
            Models = new BitDecoder[1 << numBitLevels];
        }

        public void Init()
        {
            for (uint i = 1; i < 1 << NumBitLevels; i++)
                Models[i].Init();
        }

        public uint Decode(RangeDecoder rangeRangeDecoder)
        {
            uint m = 1;
            for (var bitIndex = NumBitLevels; bitIndex > 0; bitIndex--)
                m = (m << 1) + Models[m].Decode(rangeRangeDecoder);
            return m - ((uint)1 << NumBitLevels);
        }

        public uint ReverseDecode(RangeDecoder rangeRangeDecoder)
        {
            uint m = 1;
            uint symbol = 0;
            for (var bitIndex = 0; bitIndex < NumBitLevels; bitIndex++)
            {
                var bit = Models[m].Decode(rangeRangeDecoder);
                m <<= 1;
                m += bit;
                symbol |= bit << bitIndex;
            }
            return symbol;
        }

        public static uint ReverseDecode(BitDecoder[] Models, uint startIndex,
            RangeDecoder rangeRangeDecoder, int NumBitLevels)
        {
            uint m = 1;
            uint symbol = 0;
            for (var bitIndex = 0; bitIndex < NumBitLevels; bitIndex++)
            {
                var bit = Models[startIndex + m].Decode(rangeRangeDecoder);
                m <<= 1;
                m += bit;
                symbol |= bit << bitIndex;
            }
            return symbol;
        }
    }
}