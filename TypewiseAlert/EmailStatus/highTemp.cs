using System;
using System.Collections.Generic;
using System.Text;
using TypewiseAlert.Interfaces;

namespace TypewiseAlert.EmailStatus
{
    public class highTemp : ISenderEmail
    {
        public bool SenderEmail(string result)
        {
            try
            {
                Console.WriteLine("To: {0}\n", result);
                Console.WriteLine("Temperature is too high\n");

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("cannot be sent email: {0}", ex.Message);

                return false;
            }
        }
    }
}
