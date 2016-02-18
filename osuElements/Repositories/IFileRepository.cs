namespace osuElements.Repositories
{
    public interface IFileRepository<in T> where T : class
    {
        void ReadFile(string file, T t);
        void WriteFile(string file, T t);
        string WriteToString(T t);
    }
}
