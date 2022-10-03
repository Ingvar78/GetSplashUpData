namespace GetSplashUpData.Core.Interfaces
{
    public interface IFindService
    {
        List<string> GetByPurchases(string PurchaseNum);
    }

}