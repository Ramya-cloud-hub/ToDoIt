using System;
using Xunit;
using ToDo.Data;
using ToDo.Model;

namespace ToDo.Tests
{
    public class TodoItemsTests
    {
        /// <summary>
        /// Also tests if FindAll works because otherwise it cannot know if the array is empty
        /// Creates an array and gives it null just as a benchmark
        /// </summary>
        [Fact]
        public void TodoArray_Start_As_Empty()
        {
            //Assign
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

        /// <summary>
        /// Because the array in todoItems is static we check if the size we got back with todoItems.Size
        /// is minimum of size 2 and max int.MaxValue to see if the todoItems.Size method works
        /// </summary>
        public void Size_Of_TodoArray()
        {
            //Assign
            int id1 = 14;
            int id2 = 15;
            string discription1 = "Flute";
            string discription2 = "Hamburger";

            TodoItems todoList = new TodoItems();
            todoList.CreateNewTodo(id1, discription1);
            todoList.CreateNewTodo(id2, discription2);

            int lowSize = 2;
            int highSize = int.MaxValue;

            //Act
            int size = todoList.Size();

            //Assert
            Assert.InRange(size, lowSize, highSize);
        }

        /*
        [Fact]
        public void CreateNewTodoTest()
        {
            //Assign
            int id1 = 1;
            string discription1 = "GG";
            int id2 = 3;
            string discription2 = "Hello";
            int low = 2;
            int high = int.MaxValue;

            TodoItems todoList = new TodoItems();
            Todo[] todoArray;

            //Act
            todoList.CreateNewTodo(id1, discription1);
            todoList.CreateNewTodo(id2, discription2);
            todoArray = todoList.FindAll();

            //Assert
            //Because todoArray in TodoItems are static, it will keep the Todo objects
            //created in other test methods so we just check if its length is
            //between 2 and int max value to know if anything got created in it.
            Assert.InRange(todoArray.Length, low, high);
        }
        */

        /// <summary>
        /// Test both FindById method and CreateNewTodo method
        /// </summary>
        [Fact]
        public void FindById_FoundRight()
        {
            //Assign
            int id1 = 8;
            int id2 = 9;
            string discription1 = "RR";
            string discription2 = "HH";

            TodoItems todoList = new TodoItems();
            todoList.CreateNewTodo(id1, discription1);
            todoList.CreateNewTodo(id2, discription2);

            Todo expectedTodo = new Todo(id1, discription1);
            Todo todo;

            //Act
            todo = todoList.FindById(id1);

            //Assert
            Assert.Equal(expectedTodo.TodoID, todo.TodoID);
            Assert.Equal(expectedTodo.Description, todo.Description);
        }

        [Fact]
        public void FindById_DidntExist()
        {
            //Assign
            int id1 = 11;
            int id2 = 99;
            string discription = "GGGGGG";

            TodoItems todoList = new TodoItems();
            todoList.CreateNewTodo(id1, discription);

            Todo expectedTodo = new Todo(id1, discription);
            Todo todo;

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
            //Assign
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
