using System;
using System.Collections.Generic;
using System.Text;
using TypewiseAlert.Interfaces;

namespace TypewiseAlert.Models
{
    public class Email
    {
        public ISenderEmail _emailSender;

        public string _content;

        public bool SendTo = false;

        public void SetAlerter(ISenderEmail breachAlerter)
        {
            _emailSender = breachAlerter;

        }

        public void Setcontent(string content)
        {
            _content = content;
        }

        public void EmailSend()
        {
            SendTo = _emailSender.SenderEmail(_content);
        }
    }
}
