using System.ComponentModel.DataAnnotations;

namespace ControllRR.Application.Dto;

public class SysProfilesDto
{
    public int Id { get; set; }

    [Display(Name = "Nome do Plano")]
    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    public string NomePlano { get; set; } = null!;
    [Display(Name = "Valor do Plano")]
    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    public string ValorPlano { get; set; } = null!;
    [Display(Name = "Descrição")]
    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    public string DescricaoPlano { get; set; } = null!;
    [Display(Name = "Velocidade")]
    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    public string BasePlanoVelocidade { get; set; } = null!;
    [Display(Name = "Descrição")]
    public string? FilialPlano { get; set; } = null!;
    [Display(Name = "Tipo conexão")]
    [Required(ErrorMessage = "O campo {0} é obrigatorio!")]
    public string TipoConexao { get; set; } = null!;
    public DateOnly? Ciclo { get; set; }

    public DateOnly? Abreciclo { get; set; }

    public DateOnly? DataVencimento { get; set; }

    public DateOnly? DataVencimento1 { get; set; }

    public DateOnly? DataVencimento2 { get; set; }

    public DateOnly? DataVencimento3 { get; set; }

    public int? Ultimafatura { get; set; }

    public int? Ultimocod { get; set; }

    public decimal? PadraoJuros { get; set; }

    public decimal? PadraoMulta { get; set; }
    [Display(Name = "Empresa")]
    public int BusinessCompanyId { get; set; }
    public BusinessCompanyDto BusinessCompanyDto { get; set; } = null!;
}