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
        public void Test_Constructor_Bad_Person_Null()
        {
            //Arrange
            int id = 1;
            string firstName = null;
            string lastName = null;

            Assert.Throws<ArgumentException>(() => new Person(firstName, lastName, id));            
        }
        [Fact]
        public void Test_Constructor_Bad_Person_WhiteSpace()
        {
            //Arrange
            int id1 = 2;
            string firstName1 = " ";
            string lastName1 = " ";

            Assert.Throws<ArgumentException>(() => new Person(firstName1, lastName1, id1));
        }
        [Fact]
        public void Test_Constructor_Bad_Person_Empty()
        {
            //Arrange
            int id1 = 2;
            string firstName1 = "";
            string lastName1 = "";

            Assert.Throws<ArgumentException>(() => new Person(firstName1, lastName1, id1));
        }
        [Fact]
        public void Test_Bad_Person_Property_Null()
        {
            int id = 1;
           string firstName = "Ramya";
            string lastName = "Gowda";
            Person p = new Person(firstName, lastName, id);
            string firstName1 = null;
            string secondName1 = null;

           Assert.Throws<ArgumentException>(() => p.FirstName=firstName1);
           Assert.Throws<ArgumentException>(() => p.LastName =secondName1);       
        }
        [Fact]
        public void Test_Bad_Person_Property_WhiteSpace()
        {
            int id = 1;
            string firstName = "Ramya";
            string lastName = "Gowda";
            Person p = new Person(firstName, lastName, id);
            string firstName1 = " ";
            string secondName1 = " ";

            Assert.Throws<ArgumentException>(() => p.FirstName = firstName1);
            Assert.Throws<ArgumentException>(() => p.LastName = secondName1);
        }
        [Fact]
        public void Test_Bad_Person_Property_Empty()
        {
            int id = 1;
            string firstName = "Ramya";
            string lastName = "Gowda";
            Person p = new Person(firstName, lastName, id);
            string firstName1 = "";
            string secondName1 = "";

            Assert.Throws<ArgumentException>(() => p.FirstName = firstName1);
            Assert.Throws<ArgumentException>(() => p.LastName = secondName1);
        }
    }
}
