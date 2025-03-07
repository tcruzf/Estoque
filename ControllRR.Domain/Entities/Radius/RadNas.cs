
namespace ControllRR.Infrastructure.ContextData;

public class RadNas
{
    public int Id { get; set; }

    public string Nasname { get; set; } = null!;

    public string? Shortname { get; set; }

    public string? Type { get; set; }

    public int? Ports { get; set; }

    public string Secret { get; set; } = null!;

    public string? Server { get; set; }

    public string? Community { get; set; }

    public string? Description { get; set; }




    public RadNas()
    {
    }

    public RadNas(int id, string nasname, string secret)
    {
        Id = id;
        Nasname = nasname;
        Secret = secret;
    }

    public RadNas(int id, string nasname, string? shortname, string? type, int? ports, string secret, string? server, string? community, string? description)
    {
        Id = id;
        Nasname = nasname;
        Shortname = shortname;
        Type = type;
        Ports = ports;
        Secret = secret;
        Server = server;
        Community = community;
        Description = description;
    }
}