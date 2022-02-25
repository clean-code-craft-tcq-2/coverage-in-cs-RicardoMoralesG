using System;
using System.Collections.Generic;
using System.Text;
using TypewiseAlert.EmailStatus;
using TypewiseAlert.Interfaces;
using TypewiseAlert.Models;
using static TypewiseAlert.TypewiseAlert;

namespace TypewiseAlert.Alerts
{
  
    public class SenderEmail : ISenderAlert
    {
        static Dictionary<BreachType, ISenderEmail> breachAlerters = new Dictionary<BreachType, ISenderEmail>{

            {BreachType.TOO_LOW, new lowTemp() },
            {BreachType.TOO_HIGH, new highTemp() },
            {BreachType.NORMAL, new normalTemp() },

        };

        public bool SendTo(BreachType breach)
        {
            string recepient = "a.b@c.com";

            Email _email = new Email();

            _email.SetAlerter(breachAlerters[breach]);

            _email.Setcontent(recepient);
            _email.EmailSend();

            return _email.SendTo;

        }

      
    }
}
