using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.ViewModels
{
    public class ToDoVM
    {
        public List<ToDo> ToDos { get; set; }
        public ToDo ToDo { get; set; }
    }
}