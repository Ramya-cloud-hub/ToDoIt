using System;
using Xunit;
using ToDo.Data;
using ToDo.Model;

namespace ToDo.Tests
{
    public class TodoItemsTests
    {
        /*
        [Fact]
        public void TodoArray_Start_As_Empty()
        {
            //Arrange
            TodoItems todoList = new TodoItems();
            Todo[] todoArray;
            Todo[] nullArray = null;

            //Act
            todoArray = todoList.FindAll();

            //Assert
            Assert.Empty(todoArray);
            Assert.NotNull(todoArray);
            Assert.Null(nullArray);
        }
        */

        [Fact]
        public void Size_Of_TodoArray()
        {
            //Arrange
            int expectedSize = 2;
            int id1 = 14;
            int id2 = 15;
            string discription1 = "Flute";
            string discription2 = "Hamburger";

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo(id1, discription1);
            todoList.CreateNewTodo(id2, discription2);

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
            todoList.CreateNewTodo(20, "Test");

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
            todoList.CreateNewTodo(id, discription);

            //Assert
            Assert.Contains(id.ToString(), todoList.FindAll()[0].TodoID.ToString());
            Assert.Contains(discription, todoList.FindAll()[0].Description);
        }
        
        [Fact]
        public void FindById_FoundRight()
        {
            //Arrange
            int id1 = 8;
            int id2 = 9;
            string discription1 = "RR";
            string discription2 = "HH";

            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo(id1, discription1);
            todoList.CreateNewTodo(id2, discription2);

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
            int id1 = 11;
            int id2 = 99;
            string discription = "GGGGGG";

            Todo todo;
            TodoItems todoList = new TodoItems();

            todoList.Clear();
            todoList.CreateNewTodo(id1, discription);

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
            int id1 = 5;
            int id2 = 6;
            int id3 = 7;
            string discription1 = "LL";
            string discription2 = "JJ";
            string discription3 = "KK";

            TodoItems todoList = new TodoItems();

            todoList.CreateNewTodo(id1, discription1);
            todoList.CreateNewTodo(id2, discription2);
            todoList.CreateNewTodo(id3, discription3);
            int expectedArrayLegnth = 0;

            //Act
            todoList.Clear();

            //Assert
            Assert.Equal(expectedArrayLegnth, todoList.FindAll().Length);
            Assert.Empty(todoList.FindAll());
            Assert.NotNull(todoList.FindAll());
        }
    }
}
