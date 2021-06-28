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
        public int PersonId { get { return personId; } }

        public string FullName { get { return firstName + ' ' + lastName; } }

        public Person(string firstName, string lastName, int personId)
        {
            this.personId = personId;
            this.firstName = firstName;
            this. lastName = lastName;
            bool isEmptyOrNullFirstName = string.IsNullOrEmpty(firstName);
            bool isEmptyOrNullLastName = string.IsNullOrEmpty(lastName);

            if (isEmptyOrNullFirstName || isEmptyOrNullLastName || personId == 0)
             {
                throw new ArgumentNullException(nameof(personId));
                throw new ArgumentNullException(nameof(firstName));
                throw new ArgumentNullException(nameof(lastName));
            }
        }
        

    }
}
