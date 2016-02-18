namespace osuElementsWindows
{
    public static class osuElementsWindows
    {
         public static void Init() {
             osuElements.osuElements.InitializeFileRepositories<OsuFileRepository,StoryboardFileRepository,ReplayFileRepository,SkinFileRepository>();
         }
    }
}