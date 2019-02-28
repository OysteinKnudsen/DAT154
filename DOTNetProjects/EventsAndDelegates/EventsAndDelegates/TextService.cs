using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class TextService
    {
        public void OnVideoEncoded(Object o, VideoEventArgs videoEventArgs)
        {
            Console.WriteLine($"Text service notified of video encoding of {videoEventArgs.Video.Title} sending text message");
        }
    }
}
