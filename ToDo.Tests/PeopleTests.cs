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
        public void FindById_FoundRight()
        {
            //Arrange
            int id1 = 1;
            string firstName1 = "abc";
            string lastName1 = "xyz";
            string firstName2 = "ABC";
            string lastName2 = "XYZ";

            People peopleList = new People();

            peopleList.Clear();
            peopleList.CreatNewPerson(firstName1, lastName1);
            peopleList.CreatNewPerson(firstName2, lastName2);

            Person person;

            //Act
            person = peopleList.FindById(id1);

            //Assert
            Assert.Contains(id1.ToString(), person.PersonId.ToString());
            Assert.Contains(firstName1, person.FirstName);
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
        [Fact]
        public void CreateNewPerson_Test()
        {
            //Arrange
            int id = 1;
            string firstName = "abc";
            string lastName = "xyz";

            People peopleList = new People();

            peopleList.Clear();

            //Act
            peopleList.CreatNewPerson(firstName,lastName);

            //Assert
            Assert.Contains(id.ToString(), peopleList.FindAll()[0].PersonId.ToString());
            Assert.Contains(firstName, peopleList.FindAll()[0].FirstName);
            Assert.Contains(lastName, peopleList.FindAll()[0].LastName);
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
       
        [Fact]
        public void RemovePerson_Removed()
        {
            //Arrange
            People peopleList = new People();

            peopleList.Clear();
            peopleList.CreatNewPerson("ABC", "abc");
            peopleList.CreatNewPerson("XYZ", "xyz");
            peopleList.CreatNewPerson("PQR", "pqr");
           

            //Act
            bool isRemoved = peopleList.RemoveObject_FromPersonArray(1);

            //Assert
            Assert.True(isRemoved);
        }
        [Fact]
        public void RemovePerson_DidntFind()
        {
            //Arrange
            People peopleList = new People();

            peopleList.Clear();
            peopleList.CreatNewPerson("ABC", "abc");
            peopleList.CreatNewPerson("XYZ", "xyz");
            peopleList.CreatNewPerson("PQR", "pqr");

            //Act
            bool isFound = peopleList.RemoveObject_FromPersonArray(5);

            //Assert
            Assert.False(isFound);
        }

    }
}
