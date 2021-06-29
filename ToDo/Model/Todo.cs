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
        bool done;
        Person assignee;

        public int TodoID { get { return todoId; } }
        public string Description { get { return description; } }
        public bool Done 
        { 
            get { return done; } 
            set
            {
                done = value;
            }
        }
        public Person Assignee 
        { 
            get { return assignee;  }
            set
            {
                assignee = value;
            }
        }

        public Todo (int toDoId, string description)
	    {
            todoId = toDoId;
            this.description = description;
        }
    }
}
