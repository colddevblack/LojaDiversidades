using System.ComponentModel.DataAnnotations;

namespace LojaDiversidade.Web.Models;
public class CategoryViewModel
{
    public int CategoryId { get; set; }
    [Required]
    public string? Name { get; set; }
}
