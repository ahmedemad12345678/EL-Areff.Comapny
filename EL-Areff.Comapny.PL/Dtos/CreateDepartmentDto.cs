using System.ComponentModel.DataAnnotations;

namespace EL_Areff.Comapny.PL.Dtos
{
    public class CreateDepartmentDto
    {
        [Required (ErrorMessage = "Code is Required !")]
        public string? Code { get; set; }

        [Required(ErrorMessage = "Name is Required !")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "CraeteAt is Required !")]
        public DateTime CraeteAt { get; set; }
    }
}
