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
            people.Clear();
            people.CreatNewPerson(firstName, lastName);
            people.CreatNewPerson(firstName2, lastName2);

            int expectedSize = 2;
            int highSize = int.MaxValue;

            //Act
            int size = people.Size();

            //Assert
            Assert.InRange(size, expectedSize, highSize);
            Assert.Equal(expectedSize, size);
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
            int id2 = 2;
            string firstName1 = "abc";
            string lastName1 = "xyz";
            string firstName2 = "ABC";
            string lastName2 = "XYZ";

            People peopleList = new People();

          peopleList.Clear();
          Person person1  = peopleList.CreatNewPerson(firstName1, lastName1);
          Person person2 = peopleList.CreatNewPerson(firstName2, lastName2);


            //Act
            Person p1 = peopleList.FindById(id1);
            Person p2 = peopleList.FindById(id2);

            //Assert
            Assert.Equal(person1, p1);
            Assert.Equal(person2, p2);
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
            string firstName = "abc";
            string lastName = "xyz";
            string firstName1 = "shilpa";
            string lastName1 = "Sunik";

            People peopleList = new People();
            peopleList.Clear();

            //Act
            Person person1 = peopleList.CreatNewPerson(firstName, lastName);
            Person person2 = peopleList.CreatNewPerson(firstName1, lastName1);
            Person[] lists = peopleList.FindAll();

            //Assert
            Assert.NotEqual(person1.PersonId, person2.PersonId);
            Assert.Contains(firstName, person1.FirstName);
            Assert.Contains(firstName1, person2.FirstName);
            Assert.Contains(person1,lists);
            Assert.Contains(person2, lists);
            Assert.NotEqual(person1.PersonId, person2.PersonId);
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
            int personSeqeuencerExpectedId = 0;
            //Act
            people.Clear();
            Person[] peopleList = people.FindAll();

            //Assert
            Assert.Equal(personSeqeuencerExpectedId, PersonSequencer.PersonId);
            Assert.Empty(peopleList);
            Assert.NotNull(peopleList);
            Assert.Equal(expectedLegnth,peopleList.Length);
            people.Clear();     
        }

        /// <summary>
        /// Here I am testing Remove function, weather the person is removed and when i remove he should not exits inside my database
        /// </summary>
       
        [Fact]
        public void RemovePerson_Removed()
        {
            //Arrange
            People peopleList = new People();

            peopleList.Clear();
            Person person1 =   peopleList.CreatNewPerson("ABC", "abc");
            Person person2 = peopleList.CreatNewPerson("XYZ", "xyz");
            Person person3 = peopleList.CreatNewPerson("PQR", "pqr");
            int lengthOfList = 2;
           

            //Act
            bool isRemoved = peopleList.RemoveObject_FromPersonArray(1);
            Person[] lists = peopleList.FindAll();

            //Assert
            Assert.True(isRemoved);
            Assert.DoesNotContain(person1, lists); 
            Assert.Equal(lengthOfList, lists.Length);
            Assert.Contains(person2, lists);
            Assert.Contains(person3, lists);
        }
        [Fact]
        public void RemovePerson_DidntFind()
        {
            //Arrange
            People peopleList = new People();
            int peopleLength = 3;

            peopleList.Clear();
            Person people1 =  peopleList.CreatNewPerson("ABC", "abc");
            Person people2 = peopleList.CreatNewPerson("XYZ", "xyz");
            Person people3 = peopleList.CreatNewPerson("PQR", "pqr");

            //Act
            Person[] lists = peopleList.FindAll();
            bool isFound = peopleList.RemoveObject_FromPersonArray(5);

            //Assert
            Assert.False(isFound);
            Assert.Contains(people1, lists);
            Assert.Contains(people2, lists);
            Assert.Contains(people3, lists);
            Assert.Equal(peopleLength, lists.Length);
        }

    }
}
