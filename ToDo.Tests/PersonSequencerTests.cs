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
            //Actual
            int personId = 0;
            int expected = 1;

            //Act
            personId = TodoSequencer.NextTodoId();

            //Assert
            Assert.Equal(expected, personId);
        }
        [Fact]
        public void Check_Person_Id_Reset_Work()
        {
            int personId1= PersonSequencer.NextPersonId();
            int personId2 = PersonSequencer.NextPersonId();
            int expected = 1;

            PersonSequencer.Reset();
           int  personId3= PersonSequencer.NextPersonId();

            Assert.Equal(expected, personId3);
        }
    }
}
