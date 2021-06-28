using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model
{
    public class Todo
    {
        readonly int todoId;
        string description;
        Person assignee;

        public int TodoID { get { return todoId; } }
        public string Description { get { return description; } }
        public Person Assignee { get { return assignee;  } }

        public Todo (int toDoId, string description)
	    {
            this.description = description;
            todoId = toDoId;
            assignee = new Person();
        }
    }
}
