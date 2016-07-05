using AutoMapper;
using JDynamicsApp.Data.Models;
using JDynamicsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JDynamicsApp.App_Start
{
    public static class Automapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CalculationModel, CalculationResult>();
                cfg.CreateMap<CalculationResult, CalculationModel>();
                cfg.CreateMap<Operation, OperationModel>();
                cfg.CreateMap<OperationModel, Operation>();
            });
        }        
    }
}