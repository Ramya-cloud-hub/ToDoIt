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
            string firstName = "Saranya";
            string lastName = "Devva";

            string firstName2 = "Mamatha";
            string lastName2 = "Koplu";

            People people = new People();
            people.CreatNewPerson(firstName, lastName);
            people.CreatNewPerson(firstName2, lastName2);

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
            int id2 = 200;
            string firstName = "sowmya";
            string lastname = "Kalegowda";

            Person person;
            People people = new People();

            people.Clear();
            people.CreatNewPerson(firstName, lastname);

            //Act
            person = people.FindById(id2);

            //Assert
            Assert.Null(person);
        }
        [Fact]
        public void FindAll_Test()
        {
            //Arrange
            int expectedSize = 1;

            People peopleList = new People();
            Person[] personArray = null;

            peopleList.Clear();
            peopleList.CreatNewPerson("abc", "xyz");

            //Act
            personArray = peopleList.FindAll();

            //Assert
            Assert.NotNull(personArray);
            Assert.NotEmpty(personArray);
            Assert.Equal(expectedSize, personArray.Length);
        }
        /// <summary>
        /// Testing The Clear fuction to test the PersonArray is empty and also it should not null
        /// </summary>
        [Fact]
        public void Test_Clear_People()
        {
            //Arrange
            string firstName1 = "Srini";
            string lastName1 = "Vasu";
            string firstName2 = "Srini";
            string lastName2 = "Vasu";
            string firstName3 = "Srini";
            string lastName3 = "Vasu";
            int expectedLegnth = 0;

            People people = new People();
            people.CreatNewPerson(firstName1, lastName1);
            people.CreatNewPerson(firstName2, lastName2);
            people.CreatNewPerson(firstName3, lastName3);

            //Act
            people.Clear();
            people.Clear();


            //Assert
            Assert.Equal(expectedLegnth, people.FindAll().Length);
            Assert.Empty(people.FindAll());
            Assert.NotNull(people.FindAll());
        }
        /// <summary>
        /// Function to Check can we find the person my passing PersonId
        /// </summary>
    
    }
}
