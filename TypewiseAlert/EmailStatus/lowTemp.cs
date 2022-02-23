using System;
using System.Collections.Generic;
using System.Text;
using TypewiseAlert.Interfaces;

namespace TypewiseAlert.EmailStatus
{
    public class lowTemp : ISenderEmail
    {
        public bool SenderEmail(string result)
        {
            try
            {
                Console.WriteLine("To: {0}\n", result);
                Console.WriteLine("Temperature is too low\n");

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
