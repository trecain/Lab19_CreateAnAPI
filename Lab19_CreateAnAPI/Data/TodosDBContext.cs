using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab19_CreateAnAPI.Model;

namespace Lab19_CreateAnAPI.Data
{
    public class TodosDBContext : DbContext
    {
        public TodosDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Todo>().HasData(
                new Todo
                {
                    ID = 1,
                    Name = "Wash Clothes",
                    Description = "Wash all the clothes in the hamper",
                    TodoListID = 1
                },
                new Todo
                {
                    ID = 2,
                    Name = "Clean Bathroom",
                    Description = "Clean the toilet and bathtub",
                    TodoListID = 3
                },
                new Todo
                {
                    ID = 3,
                    Name = "Throw Trash",
                    Description = "Take all trash bags to the dumpster",
                    TodoListID = 2
                },
                new Todo
                {
                    ID = 4,
                    Name = "Dust Dresser",
                    Description = "Clean all dust off dresser",
                    TodoListID = 2
                }
            );

            mb.Entity<TodoList>().HasData(
                new TodoList
                {
                    ID = 1,
                    Name = "Tre's Todo List"
                },
                new TodoList
                {
                    ID = 2,
                    Name = "Shawn's Todo List"
                },
                new TodoList
                {
                    ID = 3,
                    Name = "Lebron's Todo List"
                }
            );
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoList> TodoList { get; set; }
    }
}
