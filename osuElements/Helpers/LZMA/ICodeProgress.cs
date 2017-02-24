namespace osuElements.Helpers.LZMA
{
    internal interface ICodeProgress
    {
        /// <summary>
        /// Callback progress.
        /// </summary>
        /// <param name="inSize">
        /// input size. -1 if unknown.
        /// </param>
        /// <param name="outSize">
        /// output size. -1 if unknown.
        /// </param>
        void SetProgress(long inSize, long outSize);
    }
}