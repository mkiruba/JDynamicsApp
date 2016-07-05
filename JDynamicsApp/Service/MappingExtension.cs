using AutoMapper;
using JDynamicsApp.Data.Models;
using JDynamicsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JDynamicsApp.Service
{
    public static class MappingExtension
    {
        public static CalculationModel ToModel(this CalculationResult entity)
        {
            return Mapper.Map<CalculationResult, CalculationModel>(entity);
        }

        public static CalculationResult ToEntity(this CalculationModel data)
        {
            return Mapper.Map<CalculationModel, CalculationResult>(data);
        }

        public static OperationModel ToModel(this Operation entity)
        {
            return Mapper.Map<Operation, OperationModel>(entity);
        }

        public static Operation ToEntity(this OperationModel data)
        {
            return Mapper.Map<OperationModel, Operation>(data);
        }
    }
}