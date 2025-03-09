using System.ComponentModel.DataAnnotations;

namespace ControllRR.Application.Dto;


public class BusinessCompanyDto
{
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

    public ICollection<ProfilesDto?> InformationProfiles { get; set; }

}