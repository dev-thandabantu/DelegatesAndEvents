using DelegatesAndEvents;

internal class Program
{
    private static void Main(string[] args)
    {
        var video = new Video()
        {
            Title = "Video 1"
        };
        var videoEncoder = new VideoEncoder(); //publisher
        MailService mailService = new MailService(); //subscriber1
        videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
        MessageService messageService = new MessageService(); //subscriber2
        videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

        videoEncoder.Encode(video);
    }
}

public class MailService
{
    public string Mail { get; set; } = "MailService: Sending an email...";
    public void OnVideoEncoded(object source, VideoEventArgs e)
    {
        Console.WriteLine(Mail + e.Video.Title);
    }
}

public class MessageService
{
    public void OnVideoEncoded(object source, VideoEventArgs e)
    {
        Console.WriteLine("MessageService: Sending a text message..." + e.Video.Title);
    }
}