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
            Assert.Equal(id.ToString(), p1.PersonId.ToString());
            Assert.NotEqual(firstName, p1.LastName);
            Assert.NotEqual(lastName, p1.FirstName);
        } 
        [Fact]
        public void Test_People_PropertyType()
        {              //Arrange
        int id = 123;
        string firstName = "Ramya";
        string lastName = " Srinivs";

        //Act
        Person p1 = new Person(firstName, lastName, id);

            //Assert
            Assert.IsType<string>(p1.FirstName);
            Assert.IsType<string>(p1.LastName);
            Assert.IsType<int>(p1.PersonId);
        }
        [Fact]
        public void Test_Bad_People()
        {
            //Arrange
            int id = 1;
            int id1 = 2;
            string firstName = null;
            string lastName = null;
            string firstName1 = " ";
            string lastName1 = " ";

            Assert.Throws<ArgumentException>(() => new Person(firstName, lastName, id));
            Assert.Throws<ArgumentException>(() => new Person(firstName1, lastName1, id1));
        }
    }
}
