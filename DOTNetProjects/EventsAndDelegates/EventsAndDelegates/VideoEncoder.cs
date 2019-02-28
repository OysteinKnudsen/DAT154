using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class VideoEncoder
    {
        // 1. Define delegate 
        // 2. Define event 
        // 3. Fire event 


        public delegate void VideoEncodedEventHandler(Object soruce, VideoEventArgs eventArgs);
        public event VideoEncodedEventHandler VideoEncodedEvent;

        public VideoEncoder() { }

        public void EncodeVideo(Video video)
        {
            Console.WriteLine("Encoding video : " + video.Title);
            Thread.Sleep(3000);
            OnVideoEncoded(video); //Fires the event which notifies subscribers
            Console.ReadKey();
        }

        public void OnVideoEncoded(Video video)
        {
            VideoEncodedEvent?.Invoke(this, new VideoEventArgs() { Video = video });
        }

    }
}
