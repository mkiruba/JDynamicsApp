using JDynamicsApp.Models;
using JDynamicsApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JDynamicsApp.Controllers
{
    public class OperationController : ApiController
    {
        private readonly ICalculationService _calculationService;
        public OperationController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }
        public IEnumerable<OperationModel> Get()
        {           
            return _calculationService.GetOperations();
        }
    }
}
