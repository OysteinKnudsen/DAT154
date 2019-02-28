using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class MailService
    {

        //EventHandler
        public void OnVideoEncoded(Object o, EventArgs e)
        {
            Console.WriteLine("Mail service notified about video encoding, sending mail");
        }
    }
}
