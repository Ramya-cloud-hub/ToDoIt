using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model
{
   public class Person
    {
        readonly int personId;
        string firstName;
        string lastName;

        public string FirstName {
            get
            {
                return firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Empty or only White space is not allowed");
                }
                firstName = value;
            }
                
          }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Empty or only White space is not allowed");
                }
                lastName = value;
            }
        }

        public string FullName { get { return firstName + ' ' + lastName; } }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

    }
}
