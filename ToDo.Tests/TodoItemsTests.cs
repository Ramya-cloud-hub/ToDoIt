using System;
using Xunit;
using ToDo.Data;
using ToDo.Model;

namespace ToDo.Tests
{
    public class TodoItemsTests
    {
        ////////////////////////////////////////////////Step 9 Test Methods
        [Fact]
        public void SizeOfTodoArray()
        {
            //Arrange
            string discription1 = "Flute";
            string discription2 = "Hamburger";

            TodoItems todoList = new TodoItems();

            //Act
            int sizeBefore = todoList.Size();
            todoList.CreateNewTodo(discription1);
            todoList.CreateNewTodo(discription2);
            int sizeAfter = todoList.Size();

            //Assert
            Assert.True(sizeBefore < sizeAfter);
        }

        [Fact]
        public void FindAllWorks()
        {
            //Arrange
            int expectedSize = 1;

            TodoItems todoList = new TodoItems();
            Todo[] todoArray = null;

            todoList.Clear();
            todoList.CreateNewTodo("Test");

            //Act
            todoArray = todoList.FindAll();

            //Assert
            Assert.NotNull(todoArray);
            Assert.NotEmpty(todoArray);
            Assert.Equal(expectedSize, todoArray.Length);
        }

        [Fact]
        public void CreateNewTodoWorks()
        {
            //Arrange
            string expectedDiscription1 = "Create base class";
            string expectedDiscription2 = "Create sub class";

            TodoItems todoList = new TodoItems();

            todoList.Clear();

            //Act
            Todo task1 = todoList.CreateNewTodo(expectedDiscription1);
            Todo task2 = todoList.CreateNewTodo(expectedDiscription2);
            Todo[] todos = todoList.FindAll();

            //Assert
            Assert.Contains(expectedDiscription1, task1.Description);
            Assert.Contains(expectedDiscription2, task2.Description);
            Assert.Contains(task1, todos);
            Assert.Contains(task2, todos);
            Assert.NotEqual(task1.TodoID, task2.TodoID);
        }

            [Fact]
        public void FindById_FoundRight()
        {
            //Arrange
            int id1 = 1;
            int id3 = 3;
            string discription1 = "Set more objects";
            string discription2 = "Get more trains";
            string discription3 = "Create new class";

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            Todo expectedTodo1 = todoList.CreateNewTodo(discription1);
            todoList.CreateNewTodo(discription2);
            Todo expectedTodo3 = todoList.CreateNewTodo(discription3);

            //Act
            Todo todo1 = todoList.FindById(id1);
            Todo todo3 = todoList.FindById(id3);

            //Assert
            Assert.Equal(expectedTodo1, todo1);
            Assert.Equal(expectedTodo3, todo3);
        }

        [Fact]
        public void FindById_DidntExist()
        {
            //Arrange
            int id2 = 99;
            string discription = "GGGGGG";

            Todo todo;
            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo(discription);

            //Act
            todo = todoList.FindById(id2);

            //Assert
            Assert.Null(todo);
        }

        /// <summary>
        /// Tests both empty and notnull to make sure todoArray in todoItems is empty
        /// and not null after TodoItems.Clear method.
        /// </summary>
        [Fact]
        public void ClearTest()
        {
            //Arrange
            string discription1 = "Let loose the ducks";
            string discription2 = "Add more vehicle classes";
            string discription3 = "Get more gold";

            TodoItems todoList = new TodoItems();

            todoList.CreateNewTodo(discription1);
            todoList.CreateNewTodo(discription2);
            todoList.CreateNewTodo(discription3);
            int expectedArrayLegnth = 0;
            int todoSeqeuencerExpectedId = 0;

            //Act
            todoList.Clear();
            Todo[] list = todoList.FindAll();

            //Assert
            Assert.Equal(todoSeqeuencerExpectedId, TodoSequencer.TodoId); //We check so the TodoSequencer is also reseted
            Assert.Equal(expectedArrayLegnth, list.Length);
            Assert.Empty(list);
            Assert.NotNull(list);
            todoList.Clear();
        }



        ////////////////////////////////////////////////Step 10 Test Methods
        ////////////////////////////FindByDoneStatus test methods
        [Fact]
        public void FindByDoneStatus_Found_True()
        {
            //Arrange
            TodoItems todoList = new TodoItems();

            todoList.Clear();
            Todo task1 = todoList.CreateNewTodo("Set A");
            todoList.CreateNewTodo("Set B");
            Todo task3 = todoList.CreateNewTodo("Set C");
            todoList.CreateNewTodo("Set D");

            todoList.FindById(1).Done = true;
            todoList.FindById(2).Done = false;
            todoList.FindById(3).Done = true;
            todoList.FindById(4).Done = false;

            int expectedLength = 2;

            //Act
            Todo[] list = todoList.FindByDoneStatus(true);

            //Assert
            Assert.Equal(expectedLength, list.Length);
            Assert.True(list[0].Done);
            Assert.True(list[1].Done);
            Assert.Contains(task1, list);
            Assert.Contains(task3, list);
        }
        [Fact]
        public void FindByDoneStatus_Found_False()
        {
            //Arrange
            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("A");
            todoList.CreateNewTodo("B");
            Todo task3 = todoList.CreateNewTodo("C");
            Todo task4 = todoList.CreateNewTodo("D");

            todoList.FindById(1).Done = true;
            todoList.FindById(2).Done = true;
            todoList.FindById(3).Done = false;
            todoList.FindById(4).Done = false;

            //Act
            int expectedLength = 2;

            //Act
            Todo[] list = todoList.FindByDoneStatus(false);

            //Assert
            Assert.Equal(expectedLength, list.Length);
            Assert.False(list[0].Done);
            Assert.False(list[1].Done);
            Assert.Contains(task3, list);
            Assert.Contains(task4, list);
        }

        [Fact]
        public void FindByDoneStatus_NotFound_True()
        {
            //Arrange
            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("A");
            todoList.CreateNewTodo("B");

            todoList.FindById(1).Done = false;
            todoList.FindById(2).Done = false;

            //Act
            Todo[] list = todoList.FindByDoneStatus(true);


            //Assert
            Assert.Empty(list);
        }
        [Fact]
        public void FindByDoneStatus_NotFound_False()
        {
            //Arrange
            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("A");
            todoList.CreateNewTodo("B");

            todoList.FindById(1).Done = true;
            todoList.FindById(2).Done = true;

            //Act
            Todo[] list = todoList.FindByDoneStatus(false);


            //Assert
            Assert.Empty(list);
        }


        ////////////////////////////FindByAssignee(PersonId) test methods
        [Fact]
        public void FindByAssignee_PersonId_Found()
        {
            //Arrange
            Person expectedPerson = new Person("Martin", "Berg", 1);
            Person p2 = new Person("Gunilla", "Hillberh", 2);

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("Get A");
            todoList.CreateNewTodo("Get B");
            todoList.CreateNewTodo("Get C");

            todoList.FindById(1).Assignee = expectedPerson;
            todoList.FindById(2).Assignee = p2;
            todoList.FindById(3).Assignee = expectedPerson;

            int expectedLength = 2;

            //Act
            Todo[] list = todoList.FindByAssignee(1);

            //Assert
            Assert.Equal(expectedLength, list.Length);

            Assert.Equal(expectedPerson.PersonId, list[0].Assignee.PersonId);
            Assert.Equal(expectedPerson, list[0].Assignee);

            Assert.Equal(expectedPerson.PersonId, list[1].Assignee.PersonId);
            Assert.Equal(expectedPerson, list[1].Assignee);
        }
       
        [Fact]
        public void FindByAssignee_PersonId_NotFound()
        {
            //Arrange
            Person p1 = new Person("Anna", "Börg", 1);
            Person p2 = new Person("Gunnar", "Hamn", 2);

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("A");
            todoList.CreateNewTodo("B");

            todoList.FindById(1).Assignee = p1;
            todoList.FindById(2).Assignee = p2;

            //Act
            Todo[] list = todoList.FindByAssignee(3);

            //Assert
            Assert.Empty(list);
        }


        ////////////////////////////FindByAssignee(Assignee) test methods
        [Fact]
        public void FindByAssignee_Assignee_Found()
        {
            //Arrange
            Person p1 = new Person("Amilia", "Karlsson", 1);
            Person expectedPerson = new Person("Pär", "Rykman", 2);

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("A");
            todoList.CreateNewTodo("B");
            todoList.CreateNewTodo("C");

            todoList.FindById(1).Assignee = p1;
            todoList.FindById(2).Assignee = expectedPerson;
            todoList.FindById(3).Assignee = expectedPerson;

            int expectedLength = 2;

            //Act
            Todo[] list = todoList.FindByAssignee(expectedPerson);

            //Assert
            Assert.Equal(expectedLength, list.Length);
            Assert.Equal(expectedPerson, list[0].Assignee);
            Assert.Equal(expectedPerson, list[1].Assignee);
        }
        [Fact]
        public void FindByAssignee_Assignee_NotFound()
        {
            //Arrange
            Person p1 = new Person("Erik", "Merlin", 1);
            Person p2 = new Person("Gört", "Humm", 2);
            Person p4 = new Person("KLI", "HUM", 55);

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("A");
            todoList.CreateNewTodo("B");
            todoList.CreateNewTodo("C");

            todoList.FindById(1).Assignee = p1;
            todoList.FindById(2).Assignee = p1;
            todoList.FindById(3).Assignee = p2;

            //Act
            Todo[] list = todoList.FindByAssignee(p4);

            //Assert
            Assert.Empty(list);
        }


        ////////////////////////////FindUnassignedTodoItems test methods
        [Fact]
        public void FindUnassignedTodoItems_Found()
        {
            //Arrange
            Person p1 = new Person("A", "B", 1);
            int expectedLegnth = 2;

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("A");
            Todo exepectedTask1 = todoList.CreateNewTodo("B");
            Todo exepectedTask2 = todoList.CreateNewTodo("C");

            todoList.FindById(1).Assignee = p1;

            //Act
            Todo[] list = todoList.FindUnassignedTodoItems();


            //Assert
            Assert.Equal(expectedLegnth, list.Length);

            Assert.Contains(exepectedTask1, list);
            Assert.Contains(exepectedTask2, list);

            Assert.Null(list[0].Assignee);
            Assert.Null(list[1].Assignee);

            Assert.NotEqual(exepectedTask1, exepectedTask2);
        }
        
        [Fact]
        public void FindUnassignedTodoItems_NotFound()
        {
            //Arrange
            Person p1 = new Person("A", "B", 1);

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("A");

            todoList.FindById(1).Assignee = p1;

            //Act
            Todo[] list = todoList.FindUnassignedTodoItems();


            //Assert
            Assert.Empty(list);
        }


        ////////////////////////////////////////////////Step 11 Test Methods
        ////////////////////////////Remove test methods
        [Fact]
        public void RemoveTodo_Removed()
        {
            //Arrange
            int expectedLength = 3;

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            Todo todoExpectedToStay1 = todoList.CreateNewTodo("A");
            Todo todoExpectedRemoved = todoList.CreateNewTodo("B");
            Todo todoExpectedToStay2 = todoList.CreateNewTodo("C");
            Todo todoExpectedToStay3 = todoList.CreateNewTodo("D");

            //Act
            bool done = todoList.RemoveTodo(2);
            Todo[] list = todoList.FindAll();

            //Assert
            Assert.True(done);
            Assert.Equal(expectedLength, list.Length);
            Assert.DoesNotContain(todoExpectedRemoved, list);

            Assert.Contains(todoExpectedToStay1, list);
            Assert.Contains(todoExpectedToStay2, list);
            Assert.Contains(todoExpectedToStay3, list);
        }
        [Fact]
        public void RemoveTodo_DidntFind()
        {
            //Arrange
            int expectedLength = 4;

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            Todo todoExpectedToStay1 = todoList.CreateNewTodo("A");
            Todo todoExpectedToStay2 = todoList.CreateNewTodo("B");
            Todo todoExpectedToStay3 = todoList.CreateNewTodo("C");
            Todo todoExpectedToStay4 = todoList.CreateNewTodo("D");

            //Act
            bool done = todoList.RemoveTodo(9);
            Todo[] list = todoList.FindAll();

            //Assert
            Assert.False(done);
            Assert.Equal(expectedLength, list.Length);

            Assert.Contains(todoExpectedToStay1, list);
            Assert.Contains(todoExpectedToStay2, list);
            Assert.Contains(todoExpectedToStay3, list);
            Assert.Contains(todoExpectedToStay4, list);
        }
    }
}
