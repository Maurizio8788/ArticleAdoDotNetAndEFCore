using EntityFrameworkCoreApiSamples.DataContext;
using EntityFrameworkCoreApiSamples.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreApiSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodosContext _context;

        public TodosController(TodosContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route(nameof(GetAllTodos))]
        public async Task<ActionResult<List<Todo>>> GetAllTodos()
        {
            try
            {
                List<Todo> todos = await _context.Todos.AsNoTracking().ToListAsync();
                return Ok(todos);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route(nameof(GetAllTodoWithItems))]
        public async Task<ActionResult<List<Todo>>> GetAllTodoWithItems()
        {
            try
            {
                List<Todo> todos = await _context.Todos.Include(x => x.TodoItems ).AsNoTracking().ToListAsync();
                return Ok(todos);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{todoId}", Name ="GetTodo")]
        public async Task<ActionResult<Todo>> GetTodo(int todoId)
        {
            try
            {
                Todo? todos = await _context.Todos.FirstOrDefaultAsync(x => x.Id == todoId);
                return Ok(todos);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route(nameof(CreateTodo))]
        public async Task<ActionResult<Todo>> CreateTodo([FromBody] Todo todo)
        {
            try
            {
                _context.Todos.Add(todo);
                await _context.SaveChangesAsync();

                return CreatedAtRoute("GetTodo", new { todoId = todo.Id }, todo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{todoId}")]
        public async Task<ActionResult> UpdateTodo(int todoId, [FromBody] Todo todoUpdated)
        {
            try
            {
                Todo? todoFromDatabase = await _context.Todos.FirstOrDefaultAsync(x => x.Id == todoId);
                if (todoFromDatabase == null)
                    return NotFound();

                todoFromDatabase.Name = todoUpdated.Name;

                _context.Todos.Update(todoFromDatabase);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpDelete("{todoId}")]
        public async Task<ActionResult> Delete(int todoId)
        {
            try
            {
                Todo? todo = await _context.Todos.FirstOrDefaultAsync(y => y.Id == todoId);
                if (todo is null)
                    return NotFound();

                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
