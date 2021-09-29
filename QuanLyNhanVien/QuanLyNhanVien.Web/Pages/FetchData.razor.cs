using QuanLyNhanVien.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanVien.Web.Pages
{
    public partial class FetchData
    {
        private readonly WeatherForecastService ForecastService = new WeatherForecastService();
        private WeatherForecast[] forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
        }
    }
}
