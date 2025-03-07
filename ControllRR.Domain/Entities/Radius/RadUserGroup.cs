
namespace ControllRR.Domain.Entities.Radius;

public class RadUserGroup
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Groupname { get; set; } = null!;

    public int Priority { get; set; }


    public RadUserGroup()
    {
    }

    public RadUserGroup(int id, string username, string groupname, int priority)
    {
        Id = id;
        Username = username;
        Groupname = groupname;
        Priority = priority;
    }
}
