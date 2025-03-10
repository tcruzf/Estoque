using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BusinessCompany
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required, StringLength(250)]
    public string? RazaoSocial { get; set; }

    [Required, StringLength(500)]
    public string? NomeFantasia { get; set; }

    public DateTime? DataCadastro { get; set; }

    [Required, StringLength(500)]
    public string? CnpjEmpresa { get; set; }

    [Required, StringLength(500)]
    public string? IscEstadual { get; set; }

    [Required, StringLength(500)]
    public string? CnaeFiscal { get; set; }

    [Required, StringLength(500)]
    public string? CnaeComplementar { get; set; }

    [Required, StringLength(250)]
    public string? RegimeTributario { get; set; }

    [Required, StringLength(500)]
    public string? AtoAnatel { get; set; }

    [Required, StringLength(500)]
    public string? FoneCad { get; set; }

    [Required, StringLength(500)]
    public string? CepCad { get; set; }

    [Required, StringLength(500)]
    public string? RuaCad { get; set; }

    [Required, StringLength(500)]
    public string? NumResidenciaCad { get; set; }

    [Required, StringLength(500)]
    public string? BairroCad { get; set; }

    [Required, StringLength(500)]
    public string? ComplementoCad { get; set; }

    [Required, StringLength(500)]
    public string? CidadeCad { get; set; }

    [Required, StringLength(500)]
    public string? UfCad { get; set; }
    [Required, StringLength(500)]
    public string? IdentificacaoNegocio { get; set; }

    public ICollection<Profiles?> Profiles { get; set; }

    // Construtor sem parametros(ORM)
    public BusinessCompany()
    {
        Profiles = new List<Profiles?>();

    }

    // Construtor com parametros inicialização de propriedades de forma segura

    public BusinessCompany(int id, string razaoSocial, string nomeFantasia, DateTime dataCadastro, string cnpjEmpresa, string iscEstadual, string cnaeFiscal, string cnaeComplementar, string regimeTributario, string atoAnatel, string foneCad, string cepCad, string ruaCad, string numResidenciaCad, string bairroCad, string complementoCad, string cidadeCad, string ufCad, string identificacaoNegocio)
    {
        Id = id;
        RazaoSocial = razaoSocial;
        NomeFantasia = nomeFantasia;
        DataCadastro = dataCadastro;
        CnpjEmpresa = cnpjEmpresa;
        IscEstadual = iscEstadual;
        CnaeFiscal = cnaeFiscal;
        CnaeComplementar = cnaeComplementar;
        RegimeTributario = regimeTributario;
        AtoAnatel = atoAnatel;
        FoneCad = foneCad;
        CepCad = cepCad;
        RuaCad = ruaCad;
        NumResidenciaCad = numResidenciaCad;
        BairroCad = bairroCad;
        ComplementoCad = complementoCad;
        CidadeCad = cidadeCad;
        UfCad = ufCad;
        IdentificacaoNegocio = identificacaoNegocio;
        Profiles = new List<Profiles?>();

    }
}
