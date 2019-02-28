using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class MailService
    {
        public void OnVideoEncoded(Object o, EventArgs e)
        {
            Console.WriteLine("Mail service received notification about video encoding \n will send mail");
        }
    }
}
