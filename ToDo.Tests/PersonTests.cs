using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Tests;                        
using ToDo.Model;
using Xunit;

namespace ToDo.Tests
{
  public class PersonTests
    {
        [Fact]
        public void Person_Name_Test()
        {
            //Arrange
            string firstName = "Ramya";
            string lastName = "Gowda";

            //Act
            Person p1 = new Person(firstName, lastName);

            //Assert
            Assert.Contains(firstName, p1.FirstName);
            Assert.Contains(lastName, p1.LastName);
            Assert.Equal(firstName, p1.FirstName);
            Assert.Equal(lastName, p1.LastName);    
        }        
    }
}
