namespace ControllRR.Domain.Entities;


public class BusinessConfiguration
{

    public int Id { get; set; }
    public string? Modules { get; set; }
    public string? Manager { get; set; }

    public BusinessConfiguration()
    {

    }

    public BusinessConfiguration(int id, string? modules, string? manager)
    {
        Id = id;
        Modules = modules;
        Manager = manager;

    }
}