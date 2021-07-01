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
            TodoItems todoList = new TodoItems();
            Todo expectedToExist = todoList.CreateNewTodo("Test");

            //Act
            Todo[]  todoArray = todoList.FindAll();

            //Assert
            Assert.NotNull(todoArray);
            Assert.NotEmpty(todoArray);
            Assert.Contains(expectedToExist, todoArray);
        }

        [Fact]
        public void CreateNewTodoWorks()
        {
            //Arrange
            string expectedDiscription1 = "Create base class";
            string expectedDiscription2 = "Create sub class";

            TodoItems todoList = new TodoItems();

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
            string discription1 = "Set more objects";
            string discription2 = "Get more trains";
            string discription3 = "Create new class";

            TodoItems todoList = new TodoItems();

            Todo expectedTodo1 = todoList.CreateNewTodo(discription1);
                                 todoList.CreateNewTodo(discription2);
            Todo expectedTodo2 = todoList.CreateNewTodo(discription3);

            //Act
            Todo todo1 = todoList.FindById(expectedTodo1.TodoID);
            Todo todo2 = todoList.FindById(expectedTodo2.TodoID);

            //Assert
            Assert.Equal(expectedTodo1, todo1);
            Assert.Equal(expectedTodo2, todo2);
        }

        [Fact]
        public void FindById_DidntExist()
        {
            //Arrange
            int id2 = 9999;
            string discription = "GGGGGG";

            Todo todo;
            TodoItems todoList = new TodoItems();

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
            Todo task2 = todoList.CreateNewTodo("Set B");
            Todo task3 = todoList.CreateNewTodo("Set C");
            Todo task4 = todoList.CreateNewTodo("Set D");

            todoList.FindById(task1.TodoID).Done = true;
            todoList.FindById(task2.TodoID).Done = false;
            todoList.FindById(task3.TodoID).Done = true;
            todoList.FindById(task4.TodoID).Done = false;

            //Act
            Todo[] list = todoList.FindByDoneStatus(true);

            //Assert
            for (int i = 0; i < list.Length; i++)
            {
                Assert.True(list[i].Done);
            }
            Assert.Contains(task1, list);
            Assert.Contains(task3, list);
        }
        [Fact]
        public void FindByDoneStatus_Found_False()
        {
            //Arrange
            TodoItems todoList = new TodoItems();

            todoList.Clear();
            Todo task1 = todoList.CreateNewTodo("Mull A");
            Todo task2 = todoList.CreateNewTodo("Mull B");
            Todo task3 = todoList.CreateNewTodo("Mull C");
            Todo task4 = todoList.CreateNewTodo("Mull D");

            todoList.FindById(task1.TodoID).Done = true;
            todoList.FindById(task2.TodoID).Done = true;
            todoList.FindById(task3.TodoID).Done = false;
            todoList.FindById(task4.TodoID).Done = false;

            //Act
            Todo[] list = todoList.FindByDoneStatus(false);

            //Assert
            for (int i = 0; i < list.Length; i++)
            {
                Assert.False(list[i].Done);
            }
            Assert.Contains(task3, list);
            Assert.Contains(task4, list);
        }

        [Fact]
        public void FindByDoneStatus_NotFound_True()
        {
            //Arrange
            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("Mhb");
            todoList.CreateNewTodo("Mhc");

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
            todoList.CreateNewTodo("Abc");
            todoList.CreateNewTodo("Bcd");

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
            Person expectedAssignee = new Person("Martin", "Berg", 1);
            Person p2 = new Person("Gunilla", "Hillberh", 2);

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            Todo task1 = todoList.CreateNewTodo("Get A");
            Todo task2 = todoList.CreateNewTodo("Get B");
            Todo task3 = todoList.CreateNewTodo("Get C");

            todoList.FindById(task1.TodoID).Assignee = expectedAssignee;
            todoList.FindById(task2.TodoID).Assignee = p2;
            todoList.FindById(task3.TodoID).Assignee = expectedAssignee;

            int expectedLength = 2;

            //Act
            Todo[] list = todoList.FindByAssignee(1);

            //Assert
            Assert.Equal(expectedLength, list.Length);

            Assert.Equal(expectedAssignee.PersonId, list[0].Assignee.PersonId);
            Assert.Equal(expectedAssignee, list[0].Assignee);

            Assert.Equal(expectedAssignee.PersonId, list[1].Assignee.PersonId);
            Assert.Equal(expectedAssignee, list[1].Assignee);
        }

        [Fact]
        public void FindByAssignee_PersonId_WithNullAssigneeInStaticArray()
        {
            //Arrange
            int expectedLength = 1;
            Person expectedAssignee = new Person("Emil", "Berg", 1);

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("Collect A");
            Todo task2 = todoList.CreateNewTodo("Collect AB");

            todoList.FindById(task2.TodoID).Assignee = expectedAssignee;

            //Act
            Todo[] list = todoList.FindByAssignee(expectedAssignee.PersonId);

            //Assert
            Assert.Equal(expectedLength, list.Length);

            Assert.Equal(expectedAssignee.PersonId, list[0].Assignee.PersonId);
            Assert.Equal(expectedAssignee, list[0].Assignee);
        }

        [Fact]
        public void FindByAssignee_PersonId_NotFound()
        {
            //Arrange
            Person p1 = new Person("Anna", "Börg", 1);
            Person p2 = new Person("Gunnar", "Hamn", 2);

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("bAc");
            todoList.CreateNewTodo("cBa");

            todoList.FindById(1).Assignee = p1;
            todoList.FindById(2).Assignee = p2;

            //Act
            Todo[] list = todoList.FindByAssignee(89);

            //Assert
            Assert.Empty(list);
        }


        ////////////////////////////FindByAssignee(Assignee) test methods
        [Fact]
        public void FindByAssignee_Assignee_Found()
        {
            //Arrange
            Person p1 = new Person("Amilia", "Karlsson", 1);
            Person expectedPerson = new Person("Pär", "Rykman", 99);

            TodoItems todoList = new TodoItems();

            Todo task1 = todoList.CreateNewTodo("mAk");
            Todo task2 = todoList.CreateNewTodo("kBc");
            Todo task3 = todoList.CreateNewTodo("iCo");

            todoList.FindById(task1.TodoID).Assignee = p1;
            todoList.FindById(task2.TodoID).Assignee = expectedPerson;
            todoList.FindById(task3.TodoID).Assignee = expectedPerson;

            int expectedLength = 2;

            //Act
            Todo[] list = todoList.FindByAssignee(expectedPerson);

            //Assert
            Assert.Equal(expectedLength, list.Length);
            Assert.Equal(expectedPerson, list[0].Assignee);
            Assert.Equal(expectedPerson, list[1].Assignee);
        }

        [Fact]
        public void FindByAssignee_Assignee_WithNullAssigneeInStaticArray()
        {
            //Arrange
            Person expectedPerson = new Person("Lily", "Potter", 894);

            TodoItems todoList = new TodoItems();

                         todoList.CreateNewTodo("Vroom");
            Todo task2 = todoList.CreateNewTodo("Zoom");

            todoList.FindById(task2.TodoID).Assignee = expectedPerson;

            int expectedLength = 1;

            //Act
            Todo[] list = todoList.FindByAssignee(expectedPerson);

            //Assert
            Assert.Equal(expectedLength, list.Length);
            Assert.Equal(expectedPerson, list[0].Assignee);
        }

        [Fact]
        public void FindbyAssignee_Assignee_SendInNull()
        {
            //Arrange
            Person nullPerson = null;

            TodoItems todoList = new TodoItems();

            //Act
            Todo[] list = todoList.FindByAssignee(nullPerson);

            //Assert
            Assert.Null(list);
        }

        [Fact]
        public void FindByAssignee_Assignee_NotFound()
        {
            //Arrange
            Person p1 = new Person("Erik", "Merlin", 1);
            Person p2 = new Person("Gört", "Humm", 2);
            Person p4 = new Person("KLI", "HUM", 55);

            TodoItems todoList = new TodoItems();

            Todo task1 = todoList.CreateNewTodo("At");
            Todo task2 = todoList.CreateNewTodo("By");
            Todo task3 = todoList.CreateNewTodo("Car");

            todoList.FindById(task1.TodoID).Assignee = p1;
            todoList.FindById(task2.TodoID).Assignee = p1;
            todoList.FindById(task3.TodoID).Assignee = p2;

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
            todoList.CreateNewTodo("Ayy");
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
            todoList.CreateNewTodo("Yayyy");

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
            TodoItems todoList = new TodoItems();

            Todo todoExpectedToStay1 = todoList.CreateNewTodo("A");
            Todo todoExpectedRemoved = todoList.CreateNewTodo("B");
            Todo todoExpectedToStay2 = todoList.CreateNewTodo("C");
            Todo todoExpectedToStay3 = todoList.CreateNewTodo("D");

            //Act
            int sizeBefore = todoList.Size();
            bool done = todoList.RemoveTodo(todoExpectedRemoved.TodoID);
            Todo[] list = todoList.FindAll();

            //Assert
            Assert.True(done);
            Assert.True(sizeBefore >  list.Length);
            Assert.DoesNotContain(todoExpectedRemoved, list);

            Assert.Contains(todoExpectedToStay1, list);
            Assert.Contains(todoExpectedToStay2, list);
            Assert.Contains(todoExpectedToStay3, list);
        }
        [Fact]
        public void RemoveTodo_DidntFind()
        {
            //Arrange
            TodoItems todoList = new TodoItems();

            todoList.CreateNewTodo("Y");
            todoList.CreateNewTodo("U");
            todoList.CreateNewTodo("O");

            //Act
            Todo[] list = todoList.FindAll();
            bool done = todoList.RemoveTodo(99999);
            Todo[] list2 = todoList.FindAll();

            //Assert
            Assert.False(done);
            Assert.Equal(list, list2);
        }
    }
}
