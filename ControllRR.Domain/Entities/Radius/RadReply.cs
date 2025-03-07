namespace ControllRR.Domain.Entities.Radius;

public class RadReply
{
    public uint Id { get; set; }

    public string Username { get; set; } = null!;

    public string Attribute { get; set; } = null!;

    public string Op { get; set; } = null!;

    public string Value { get; set; } = null!;


    public RadReply() { }


    public RadReply(uint id, string username, string attribute, string op, string value)
    {
        Id = id;
        Username = username;
        Attribute = attribute;
        Op = op;
        Value = value;
    }
}
