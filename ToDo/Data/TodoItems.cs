using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model;

namespace ToDo.Data
{
    public class TodoItems
    {
        static Todo[] todoArray = Array.Empty<Todo>();

        public int Size()
        {
            return todoArray.Length;
        }

        public Todo[] FindAll()
        {
            return todoArray;
        }

        public Todo FindById(int todoId)
        {
            Todo foundTheTodo = null;

            //Easiest to use foreach on an array when searching for specific item in it
            //It breaks after finding the right one to stop looking through the rest
            foreach (Todo todo in todoArray)
            {
                if(todo.TodoID == todoId)
                {
                    foundTheTodo = todo;
                    break;
                }
            }

            return foundTheTodo;
        }

        public Todo CreateNewTodo(string description)
        {
            Todo newTodo = new Todo(TodoSequencer.NextTodoId(), description);

            Array.Resize(ref todoArray, todoArray.Length + 1);
            todoArray[todoArray.Length - 1] = newTodo;

            return newTodo;
        }
        public void Clear()
        {
            //Array got a clear method. Instead of going through all the hassel of doing it ourselfs
            //The array keeps its size but every index ís null so we use Arrays resize to go back to the starting size of 0
            Array.Clear(todoArray, 0, todoArray.Length);
            Array.Resize(ref todoArray, 0);
            TodoSequencer.Reset();
        }

        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] todoWithDoneStatus = new Todo[todoArray.Length];
            int counter = 0;

            foreach (Todo todo in todoArray)
            {
                if(todo.Done == doneStatus)
                {
                    todoWithDoneStatus[counter] = todo;
                    counter++;
                }
            }
            Array.Resize(ref todoWithDoneStatus, counter);

            return todoWithDoneStatus;
        }

        public Todo[] FindByAssignee(int personId)
        {
            Todo[] todosWithSameAssignee = new Todo[todoArray.Length];
            int counter = 0;

            foreach (Todo todo in todoArray)
            {
                //First check if Assignee is null because otherwise if we do todo.Assignee.PersonId on null it will crash
                if (todo.Assignee != null && todo.Assignee.PersonId == personId)
                {
                    todosWithSameAssignee[counter] = todo;
                    counter++;
                }
            }
            Array.Resize(ref todosWithSameAssignee, counter);

            return todosWithSameAssignee;
        }

        public Todo[] FindByAssignee(Person assignee)
        {
            Todo[] todosWithSameAssignee = null;

            if (assignee != null)
            {
                todosWithSameAssignee = FindByAssignee(assignee.PersonId);
            }

            return todosWithSameAssignee;
        }
        
        public Todo[] FindUnassignedTodoItems()
        {
            Todo[] todosWithSameAssignee = new Todo[todoArray.Length];
            int counter = 0;

            foreach (Todo todo in todoArray)
            {
                if (todo.Assignee == null)
                {
                    todosWithSameAssignee[counter] = todo;
                    counter++;
                }
            }
            Array.Resize(ref todosWithSameAssignee, counter);

            return todosWithSameAssignee;
        }

        public bool RemoveTodo(int todoId)
        {
            bool done = false;
            Todo specificTodo = FindById(todoId);

            if(!(specificTodo == null))
            {
                Todo[] tmpArray = new Todo[todoArray.Length];
                int tmpArrayCounter = 0;

                for (int i = 0; i < todoArray.Length; i++)
                {
                    if (todoArray[i] != specificTodo)
                    {
                        tmpArray[tmpArrayCounter] = todoArray[i];
                        tmpArrayCounter++;
                    }
                }
                todoArray = tmpArray;
                Array.Resize(ref todoArray, todoArray.Length - 1);
                done = true;
            }
            return done;
        }
    }
}
