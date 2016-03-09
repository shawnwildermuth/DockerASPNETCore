using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerASPNETCore.Services;
using Microsoft.AspNet.Mvc;

namespace DockerASPNETCore.Controllers
{
  [Route("api/[controller]")]
  public class MessagesController : Controller
  {
    private MessageService _messages;

    public MessagesController(MessageService messages)
    {
      _messages = messages;
    }

    [HttpGet]
    public IEnumerable<Message> Get()
    {
      return _messages.Messages;
    }

    [HttpGet("{id}")]
    public Message Get(int id)
    {
      return _messages.Messages.Where(m => m.Id == id).FirstOrDefault();
    }

    [HttpPost]
    public IActionResult Post([FromBody]Message value)
    {
      value.Id = _messages.Messages.Max(m => m.Id) + 1;
      _messages.Messages.Add(value);

      return Created($"/messages/{value.Id}", value);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      if (_messages.Messages.Any(m => m.Id == id))
      {
        _messages.Messages.RemoveAll(m => m.Id == id);
        return Ok();
      }

      return HttpBadRequest();
    }
  }
}
