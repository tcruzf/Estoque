namespace ControllRR.Domain.Entities.Radius;

public class SysProfiles 
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

    public SysProfiles()
    {

    }
    public SysProfiles(int id, string nomePlano, string valorPlano, string descricaoPlano, string basePlanoVelocidade, string filialPlano, string tipoConexao, DateOnly? ciclo, DateOnly? abreciclo, DateOnly? dataVencimento, DateOnly? dataVencimento1, DateOnly? dataVencimento2, DateOnly? dataVencimento3, int? ultimafatura, int? ultimocod, decimal? padraoJuros, decimal? padraoMulta, BusinessCompany businessCompany)
    {
        Id = id;
        NomePlano = nomePlano;
        ValorPlano = valorPlano;
        DescricaoPlano = descricaoPlano;
        BasePlanoVelocidade = basePlanoVelocidade;
        FilialPlano = filialPlano;
        TipoConexao = tipoConexao;
        Ciclo = ciclo;
        Abreciclo = abreciclo;
        DataVencimento = dataVencimento;
        DataVencimento1 = dataVencimento1;
        DataVencimento2 = dataVencimento2;
        DataVencimento3 = dataVencimento3;
        Ultimafatura = ultimafatura;
        Ultimocod = ultimocod;
        PadraoJuros = padraoJuros;
        PadraoMulta = padraoMulta;
        BusinessCompany = businessCompany;
    }

    

}