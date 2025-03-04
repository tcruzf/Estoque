namespace ControllRR.Domain.Entities;

public class ContactInfo
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Street { get; set; }
    public string? Neigh { get; set; }
    public string? CEP { get; set; }
    public string? WhattsApp { get; set; }

     public int CustomerId { get; set; }  // Chave estrangeira
    public Customer Customer { get; set; } = null!;

    public ContactInfo()
    {
        
    }

    public ContactInfo(int id, string? email, string? phone, string? street, 
                       string? neigh, string? cep, string? whattsApp, int customerId)
    {
        Id = id;
        Email = email;
        Phone = phone;
        Street = street;
        Neigh = neigh;
        CEP = cep;
        WhattsApp = whattsApp;
        CustomerId = customerId;
    }
}