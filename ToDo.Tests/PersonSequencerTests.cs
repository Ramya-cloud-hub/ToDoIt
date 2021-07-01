using Xunit;
using System;
using ToDo.Data;
using ToDo.Tests;

namespace ToDo.Tests
{
  public class PersonSequencerTests
    {
        [Fact]
        public void Check_Person_Id_Increment_Work()
        {
            //Arrange
            int expected = PersonSequencer.PersonId;

            //Act
            int actual = PersonSequencer.NextPersonId();

            //Assert
            Assert.True(expected < actual);
        }
        [Fact]
        public void Check_Person_Id_Reset_Work()
        {
            //Actual
            PersonSequencer.NextPersonId();
            int expected = PersonSequencer.NextPersonId();
            int expectedId = 1;

            //Act
            PersonSequencer.Reset();
            int  actual= PersonSequencer.NextPersonId();

            //Assert
            Assert.Equal(expectedId, actual);
            Assert.True(actual < expected);
        }
    }
}
