using System;
using Xunit;
using ToDo.Data;
using ToDo.Model;

namespace ToDo.Tests
{
    public class TodoItemsTests
    {
        [Fact]
        public void Size_Of_TodoArray()
        {
            //Arrange
            int expectedSize = 2;
            string discription1 = "Flute";
            string discription2 = "Hamburger";

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo(discription1);
            todoList.CreateNewTodo(discription2);

            //Act
            int size = todoList.Size();

            //Assert
            Assert.Equal(expectedSize, size);
        }

        [Fact]
        public void FindAll_Test()
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
        public void CreateNewTodo_Test()
        {
            //Arrange
            int id = 1;
            string discription = "GG";

            TodoItems todoList = new TodoItems();

            todoList.Clear();

            //Act
            todoList.CreateNewTodo(discription);

            //Assert
            Assert.Contains(id.ToString(), todoList.FindAll()[0].TodoID.ToString());
            Assert.Contains(discription, todoList.FindAll()[0].Description);
        }
        
        [Fact]
        public void FindById_FoundRight()
        {
            //Arrange
            int id1 = 1;
            string discription1 = "RR";
            string discription2 = "HH";

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo(discription1);
            todoList.CreateNewTodo(discription2);

            Todo todo;

            //Act
            todo = todoList.FindById(id1);

            //Assert
            Assert.Contains(id1.ToString(), todo.TodoID.ToString());
            Assert.Contains(discription1, todo.Description);
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
            string discription1 = "LL";
            string discription2 = "JJ";
            string discription3 = "KK";

            TodoItems todoList = new TodoItems();

            todoList.CreateNewTodo(discription1);
            todoList.CreateNewTodo(discription2);
            todoList.CreateNewTodo(discription3);
            int expectedArrayLegnth = 0;
            int todoSeqeuencerExpectedId = 1;

            //Act
            todoList.Clear();

            //Assert
            Assert.Equal(expectedArrayLegnth, todoList.FindAll().Length);
            Assert.Empty(todoList.FindAll());
            Assert.NotNull(todoList.FindAll());
            Assert.Equal(todoSeqeuencerExpectedId, TodoSequencer.NextTodoId());
        }




        [Fact]
        public void FindByDoneStatus_Found_True()
        {
            //Arrange
            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("A");
            todoList.CreateNewTodo("B");
            todoList.CreateNewTodo("C");
            todoList.CreateNewTodo("D");

            todoList.FindById(1).Done = true;
            todoList.FindById(2).Done = false;
            todoList.FindById(3).Done = true;
            todoList.FindById(4).Done = false;

            //Act
            Todo[] list = todoList.FindByDoneStatus(true);

            //Assert
            Assert.True(list[0].Done);
            Assert.True(list[1].Done);
        }
        [Fact]
        public void FindByDoneStatus_Found_False()
        {
            //Arrange
            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("A");
            todoList.CreateNewTodo("B");
            todoList.CreateNewTodo("C");
            todoList.CreateNewTodo("D");

            todoList.FindById(1).Done = true;
            todoList.FindById(2).Done = true;
            todoList.FindById(3).Done = false;
            todoList.FindById(4).Done = false;

            //Act
            Todo[] list = todoList.FindByDoneStatus(false);


            //Assert
            Assert.False(list[0].Done);
            Assert.False(list[1].Done);
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



        
        [Fact]
        public void FindByAssignee_PersonId_Found()
        {
            //Arrange
            Person p1 = new Person("Martin", "Berg", 1);
            Person p2 = new Person("Gunilla", "Hillberh", 2);
            Person p3 = new Person("Kilj", "Neverg", 1);

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("A");
            todoList.CreateNewTodo("B");
            todoList.CreateNewTodo("C");

            todoList.FindById(1).Assignee = p1;
            todoList.FindById(2).Assignee = p2;
            todoList.FindById(3).Assignee = p3;

            //Act
            Todo[] list = todoList.FindByAssignee(1);

            //Assert
            Assert.Equal(1, list[0].Assignee.PersonId);
            Assert.Equal(1, list[1].Assignee.PersonId);
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


        
        [Fact]
        public void FindByAssignee_Assignee_Found()
        {
            //Arrange
            Person p1 = new Person("Amilia", "Karlsson", 1);
            Person p2 = new Person("Pär", "Rykman", 2);

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("A");
            todoList.CreateNewTodo("B");
            todoList.CreateNewTodo("C");

            todoList.FindById(1).Assignee = p1;
            todoList.FindById(2).Assignee = p2;
            todoList.FindById(3).Assignee = p1;

            //Act
            Todo[] list = todoList.FindByAssignee(p1);

            //Assert
            Assert.Equal(p1, list[0].Assignee);
            Assert.Equal(p1, list[1].Assignee);
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
        



        [Fact]
        public void FindUnassignedTodoItems_Found()
        {
            //Arrange
            Person p1 = new Person("A", "B", 1);
            int expectedUnassingedTodoId1 = 2;
            int expectedUnassingedTodoId2 = 3;

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("A");
            todoList.CreateNewTodo("B");
            todoList.CreateNewTodo("C");

            todoList.FindById(1).Assignee = p1;

            //Act
            Todo[] list = todoList.FindUnassignedTodoItems();


            //Assert
            Assert.Equal(expectedUnassingedTodoId1, list[0].TodoID);
            Assert.Equal(expectedUnassingedTodoId2, list[1].TodoID);
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


        [Fact]
        public void RemoveTodo_Removed()
        {
            //Arrange
            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("A");
            todoList.CreateNewTodo("B");
            todoList.CreateNewTodo("C");
            todoList.CreateNewTodo("D");

            //Act
            bool done = todoList.RemoveTodo(2);

            //Assert
            Assert.True(done);
        }
        [Fact]
        public void RemoveTodo_DidntFind()
        {
            //Arrange
            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo("A");
            todoList.CreateNewTodo("B");
            todoList.CreateNewTodo("C");
            todoList.CreateNewTodo("D");

            //Act
            bool done = todoList.RemoveTodo(9);

            //Assert
            Assert.False(done);
        }
    }
}
