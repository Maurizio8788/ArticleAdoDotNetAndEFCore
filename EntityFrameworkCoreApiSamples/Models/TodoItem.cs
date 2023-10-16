using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreApiSamples.Models;

[Table(nameof(TodoItem))]
public class TodoItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(150)]
    [Column("todo_item_description")]
    public string Description { get; set; }
    [Column("todo_item_is_completed")]
    public bool IsCompleted { get; set; }

    public int TodoId { get; set; }
    [ForeignKey(nameof(TodoId))]
    public Todo? Todo { get; set; }
}
