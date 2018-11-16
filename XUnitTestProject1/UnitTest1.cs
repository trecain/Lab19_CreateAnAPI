using System;
using Xunit;
using Lab19_CreateAnAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Lab19_CreateAnAPI.Model;
using System.Linq;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        /// <summary>
        /// Create and read Todo in database.
        /// </summary>
        [Fact]
        public async void SaveAndReadTodoInDb()
        {
            // Setup our database
            // Set values
            DbContextOptions<TodosDBContext> options = new DbContextOptionsBuilder<TodosDBContext>().UseInMemoryDatabase("DbCanSaveTodo").Options;

            using (TodosDBContext context = new TodosDBContext(options))
            {
                // Arrange
                Todo Todo = new Todo();
                Todo.Name = "Clean Room";
                context.Todos.Add(Todo);
                context.SaveChanges();

                // Act
                var TodoName = await context.Todos.FirstOrDefaultAsync();

                // Assert
                Assert.Equal("Clean Room", TodoName.Name);
            }
        }

        /// <summary>
        /// Updates the read Todo in database.
        /// </summary>
        [Fact]
        public async void UpdateReadTodoInDb()
        {
            // Setup our database
            // Set values
            DbContextOptions<TodosDBContext> options = new DbContextOptionsBuilder<TodosDBContext>().UseInMemoryDatabase("DbCanUpdateTodo").Options;

            using (TodosDBContext context = new TodosDBContext(options))
            {
                // Arrange
                Todo Todo = new Todo();
                Todo.Name = "Clean Room";
                context.Todos.Add(Todo);
                context.SaveChanges();

                // Act
                Todo.Name = "Fix Tire";
                context.Todos.Update(Todo);
                context.SaveChanges();

                var TodoName = await context.Todos.FirstOrDefaultAsync();

                // Assert
                Assert.Equal("Fix Tire", TodoName.Name);
            }
        }

        /// <summary>
        /// Deletes the Todo in database.
        /// </summary>
        [Fact]
        public async void DeleteTodoInDb()
        {
            // Setup our database
            // Set values
            DbContextOptions<TodosDBContext> options = new DbContextOptionsBuilder<TodosDBContext>().UseInMemoryDatabase("DbCanDeleteTodo").Options;

            using (TodosDBContext context = new TodosDBContext(options))
            {
                // Arrange
                Todo Todo = new Todo();
                Todo.Name = "Clean Room";
                context.Todos.Add(Todo);
                context.SaveChanges();

                // Act
                context.Todos.Remove(Todo);
                context.SaveChanges();

                var TodoName = await context.Todos.FirstOrDefaultAsync();

                // Assert
                Assert.Null(TodoName);
            }
        }


        /// <summary>
        /// Create and read Todolist in database.
        /// </summary>
        [Fact]
        public async void SaveAndReadTodoListInDb()
        {
            // Setup our database
            // Set values
            DbContextOptions<TodosDBContext> options = new DbContextOptionsBuilder<TodosDBContext>().UseInMemoryDatabase("DbCanSaveTodoList").Options;

            using (TodosDBContext context = new TodosDBContext(options))
            {
                // Arrange
                TodoList TodoList = new TodoList();
                TodoList.Name = "School";
                context.TodoList.Add(TodoList);
                context.SaveChanges();

                // Act
                var TodoListName = await context.TodoList.FirstOrDefaultAsync();

                // Assert
                Assert.Equal("School", TodoListName.Name);
            }
        }

        /// <summary>
        /// Updates the Todo list in database.
        /// </summary>
        [Fact]
        public async void UpdateTodoListInDb()
        {
            // Setup our database
            // Set values
            DbContextOptions<TodosDBContext> options = new DbContextOptionsBuilder<TodosDBContext>().UseInMemoryDatabase("DbCanUpdateTodoList").Options;

            using (TodosDBContext context = new TodosDBContext(options))
            {
                // Arrange
                TodoList TodoList = new TodoList();
                TodoList.Name = "School";
                context.TodoList.Add(TodoList);
                context.SaveChanges();

                // Act
                TodoList.Name = "Work";
                context.TodoList.Update(TodoList);
                context.SaveChanges();

                var TodoListName = await context.TodoList.FirstOrDefaultAsync();

                // Assert
                Assert.Equal("Work", TodoListName.Name);
            }
        }

        /// <summary>
        /// Deletes the Todo list in database.
        /// </summary>
        [Fact]
        public async void DeleteTodoListInDb()
        {
            // Setup our database
            // Set values
            DbContextOptions<TodosDBContext> options = new DbContextOptionsBuilder<TodosDBContext>().UseInMemoryDatabase("DbCanDeleteTodoList").Options;

            using (TodosDBContext context = new TodosDBContext(options))
            {
                // Arrange
                TodoList TodoList = new TodoList();
                TodoList.Name = "School";
                context.TodoList.Add(TodoList);
                context.SaveChanges();

                // Act
                context.TodoList.Remove(TodoList);
                context.SaveChanges();

                var TodoListName = await context.TodoList.FirstOrDefaultAsync();

                // Assert
                Assert.Null(TodoListName);
            }
        }


        /// <summary>
        /// Delete the Todo from Todo list in database.
        /// </summary>
        [Fact]
        public async void DeleteTodoFromTodoListInDb()
        {
            // Setup our database
            // Set values
            DbContextOptions<TodosDBContext> options = new DbContextOptionsBuilder<TodosDBContext>().UseInMemoryDatabase("DbCanAddTodoToTodoList").Options;

            using (TodosDBContext context = new TodosDBContext(options))
            {
                // Arrange
                TodoList TodoList = new TodoList();
                TodoList.Name = "School";
                context.TodoList.Add(TodoList);
                context.SaveChanges();

                Todo Todo = new Todo();
                Todo.Name = "Finish Homework";
                Todo.TodoListID = TodoList.ID;
                context.Todos.Add(Todo);

                await context.SaveChangesAsync();

                // Act
                context.Todos.Remove(Todo);
                await context.SaveChangesAsync();


                var TodoListName = await context.TodoList.FirstOrDefaultAsync();

                // Assert
                Assert.Empty(TodoListName.Todos);
            }
        }
    }
}

