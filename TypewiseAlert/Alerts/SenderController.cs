using System;
using System.Collections.Generic;
using System.Text;
using TypewiseAlert.Interfaces;
using static TypewiseAlert.TypewiseAlert;

namespace TypewiseAlert.Alerts
{
    public class SenderController : ISenderAlert
    {
    

        public bool SendTo(BreachType breach)
        {
            try
            {
                const ushort To = 0xfeed;

                Console.WriteLine("{0} : {1}\n", To, breach);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot be sent: {0}", ex.Message);

                return false;
            }

        }

    }
}
