using BlazorCrud.Web.Models.Entities;
using BlazorCrud.Web.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorCrud.Web.Pages
{
    public partial class PersonList : ComponentBase
    {
        [Inject] public IPersonService _personService { get; set; }
        [Inject] private NavigationManager Navigatio { get; set; }
        private List<Person> _personList = new List<Person>();

        protected override async Task OnInitializedAsync()
        {
            _personList = await _personService.GetAll();
            await base.OnInitializedAsync();
        }

        private void GoTo(string route)
        {
            Navigatio.NavigateTo(route);
        }

        private async Task DeletePerson(Guid? personId)
        {

            var response = await _personService.Delete(personId?.ToString());
            if (response)
            {
                _personList = await _personService.GetAll();
            }
        }
    }
}
