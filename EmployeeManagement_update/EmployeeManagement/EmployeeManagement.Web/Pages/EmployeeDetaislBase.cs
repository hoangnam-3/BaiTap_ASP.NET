using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetaislBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();

        protected string Coordinates { get; set; }
        protected string ButtonText { get; set; } = "Hide Footer";

        protected string CssClass { get; set; } = null;

        public int plus { get; set; } = 1;

        [Inject]
        IEmployeeService EmployeeServices { get; set; }
        [Parameter]
        public string Id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeServices.GetEmployee(int.Parse(Id));
        }

        protected void Mouse_Move(MouseEventArgs e)
        {
            Coordinates = $"X= {e.ClientX} Y = {e.ClientY}";
        }

        protected void ButtonClick()
        {
            if (ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "Hide Footer";
            }
            else
            {
                ButtonText = "Hide Footer";
                CssClass = null;
            }
        }

        protected void BtnClick1()
        {
            plus++;
        }
        protected void BtnClick2()
        {
            if (plus > 1)
                plus--;
        }

    }
}
