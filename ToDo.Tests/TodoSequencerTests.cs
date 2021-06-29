using System;
using Xunit;
using ToDo.Data;

namespace ToDo.Tests
{
    public class TodoSequencerTests
    {
        [Fact]
        public void TodoIdWorks()
        {
            //Arrange
            int id = 0;
            int expected = 1;

            //Act
            id = TodoSequencer.nextTodoId();

            //Assert
            Assert.Equal(expected, id);
        }
        
        [Fact]
        public void TodoIdResetWorks()
        {
            //Arrange
            int tmp = TodoSequencer.nextTodoId();
            int tmp2 = TodoSequencer.nextTodoId();
            int expected = 1;

            //Act
            TodoSequencer.reset();
            int result = TodoSequencer.nextTodoId();

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
