using System;
using Xunit;
using ToDo.Data;

namespace ToDo.Tests
{
    public class TodoSequencerTests
    {
        [Fact]
        public void TodoIdIncrementWorks()
        {
            //Arrange
            int expected = 1;

            TodoSequencer.Reset();
            
            //Act
            int id = TodoSequencer.NextTodoId();
            int id2 = TodoSequencer.NextTodoId();

            //Assert
            Assert.Equal(expected, id);
            Assert.True(id < id2);
        }


        [Fact]
        public void TodoIdResetWorks()
        {
            //Arrange
            int id1 = TodoSequencer.NextTodoId();
            int id2 = TodoSequencer.NextTodoId();
            int expectedId = 1;

            //Act
            TodoSequencer.Reset();
            int result = TodoSequencer.NextTodoId();

            //Assert
            Assert.Equal(expectedId, result);
            Assert.Equal(id1, result);
        }
    }
}
