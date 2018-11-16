using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab19_CreateAnAPI.Model
{
    public class Todo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int TodoListID { get; set; }
    }
}
