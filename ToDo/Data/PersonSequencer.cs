using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model;

namespace ToDo.Data
{
   public class PersonSequencer
    {
        static int personId;

        public static int NextPersonId()
        { 
            return ++personId;
        }
        public static void Reset()
        {
            personId = 0;
        }
    }
}
