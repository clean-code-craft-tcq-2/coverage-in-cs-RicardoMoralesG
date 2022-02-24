using System;
using TypewiseAlert.Alerts;
using TypewiseAlert.Models;
using Xunit;
using static TypewiseAlert.TypewiseAlert;

namespace TypewiseAlert.Test
{
  public class TypewiseAlertTest
  {
        [Fact]
        public void InfersBreachAsPerLimits()
        {
            Assert.True(TypewiseAlert.InferBreach(12, new Limits { minLimit = 20, maxLimit = 30 }) == BreachType.TOO_LOW);
        }

       


    }
}
