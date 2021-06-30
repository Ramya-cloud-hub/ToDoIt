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
            int expected = 1;

            TodoSequencer.Reset();
            
            //Act
            int id = TodoSequencer.NextTodoId();
            int id2 = TodoSequencer.NextTodoId();

            //Assert
            Assert.Equal(expected, id);
            Assert.NotEqual(id, id2);
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
