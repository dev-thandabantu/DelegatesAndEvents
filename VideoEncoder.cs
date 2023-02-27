namespace DelegatesAndEvents
{
    public class VideoEventArgs
    {
        public Video Video { get; set; }
    }
    internal class VideoEncoder
    {
        //1. Define the delegate
        //2. Define an event based on that delegate
        //3. Raise the event

        public event EventHandler<VideoEventArgs> VideoEncoded;
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding videooo...");
            Thread.Sleep(3000);
            video.Title = "Rambo!";
            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs()
                {
                    Video = video
                });
        }
    }
}
