using System;
using Xunit;
using ToDo.Data;
using ToDo.Model;

namespace ToDo.Tests
{
    public class PeopleTests
    {
        [Fact]
        public void Test_Size_Of_PersonArray()
        {
            //Assign
            int id1 = 1;
            string firstName = "Saranya";
            string lastName = "Devva";
            int id2 = 2;
            string firstName2 = "Mamatha";
            string lastName2 = "Koplu";

            People people = new People();
            people.CreatNewPerson(firstName, lastName, id1);
            people.CreatNewPerson(firstName2, lastName2, id2);

            int expectedSize = 2;
            int highSize = int.MaxValue;

            //Act
            int size = people.Size();

            //Assert
            Assert.InRange(size, expectedSize, highSize);
        }
        [Fact]
        public void Check_Empty_Person_Array_Test()
        {
            //Assert
            People peopleList = new People();
            Person[] personArray;
            Person[] nullArray = null;

            //Act
            personArray = peopleList.FindAll();

            //Assert
            Assert.Empty(personArray);
            Assert.NotNull(personArray);
            Assert.Null(nullArray);
        }
        [Fact]
        public void FindById_DidntExist()
            {
                //Arrange
            int id1 = 100;
            int id2 = 200;
            string firstName = "sowmya";
            string lastname = "Kalegowda";

            Person person;
            People people = new People();

            people.Clear();
            people.CreatNewPerson(firstName, lastname, id1);

             //Act
            person = people.FindById(id2);

             //Assert
            Assert.Null(person);          
        }
    }
}
