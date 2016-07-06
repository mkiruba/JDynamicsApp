using JDynamicsApp.Models;
using JDynamicsApp.Service;
using System.Collections.Generic;
using System.Web.Http;

namespace JDynamicsApp.Controllers
{
    //[Authorize]
    public class CalculationController : ApiController
    {
        private readonly ICalculationService _calculationService;
        public CalculationController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }
        // GET api/values
        public IEnumerable<CalculationModel> Get()
        {            
            return _calculationService.GetResults();
        }

        // POST api/values
        public void Post([FromBody]CalculationModel model)
        {
            _calculationService.Calculate(model);
        }                
    }
}
