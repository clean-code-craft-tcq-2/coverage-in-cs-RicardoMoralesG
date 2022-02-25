using System;
using System.Collections.Generic;
using System.Text;
using TypewiseAlert.Interfaces;

namespace TypewiseAlert.EmailStatus
{
    class normalTemp : ISenderEmail
    {
        public bool SenderEmail(string result)
        {
            Console.WriteLine("Temperature is  ok ");

            return true;
        }
    }
}
