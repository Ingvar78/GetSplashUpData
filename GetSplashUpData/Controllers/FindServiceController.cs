using GetSplashUpData.Core.Interfaces;
using GetSplashUpData.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GetSplashUpData.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetContract : ControllerBase
    {
        //private readonly ILogger _logger;
        private readonly IFindService _ifindservice;
        private readonly ILogger<GetContract> _logger;

        public GetContract(IFindService ifindservice, ILogger<GetContract> logger)
        {
            _ifindservice = ifindservice;
            _logger = logger;
        }


        [HttpGet("[action]")]

        public List<String> GetByNum(string Purchase)
        {
            _logger.LogInformation($"Запросили по номеру GetByNum {Purchase}");
            try
            {
                var result = _ifindservice.GetByPurchases(Purchase);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message + $" ErrorNumber: #({Purchase})# ");
                var result = new List<string> { };
                return result;

            }
        }
    }
}
