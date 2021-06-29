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
            id = TodoSequencer.NextTodoId();

            //Assert
            Assert.Equal(expected, id);
        }
        
        [Fact]
        public void TodoIdResetWorks()
        {
            //Arrange
            int tmp = TodoSequencer.NextTodoId();
            int tmp2 = TodoSequencer.NextTodoId();
            int expected = 1;

            //Act
            TodoSequencer.Reset();
            int result = TodoSequencer.NextTodoId();

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
