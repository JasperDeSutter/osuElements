using System;
using Microsoft.Practices.Unity;
using osuElements.Api.Repositories;
using osuElements.Replays;
using osuElements.Repositories;
using osuElements.Skins;
using osuElements.Storyboards;
using UserInfoViewer.Data;

namespace osuElements
{
    public static class osuElements
    {
        private static IUnityContainer Container { get; } = new UnityContainer();

        static osuElements() {
            InitializeApiRepositories<ApiBeatmapRepository, UserRepository, ApiReplayRepository, MultiplayerRepository>();
        }

        public static void InitializeFileRepositories<TBeatmapRepository, TStoryboardRepository, TReplayRepository, TSkinRepository>()
            where TBeatmapRepository : IFileRepository<Beatmap>
            where TStoryboardRepository : IFileRepository<Storyboard>
            where TReplayRepository : IFileRepository<Replay>
            where TSkinRepository : IFileRepository<Skin> {
            Container.RegisterType<IFileRepository<Beatmap>, TBeatmapRepository>();
            Container.RegisterType<IFileRepository<Storyboard>, TStoryboardRepository>();
            Container.RegisterType<IFileRepository<Replay>, TReplayRepository>();
            Container.RegisterType<IFileRepository<Skin>, TSkinRepository>();
        }
        public static void InitializeApiRepositories<TBeatmapRepository, TUserRepository, TReplayRepository, TMultiplayerRepository>()
            where TBeatmapRepository : IApiBeatmapRepository
            where TUserRepository : IUserRepository
            where TReplayRepository : IApiReplayRepository
            where TMultiplayerRepository : IMultiplayerRepository {
            Container.RegisterType<IApiBeatmapRepository, TBeatmapRepository>();
            Container.RegisterType<IUserRepository, TUserRepository>();
            Container.RegisterType<IApiReplayRepository, TReplayRepository>();
            Container.RegisterType<IMultiplayerRepository, TMultiplayerRepository>();
        }

    }
}