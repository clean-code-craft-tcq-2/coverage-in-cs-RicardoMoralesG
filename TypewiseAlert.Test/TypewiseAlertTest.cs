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
        public void TestEmail()
        {
            Alerter _alert = new Alerter();

            _alert.SetTarget(new SenderEmail());


            // Test email  NORMAL
            _alert.SetBreachType(BreachType.NORMAL);

            _alert.SendTo();

            // Test email  TOO_LOW
            _alert.SetBreachType(BreachType.TOO_LOW);

            _alert.SendTo();


            // Test email TOO_HIGH
            _alert.SetBreachType(BreachType.TOO_HIGH);

            _alert.SendTo();

            Assert.True(_alert.sendTo == true);


            // Controller Sender
            _alert.SetTarget(new SenderController());

            // Test email  NORMAL
            _alert.SetBreachType(BreachType.NORMAL);

            _alert.SendTo();


            // Test email  TOO_LOW
            _alert.SetBreachType(BreachType.TOO_LOW);

            _alert.SendTo();


            // Test email TOO_HIGH
            _alert.SetBreachType(BreachType.TOO_HIGH);

            _alert.SendTo();

            Assert.True(_alert.sendTo == true);

        }


        [Fact]
        public void InfersPerCoolingType()
        {
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, -1) == TypewiseAlert.BreachType.TOO_LOW);
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 36) == TypewiseAlert.BreachType.TOO_HIGH);
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 24) == TypewiseAlert.BreachType.NORMAL);

            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, -1) == TypewiseAlert.BreachType.TOO_LOW);
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, 56) == TypewiseAlert.BreachType.TOO_HIGH);
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, 24) == TypewiseAlert.BreachType.NORMAL);

            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING,  -1) == TypewiseAlert.BreachType.TOO_LOW);
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING, 41) == TypewiseAlert.BreachType.TOO_HIGH);
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING, 24) == TypewiseAlert.BreachType.NORMAL);
        }


        [Fact]
        public void InfersBreachAsPerLimits()
        {
            Assert.True(TypewiseAlert.InferBreach(25, 20, 30) == TypewiseAlert.BreachType.NORMAL);
            Assert.True(TypewiseAlert.InferBreach(10, 20, 30) == TypewiseAlert.BreachType.TOO_LOW);
            Assert.True(TypewiseAlert.InferBreach(31, 20, 30) == TypewiseAlert.BreachType.TOO_HIGH);
           
        }

       
      
    }
}
