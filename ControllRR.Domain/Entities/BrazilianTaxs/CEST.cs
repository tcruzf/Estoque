using System.ComponentModel.DataAnnotations;

namespace ControllRR.Domain.Entities.BrazilianTaxs;


public class CEST
{
    [Key]
    [MaxLength(10)]
    public string CodigoTbc { get; set; }
    public int LegalTbc { get; set; }
    public int NcmTbc { get; set; }
    public string? DescTbc { get; set; }

    public CEST()
    {

    }

    public CEST(string codTbc, int legalTbc, int ncmTbc, string? descTbc)
    {
        CodigoTbc = codTbc;
        LegalTbc = legalTbc;
        NcmTbc = ncmTbc;
        DescTbc = descTbc;

    }
}