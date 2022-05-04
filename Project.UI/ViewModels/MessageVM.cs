using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.ViewModels
{
    public class MessageVM
    {
        public List<Message> Messages { get; set; }
        public Message Message { get; set; }
    }
}