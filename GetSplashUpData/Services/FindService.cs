using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GetSplashUpData.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GetSplashUpData.Core.Services
{
    internal class FindService : IFindService
    {
        private readonly IGovDbManager _dbM;

        public FindService (IGovDbManager dbM)
        {
            _dbM = dbM;
        }

        #region GetByNumber
        List<string> IFindService.GetByPurchases(string PurchaseNum)
        {

            var tt = string.Format("%{0}%", PurchaseNum);

            using (var dbContext = _dbM.GetContext())
                return dbContext.Notifications.AsNoTracking()
                  .Where(x=>EF.Functions.ILike(x.Purchase_num, string.Format("%{0}%", PurchaseNum))).Select(c=>c.Purchase_num).ToList();

        }

        #endregion GetByNumber
    }
}