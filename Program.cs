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
        MailService mailService = new MailService(); //subscriber
        videoEncoder.VideoEncoded += mailService.OnVideoEncoded;

        videoEncoder.Encode(video);
    }
}

public class MailService
{
    public string Mail { get; set; } = "MailService: Sending an email...";
    public void OnVideoEncoded(object source, EventArgs e)
    {
        Console.WriteLine(Mail);
    }
}