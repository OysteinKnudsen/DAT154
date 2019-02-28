using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class TextService
    {
        public void OnVideoEncoded(Object o, EventArgs e)
        {
            Console.WriteLine("Text service notified of video encoding, sending text message");
        }
    }
}
