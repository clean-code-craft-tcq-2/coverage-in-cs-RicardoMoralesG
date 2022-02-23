using System;
using System.Collections.Generic;
using System.Text;
using TypewiseAlert.Interfaces;
using static TypewiseAlert.TypewiseAlert;

namespace TypewiseAlert.Models
{
    public class Alerter
    {
        public ISenderAlert _alertSender;

        public BreachType _breachType;

        public bool sendTo = false;

        public void SetTarget(ISenderAlert alert)
        {
            _alertSender = alert;
        }

        public void SetBreachType(BreachType breach)
        {
            _breachType = breach;
        }

        public void SendTo()
        {
            sendTo = this._alertSender.SendTo(_breachType);
        }
    }
}
