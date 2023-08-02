using BlazorCrud.Web.Models.Entities;
using BlazorCrud.Web.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorCrud.Web.Pages;
public partial class AddUpdatePerson : ComponentBase
{
    [Inject] public IPersonService _PersonService { get; set; }

    [Parameter] public Guid personId { get; set; }
    public string message { get; set; } = string.Empty;
    private Person person = new();
    private string pagetitle = "AddPerson";
    private async void SavePerson()
    {

    }
}

