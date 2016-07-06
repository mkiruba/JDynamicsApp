using AutoMapper;
using JDynamicsApp.Data.Models;
using JDynamicsApp.Models;

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