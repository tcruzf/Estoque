using System.ComponentModel.DataAnnotations;
using ControllRR.Domain.Entities;

namespace ControllRR.Application.Dto;

public class CustomerDto
{

    public int Id { get; set; }
    [Display(Name = "Nome do cliente")]
    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    public string? Name { get; set; }
    [Display(Name = "CPF do cliente")]
    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]

    public string? CPF_CNPJ { get; set; }
    
    //[ValidateComplexType]
    public ContactInfo? ContactInfo { get; set; }
}