namespace osuElements.Helpers.LZMA
{
    internal struct BitDecoder
    {
        public const int kNumBitModelTotalBits = 11;
        public const uint kBitModelTotal = 1 << kNumBitModelTotalBits;
        private const int kNumMoveBits = 5;

        private uint Prob;

        public void UpdateModel(int numMoveBits, uint symbol)
        {
            if (symbol == 0)
                Prob += (kBitModelTotal - Prob) >> numMoveBits;
            else
                Prob -= Prob >> numMoveBits;
        }

        public void Init() { Prob = kBitModelTotal >> 1; }

        public uint Decode(RangeDecoder rangeRangeDecoder)
        {
            var newBound = (rangeRangeDecoder.Range >> kNumBitModelTotalBits) * Prob;
            if (rangeRangeDecoder.Code < newBound)
            {
                rangeRangeDecoder.Range = newBound;
                Prob += (kBitModelTotal - Prob) >> kNumMoveBits;
                if (rangeRangeDecoder.Range < RangeDecoder.kTopValue)
                {
                    rangeRangeDecoder.Code = (rangeRangeDecoder.Code << 8) | (byte)rangeRangeDecoder.Stream.ReadByte();
                    rangeRangeDecoder.Range <<= 8;
                }
                return 0;
            }
            rangeRangeDecoder.Range -= newBound;
            rangeRangeDecoder.Code -= newBound;
            Prob -= Prob >> kNumMoveBits;
            if (rangeRangeDecoder.Range < RangeDecoder.kTopValue)
            {
                rangeRangeDecoder.Code = (rangeRangeDecoder.Code << 8) | (byte)rangeRangeDecoder.Stream.ReadByte();
                rangeRangeDecoder.Range <<= 8;
            }
            return 1;
        }
    }
}