using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Lab19_CreateAnAPI.Data;
using Lab19_CreateAnAPI.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab19_CreateAnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly TodosDBContext _context;

        public ToDoListController(TodosDBContext context)
        {
            _context = context;
        }

        // GET: api/TodoList
        [HttpGet]
        public ActionResult<IEnumerable<TodoList>> GetToDoLists()
        {
            return _context.TodoList;
        }


        // GET: api/TodoList/5
        [HttpGet("{id}")]
        public IActionResult GetToDoList([FromRoute] int id)
        {
            var toDoList = _context.TodoList.FirstOrDefault(x => x.ID == id);

            if (toDoList == null)
            {
                return NotFound();
            }

            toDoList.Todos = _context.Todos.Where(t => t.TodoListID == toDoList.ID).ToList();

            return Ok(toDoList);
        }


        // POST: api/TodoList
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoList toDoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.TodoList.AddAsync(toDoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoList", new { id = toDoList.ID }, toDoList);
        }


        // PUT: api/TodoList/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] TodoList toDoList)
        {
            var found = _context.TodoList.FirstOrDefault(x => x.ID == id);

            if (found != null)
            {
                _context.TodoList.Update(toDoList);
            }
            else
            {
                await Post(toDoList);
            }

            return RedirectToAction("Get", new { id = toDoList.ID });
        }


        // DELETE: api/TodoList/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {

            var result = _context.TodoList.FirstOrDefault(x => x.ID == id);

            if (result != null)
            {
                _context.TodoList.Remove(result);
            }

            return Ok();
        }
    }
}
