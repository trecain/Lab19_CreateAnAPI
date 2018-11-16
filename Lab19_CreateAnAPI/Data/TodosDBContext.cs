using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab19_CreateAnAPI.Data
{
    public class TodosDBContext : DbContext
    {
        public TodosDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
