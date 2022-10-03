namespace GetSplashUpData.Core.Interfaces
{
    internal interface IDbManager
    {
        void InitDb();
    }
    internal interface IGovDbManager : IDbManager
    {
        IGovDbContext GetContext();
    }
}
