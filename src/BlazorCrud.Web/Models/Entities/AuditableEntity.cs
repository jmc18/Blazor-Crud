namespace BlazorCrud.Web.Models.Entities;

public abstract class AuditableEntity
{
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
