namespace DelegatesAndEvents
{
    internal class VideoEncoder
    {
        //1. Define the delegate
        //2. Define an event based on that delegate
        //3. Raise the event

        public delegate void VideoEncodedEventHandler(object source, EventArgs eventArgs);
        public event VideoEncodedEventHandler VideoEncoded;
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding videooo...");
            Thread.Sleep(3000);

            OnVideoEncoded();
        }

        protected virtual void OnVideoEncoded()
        {
            if (VideoEncoded != null)
                VideoEncoded(this, EventArgs.Empty);
        }
    }
}
