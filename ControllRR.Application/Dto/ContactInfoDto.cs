using System.ComponentModel.DataAnnotations;

namespace ControllRR.Application.Dto;

public class ContactInfoDto
{

    public int Id { get; set; }
    [Display(Name = "Email do cliente")]
    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    public string? Email { get; set; }
    [Display(Name = "Telefone do cliente")]
    public string? Phone { get; set; }
    [Display(Name = "Endereço/Rua/Logradouro do cliente")]
    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    public string? Street { get; set; }
    [Display(Name = "Bairro/Distrito do cliente")]
    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    public string? Neigh { get; set; }
    [Display(Name = "CEP do cliente")]
    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    public string? CEP { get; set; }
    [Display(Name = "WhattsApp do cliente")]
    public string? WhattsApp { get; set; }

    public int CustomerId { get; set; }  // Chave estrangeira
    //public CustomerDto CustomerDto { get; set; } = null!;
}