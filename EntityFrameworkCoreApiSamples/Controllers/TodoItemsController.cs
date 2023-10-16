using EntityFrameworkCoreApiSamples.DataContext;
using EntityFrameworkCoreApiSamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreApiSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodosContext _context;

        public TodoItemsController(TodosContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route(nameof(GetTodoItemsByTodoId))]
        public async Task<ActionResult<List<TodoItem>>> GetTodoItemsByTodoId(int todoId)
        {
            try
            {
                List<TodoItem> todos = await _context.TodoItems.Where(x => x.TodoId == todoId).AsNoTracking().ToListAsync();
                return Ok(todos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{todoItemId}", Name = "GetTodoItem")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int todoItemId)
        {
            try
            {
                TodoItem? todos = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == todoItemId);
                return Ok(todos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route(nameof(CreateTodoItem))]
        public async Task<ActionResult<Todo>> CreateTodoItem([FromBody] TodoItem todoItem)
        {
            try
            {
                _context.TodoItems.Add(todoItem);
                await _context.SaveChangesAsync();

                return CreatedAtRoute("GetTodoItem", new { todoItemId = todoItem.Id }, todoItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("{todoItemId:int}")]
        public async Task<ActionResult> UpdateTodoItem(int todoItemId, [FromBody] TodoItem todoItemUpdated)
        {
            ArgumentNullException.ThrowIfNull(todoItemId, nameof(todoItemId));
            try
            {
                TodoItem? todoItemFromDatabase = await _context.TodoItems.FirstOrDefaultAsync(x =>x.Id == todoItemId);
                if (todoItemFromDatabase == null)
                    return NotFound();

                todoItemFromDatabase.IsCompleted = todoItemUpdated.IsCompleted;
                todoItemFromDatabase.Description = todoItemUpdated.Description;

                _context.TodoItems.Update(todoItemFromDatabase);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{todoItemId}")]
        public async Task<ActionResult> Delete(int todoItemId)
        {
            try
            {
                TodoItem? todoItem = await _context.TodoItems.FirstOrDefaultAsync(y => y.Id == todoItemId);
                if (todoItem is null)
                    return NotFound();

                _context.TodoItems.Remove(todoItem);
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
