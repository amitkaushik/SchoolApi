using System.ComponentModel;

namespace dot7.API.Crud.Data.Entities;
public class tblStudent
{
    [ReadOnly(true)]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? Age {get;set;}
    public string? Gender{get;set;}
}