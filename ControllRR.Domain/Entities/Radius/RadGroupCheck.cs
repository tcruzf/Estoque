using System;
using System.Collections.Generic;

namespace ControllRR.Domain.Entities.Radius;

public class RadGroupCheck
{
    public uint Id { get; set; }

    public string Groupname { get; set; } = null!;

    public string Attribute { get; set; } = null!;

    public string Op { get; set; } = null!;

    public string Value { get; set; } = null!;

    
    public RadGroupCheck() { }

   
    public RadGroupCheck(uint id, string groupname, string attribute, string op, string value)
    {
        Id = id;
        Groupname = groupname;
        Attribute = attribute;
        Op = op;
        Value = value;
    }
}
