using System;
using System.Collections.Generic;

namespace ControllRR.Domain.Entities.Radius;

public class RadIpPool
{
    public uint Id { get; set; }

    public string PoolName { get; set; } = null!;

    public string Framedipaddress { get; set; } = null!;

    public string Nasipaddress { get; set; } = null!;

    public string Calledstationid { get; set; } = null!;

    public string Callingstationid { get; set; } = null!;

    public DateTime? ExpiryTime { get; set; }

    public string Username { get; set; } = null!;

    public string PoolKey { get; set; } = null!;

    public string Bloqueio { get; set; } = null!;


    public RadIpPool()
    {
    }

    public RadIpPool(uint id, string poolName, string framedipaddress, string nasipaddress, string calledstationid, string callingstationid, DateTime? expiryTime, string username, string poolKey, string bloqueio)
    {
        Id = id;
        PoolName = poolName;
        Framedipaddress = framedipaddress;
        Nasipaddress = nasipaddress;
        Calledstationid = calledstationid;
        Callingstationid = callingstationid;
        ExpiryTime = expiryTime;
        Username = username;
        PoolKey = poolKey;
        Bloqueio = bloqueio;
    }

}
