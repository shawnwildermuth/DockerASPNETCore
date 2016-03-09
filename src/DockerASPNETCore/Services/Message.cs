using System;

namespace DockerASPNETCore
{
  public class Message
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string Author { get; set; }
    public DateTime MessageDate { get; set; } = DateTime.UtcNow;
  }
}