using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model;

namespace ToDo.Data
{
    public class TodoSequencer
    {
        static int todoId;

        public static int nextTodoId()
        {
            return ++todoId;
        }

        public static void reset()
        {
            todoId = 0;
        }
    }
}
