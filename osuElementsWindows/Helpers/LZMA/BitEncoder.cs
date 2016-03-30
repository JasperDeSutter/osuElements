namespace osuElements.Helpers.LZMA
{
    internal struct BitEncoder
	{
		public const int kNumBitModelTotalBits = 11;
		public const uint kBitModelTotal = 1 << kNumBitModelTotalBits;
	    private const int kNumMoveBits = 5;
	    private const int kNumMoveReducingBits = 2;
		public const int kNumBitPriceShiftBits = 6;

	    private uint Prob;

		public void Init() { Prob = kBitModelTotal >> 1; }

		public void UpdateModel(uint symbol)
		{
			if (symbol == 0)
				Prob += (kBitModelTotal - Prob) >> kNumMoveBits;
			else
				Prob -= Prob >> kNumMoveBits;
		}

		public void Encode(RangeCoder rangeCoder, uint symbol)
		{
			// encoder.EncodeBit(Prob, kNumBitModelTotalBits, symbol);
			// UpdateModel(symbol);
			var newBound = (rangeCoder.Range >> kNumBitModelTotalBits) * Prob;
			if (symbol == 0)
			{
				rangeCoder.Range = newBound;
				Prob += (kBitModelTotal - Prob) >> kNumMoveBits;
			}
			else
			{
				rangeCoder.Low += newBound;
				rangeCoder.Range -= newBound;
				Prob -= Prob >> kNumMoveBits;
			}
			if (rangeCoder.Range < RangeCoder.kTopValue)
			{
				rangeCoder.Range <<= 8;
				rangeCoder.ShiftLow();
			}
		}

		private static readonly uint[] ProbPrices = new uint[kBitModelTotal >> kNumMoveReducingBits];

		static BitEncoder()
		{
			const int kNumBits = kNumBitModelTotalBits - kNumMoveReducingBits;
			for (var i = kNumBits - 1; i >= 0; i--)
			{
				var start = (uint)1 << (kNumBits - i - 1);
				var end = (uint)1 << (kNumBits - i);
				for (var j = start; j < end; j++)
					ProbPrices[j] = ((uint)i << kNumBitPriceShiftBits) +
						(((end - j) << kNumBitPriceShiftBits) >> (kNumBits - i - 1));
			}
		}

		public uint GetPrice(uint symbol)
		{
			return ProbPrices[(((Prob - symbol) ^ -(int)symbol) & (kBitModelTotal - 1)) >> kNumMoveReducingBits];
		}
	  public uint GetPrice0() { return ProbPrices[Prob >> kNumMoveReducingBits]; }
		public uint GetPrice1() { return ProbPrices[(kBitModelTotal - Prob) >> kNumMoveReducingBits]; }
	}
}
