using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video("SHARK ATTACK!");
            var videoEncoder = new VideoEncoder();
            var mailService = new MailService();
            var textService = new TextService();
            videoEncoder.VideoEncodedEvent += mailService.OnVideoEncoded;
            videoEncoder.VideoEncodedEvent += textService.OnVideoEncoded;
            videoEncoder.EncodeVideo(video);
        }
    }
}
