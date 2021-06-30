using System;
using Xunit;
using ToDo.Data;

namespace ToDo.Tests
{
    public class TodoSequencerTests
    {
        [Fact]
        public void IdIncrementWorks()
        {
            //Arrange

            //Act
            int before = TodoSequencer.TodoId;
            int result = TodoSequencer.NextTodoId();

            //Assert
            Assert.True(before < result);
        }

        [Fact]
        public void IdResetWorks()
        {
            //Arrange
            TodoSequencer.NextTodoId();
            int before = TodoSequencer.NextTodoId();
            int expectedId = 1;

            //Act
            TodoSequencer.Reset();
            int result = TodoSequencer.NextTodoId();

            //Assert
            Assert.Equal(expectedId, result);
            Assert.True(result < before);
        }
    }
}
