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
        static Todo[] todoArray = new Todo[0];

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

        public Todo CreateNewTodo(int toDoId, string description)
        {
            Todo newTodo = new Todo(toDoId, description);

            //To expand the current array, we need to save everything in it first
            //Then we can create a new bigger array and copy over all the old Todo's
            //Then add the new Todo
            Todo[] tmpArray = todoArray;
            todoArray = new Todo[tmpArray.Length+1];
            tmpArray.CopyTo(todoArray, 0);
            todoArray[todoArray.Length - 1] = newTodo;

            return newTodo;
        }

        public void Clear()
        {
            //Array got a clear method. Instead of going through all the hassel of doing it ourselfs
            //The array keeps its size but every index ís null so we use Arrays resize to go back to the starting size of 0
            Array.Clear(todoArray, 0, todoArray.Length);
            Array.Resize(ref todoArray, 0);
        }
    }
}
