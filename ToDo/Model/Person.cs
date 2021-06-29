using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model
{
    public class Person
    {
      readonly int personid;
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
        public int PersonId { get { return personid; } }

        public string FullName { get { return firstName + ' ' + lastName; } }

        public Person(string firstName, string lastName, int personId)
        {
            personid = personId;
            this.firstName = firstName;
            this. lastName = lastName;
           
        }
        

    }
}
