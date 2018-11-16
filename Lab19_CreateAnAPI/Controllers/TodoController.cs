using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab19_CreateAnAPI.Data;
using Lab19_CreateAnAPI.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab19_CreateAnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly TodosDBContext _context;

        public ToDoController(TodosDBContext context)
        {
            _context = context;
        }


        // GET: api/Todo
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetTodos()
        {
            return _context.Todos;
        }


        // GET: api/Todo/5
        [HttpGet("{id}")]
        public ActionResult<IActionResult> GetTodo(int id)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.ID == id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }


        // POST: api/Todo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDo", new { id = todo.ID }, todo);
        }


        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Todo todo)
        {
            var found = _context.Todos.FirstOrDefault(x => x.ID == id);

            if (found != null)
            {
                _context.Todos.Update(todo);
            }
            else
            {
                await Post(todo);
            }

            return RedirectToAction("Get", new { id = todo.ID });
        }


        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _context.Todos.FirstOrDefault(x => x.ID == id);

            if (result != null)
            {
                _context.Todos.Remove(result);
            }

            return Ok();
        }
    }
}
