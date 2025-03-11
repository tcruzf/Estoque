using System.ComponentModel.DataAnnotations;

namespace ControllRR.Application.Dto;


public class BusinessCompanyDto
{
       public int Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    [Display(Name = "Razão social")]
    public string? RazaoSocial { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    [Display(Name = "Nome fantasia")]
    public string? NomeFantasia { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    [Display(Name = "Data cadastro")]

    public DateTime? DataCadastro { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    [Display(Name = "CNPJ")]
    public string? CnpjEmpresa { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    [Display(Name = "Inscrição estadual")]
    public string? IscEstadual { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    [Display(Name = "CNAE Fiscal")]
    public string? CnaeFiscal { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    [Display(Name = "CNAE complementar")]
    public string? CnaeComplementar { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    [Display(Name = "Regime tributario")]
    public string? RegimeTributario { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    [Display(Name = "Ato ANATEL")]
    public string? AtoAnatel { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    [Display(Name = "Telefone")]
    public string? FoneCad { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    [Display(Name = "CEP")]
    public string? CepCad { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    [Display(Name = "Rua")]
    public string? RuaCad { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    [Display(Name = "Número")]
    public string? NumResidenciaCad { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    [Display(Name = "Bairro")]
    public string? BairroCad { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    [Display(Name = "Complemento")]
    public string? ComplementoCad { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    [Display(Name = "Cidade")]
    public string? CidadeCad { get; set; }

    [Required, StringLength(500)]
    [Display(Name = "UF")]
    public string? UfCad { get; set; }
    [Required, StringLength(500)]
    [Display(Name = "Ramo Negócio")]
    public string? IdentificacaoNegocio { get; set; }

    public ICollection<ProfilesDto?> ProfilesDtos { get; set; }

}