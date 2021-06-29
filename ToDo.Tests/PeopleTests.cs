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
        /// <summary>
        /// Testing The Clear fuction to test the PersonArray is empty and also it should not null
        /// </summary>
        [Fact]
        public void Test_Clear_People()
        {
            //Arrange
            int id1 = 123;
            int id2 = 456;
            int id3 = 789;
            string firstName1 = "Srini";
            string lastName1 = "Vasu";
            string firstName2 = "Srini";
            string lastName2= "Vasu";
            string firstName3 = "Srini";
            string lastName3 = "Vasu";
            int expectedLegnth = 0;

            People people = new People();
            people.CreatNewPerson(firstName1, lastName1, id1);
            people.CreatNewPerson(firstName2, lastName2, id2);
            people.CreatNewPerson(firstName3, lastName3, id3);

            //Act
            people.Clear();
            people.Clear();
            

            //Assert
            Assert.Equal(expectedLegnth ,people.FindAll().Length);
            Assert.Empty(people.FindAll());
            Assert.NotNull(people.FindAll());
        }
        /// <summary>
        /// Function to Check can we find the person my passing PersonId
        /// </summary>
        [Fact]
        public void Find_PersonById_FoundRight()
        {
            //Arrange
            int id1 = 123;
            int id2 = 456;
            string firstName = "Srinivasa";
            string LastName = "Chakravarthy";
            string firstName2 = "Shruthi";
            string LastName2 = "Sogi";

            People people = new People();

            people.Clear();
            people.CreatNewPerson(firstName, LastName,id1);
            people.CreatNewPerson(firstName2,LastName2,id2);

            Person person;

            //Act
            person = people.FindById(id1);

            //Assert
            Assert.Contains(id1.ToString(), person.PersonId.ToString());
        }
        }
}
