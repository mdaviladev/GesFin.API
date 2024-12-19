using System.ComponentModel.DataAnnotations;

namespace GesFin.Core.Requests.Categories
{
    public class CreateCategoryRequest: Request
    {
        [Required(ErrorMessage = "Título Inválido.")]
        [MaxLength(80, ErrorMessage = "Título deve conter até 80 caracteres.")]
        public string Title { get; set; }   =  string.Empty;
        public string? Description { get; set; }

    }
}