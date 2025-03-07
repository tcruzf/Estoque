
namespace ControllRR.Domain.Entities.Radius;

public class RadpostAuth
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string Reply { get; set; } = null!;

    public DateTime Authdate { get; set; }


    public RadpostAuth()
    {
    }

    public RadpostAuth(int id, string username, string pass, string reply, DateTime authdate)
    {
        Id = id;
        Username = username;
        Pass = pass;
        Reply = reply;
        Authdate = authdate;
    }
}
