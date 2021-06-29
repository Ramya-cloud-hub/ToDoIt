using System;
using Xunit;
using ToDo.Model;

namespace ToDo.Tests
{
    public class TodoTests
    {
        [Fact]
        public void Create_A_Todo_Object()
        {
            //Assign
            int todoId = 1;
            string description = "Create project";
            bool done = false;

            //Act
            Todo toDoObject = new Todo(todoId, description);

            //Assert
            Assert.Contains(todoId.ToString(), toDoObject.TodoID.ToString());
            Assert.Contains(description.ToString(), toDoObject.Description.ToString());
            Assert.Equal(done, toDoObject.Done);
            Assert.Null(toDoObject.Assignee);
        }
    }
}
