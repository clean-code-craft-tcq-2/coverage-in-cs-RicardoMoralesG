using System;
using System.Collections.Generic;
using TypewiseAlert.Alerts;
using TypewiseAlert.Interfaces;
using TypewiseAlert.Models;

namespace TypewiseAlert
{
  public class TypewiseAlert
  {

        public enum BreachType
        {
            NORMAL,
            TOO_LOW,
            TOO_HIGH
        };

        static Dictionary<CoolingType, TempLimits> listOptions = new Dictionary<CoolingType, TempLimits>{

            {CoolingType.PASSIVE_COOLING,new TempLimits{MIN= 0,MAX=35 } },

            {CoolingType.HI_ACTIVE_COOLING,new TempLimits{MIN= 0,MAX=45 } },

            {CoolingType.MED_ACTIVE_COOLING,new TempLimits{MIN= 0,MAX=40 } },

        };

        public static BreachType InferBreach(double value, double lowerLimit, double upperLimit)
        {

            if (value < lowerLimit)
            {
                return BreachType.TOO_LOW;
            }

            if (value > upperLimit)
            {
                return BreachType.TOO_HIGH;
            }

            return BreachType.NORMAL;

        }

        public enum CoolingType
        {
            PASSIVE_COOLING,
            HI_ACTIVE_COOLING,
            MED_ACTIVE_COOLING
        };

        public static BreachType ClassifyTemperatureBreach(
            CoolingType coolType, double tempInC)
        {

            int Limitup = listOptions[coolType].MIN;
            int Limitlow = listOptions[coolType].MAX;

            return InferBreach(tempInC, Limitup, Limitlow);

        }
        public enum AlertTarget
        {
            TO_CONTROLLER,
            TO_EMAIL
        };

        public struct BatteryCharacter
        {
            public CoolingType Type;
            public string brand;
        }

        static Dictionary<AlertTarget, ISenderAlert> target = new Dictionary<AlertTarget, ISenderAlert>{

            {AlertTarget.TO_CONTROLLER, new SenderController () },
            {AlertTarget.TO_EMAIL, new SenderEmail() },

        };



        public static bool Alert(  AlertTarget Target, BatteryCharacter battery, double tempInC)
        {

            BreachType breach = ClassifyTemperatureBreach(battery.Type, tempInC);

            Alerter alert = new Alerter();

            alert.SetTarget(target[Target]);

            alert.SetBreachType(breach);

            alert.SendTo();

            return alert.sendTo;


        }



    }
}
