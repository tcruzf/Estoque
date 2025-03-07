namespace ControllRR.Application.Dto;

public class ProfilesDto
{
    public int Id { get; set; }

    public string NomePlano { get; set; } = null!;

    public string ValorPlano { get; set; } = null!;

    public string DescricaoPlano { get; set; } = null!;

    public string BasePlanoVelocidade { get; set; } = null!;

    public string FilialPlano { get; set; } = null!;

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
    public int BusinessCompanyId { get; set; }
    public BusinessCompany BusinessCompany { get; set; } = null!;
}