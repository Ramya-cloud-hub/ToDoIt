using System;   
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
            int id = 123;
            string firstName = "Ramya";
            string lastName = "Gowda";

            //Act
            Person p1 = new Person(firstName, lastName, id);

            //Assert
            Assert.Contains(id.ToString(), p1.PersonId.ToString());
            Assert.Contains(firstName, p1.FirstName);
            Assert.Contains(lastName, p1.LastName);
            Assert.Equal(firstName, p1.FirstName);
            Assert.Equal(lastName, p1.LastName); 
            
            
        }        
    }
}
