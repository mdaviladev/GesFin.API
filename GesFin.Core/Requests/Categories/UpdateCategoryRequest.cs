using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GesFin.Core.Requests.Categories
{
    public class UpdateCategoryRequest: Request
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Título Inválido.")]
        [MaxLength(80, ErrorMessage = "Título deve conter até 80 caracteres.")]
        public string Title { get; set; }   =  string.Empty;
        public string? Description { get; set; }
    }
}