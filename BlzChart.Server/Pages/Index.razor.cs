using BlzChart.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BlzChart.Server.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject] IJSRuntime JSRuntime { get; set; }
        [Inject] HttpClient Http { get; set; }
        private async Task OnButtonClicked()
        {
            var data = await Http.GetFromJsonAsync<ChartData[]>("https://localhost:7028/WeatherForecast/GetChartData");

            var funded = data.Where(x => x.Program != null).Sum(s => s.Funded);
            var remainingBalance = data.Where(x => x.Program != null).Sum(s => s.RemainingBalance);
            var pendingApproval = data.Where(x => x.Program != null).Sum(s => s.PendingApproval);
            var commited = data.Where(x => x.Program != null).Sum(s => s.Commited);
            var invoiced = data.Where(x => x.Program != null).Sum(s => s.Invoiced);

            var arrLegends = new string[] { "", "Funded", "Remaining Balance", "Pending Approval", "Commited", "Invoiced" };

            var arrData = new double[] {0, funded, remainingBalance , pendingApproval , commited , invoiced };
           
            await JSRuntime.InvokeVoidAsync("loadMe", arrLegends, arrData);
        }
    }
}
