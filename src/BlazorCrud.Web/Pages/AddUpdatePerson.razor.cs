using BlazorCrud.Web.Models.Entities;
using BlazorCrud.Web.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorCrud.Web.Pages;
public partial class AddUpdatePerson : ComponentBase
{
    [Inject] public IPersonService _personService { get; set; }

    [Parameter] public string personId { get; set; }
    public string message { get; set; } = string.Empty;
    private Person person = new();
    private string pageTitle = "AddPerson";

    protected override async Task OnInitializedAsync()
    {
        if (!string.IsNullOrEmpty(personId))
        {
            pageTitle = "Update Person";
            person = await _personService.FindById(personId);
        }

        await base.OnInitializedAsync();
    }


    private async void SavePerson()
    {
        var saveResponse = await _personService.AddUpdate(person);
        if (saveResponse)
        {
            message = "Record Saved.";
            person = new();
        }
        else
            message = "Could not save";
    }
}

