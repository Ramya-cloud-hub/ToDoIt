using System;
using Xunit;
using ToDo.Model;

namespace ToDo.Tests
{
    public class TodoTests
    {
        [Fact]
        public void CreateATodoObject()
        {
            //Assign
            int todoId = 1;
            string description = "Create project";
            Person person = new Person();

            //Act
            Todo ToDoObject = new Todo(todoId, description);

            //Assert
            Assert.Contains(todoId.ToString(), ToDoObject.TodoID.ToString());
            Assert.Contains(description.ToString(), ToDoObject.Description.ToString());
        }
    }
}
