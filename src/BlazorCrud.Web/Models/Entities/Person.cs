using System.ComponentModel.DataAnnotations;

namespace BlazorCrud.Web.Models.Entities;
public class Person : AuditableEntity
{
    public Guid? PersonId { get; set; }
    [Required]
    public string Name { get; set; }
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
}

