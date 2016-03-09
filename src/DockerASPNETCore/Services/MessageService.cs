using System;
using System.Collections.Generic;

namespace DockerASPNETCore.Services
{
  public class MessageService
  {
    public List<Message> Messages { get; } = new List<Message>()
    {
      new Message() { Id = 1, Title = "First Message", Body = "This is a message", Author = "Shawn Wildermuth" }
    };
  }
}
