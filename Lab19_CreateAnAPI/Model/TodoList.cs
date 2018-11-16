using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab19_CreateAnAPI.Model
{
    public class TodoList
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Todo> Todos { get; set; }
    }
}
