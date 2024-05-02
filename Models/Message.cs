namespace NewsPaperAPI.Models
{
    public class Message
    {
        public int? UserId { get; set; } = null;
        public string Msg { get; set; } = "";
        public bool Response { get; set; }
    }
}
