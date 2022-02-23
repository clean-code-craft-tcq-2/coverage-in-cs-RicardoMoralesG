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

        }

        [Fact]
        public void TestAlertController()
        {
            Alerter _alert = new Alerter();

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
        public void InfersBreachAsPerLimits()
        {
            Assert.True(TypewiseAlert.InferBreach(25, 20, 30) == TypewiseAlert.BreachType.NORMAL);
            Assert.True(TypewiseAlert.InferBreach(10, 20, 30) == TypewiseAlert.BreachType.TOO_LOW);
            Assert.True(TypewiseAlert.InferBreach(31, 20, 30) == TypewiseAlert.BreachType.TOO_HIGH);
           
        }

       
      
    }
}
