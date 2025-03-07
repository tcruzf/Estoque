using System;
using System.Collections.Generic;

namespace ControllRR.Domain.Entities.Radius;

public  class RadAcct
{
    public long Radacctid { get; set; }

    public string Acctsessionid { get; set; } = null!;

    public string Acctuniqueid { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Groupname { get; set; } = null!;

    public string? Realm { get; set; }

    public string Nasipaddress { get; set; } = null!;

    public string? Nasportid { get; set; }

    public string? Nasporttype { get; set; }

    public DateTime? Acctstarttime { get; set; }

    public DateTime? Acctupdatetime { get; set; }

    public DateTime? Acctstoptime { get; set; }

    public int? Acctinterval { get; set; }

    public uint? Acctsessiontime { get; set; }

    public string? Acctauthentic { get; set; }

    public string? ConnectinfoStart { get; set; }

    public string? ConnectinfoStop { get; set; }

    public long? Acctinputoctets { get; set; }

    public long? Acctoutputoctets { get; set; }

    public string Calledstationid { get; set; } = null!;

    public string Callingstationid { get; set; } = null!;

    public string Acctterminatecause { get; set; } = null!;

    public string? Servicetype { get; set; }

    public string? Framedprotocol { get; set; }

    public string Framedipaddress { get; set; } = null!;
    public RadAcct(){}

    public RadAcct(long radacctid, string acctsessionid, string acctuniqueid, string username, string groupname, string? realm, string nasipaddress, string? nasportid, string? nasporttype, DateTime? acctstarttime, DateTime? acctupdatetime, DateTime? acctstoptime, int? acctinterval, uint? acctsessiontime, string? acctauthentic, string? connectinfoStart, string? connectinfoStop, long? acctinputoctets, long? acctoutputoctets, string calledstationid, string callingstationid, string acctterminatecause, string? servicetype, string? framedprotocol, string framedipaddress)
    {
        Radacctid = radacctid;
        Acctsessionid = acctsessionid;
        Acctuniqueid = acctuniqueid;
        Username = username;
        Groupname = groupname;
        Realm = realm;
        Nasipaddress = nasipaddress;
        Nasportid = nasportid;
        Nasporttype = nasporttype;
        Acctstarttime = acctstarttime;
        Acctupdatetime = acctupdatetime;
        Acctstoptime = acctstoptime;
        Acctinterval = acctinterval;
        Acctsessiontime = acctsessiontime;
        Acctauthentic = acctauthentic;
        ConnectinfoStart = connectinfoStart;
        ConnectinfoStop = connectinfoStop;
        Acctinputoctets = acctinputoctets;
        Acctoutputoctets = acctoutputoctets;
        Calledstationid = calledstationid;
        Callingstationid = callingstationid;
        Acctterminatecause = acctterminatecause;
        Servicetype = servicetype;
        Framedprotocol = framedprotocol;
        Framedipaddress = framedipaddress;
    }
}
