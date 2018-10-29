using Core.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Core.NotifyApp.Tools
{
    public static class Connection
    {
        static Service.ApiService apiService = new Service.ApiService();
        public static async Task<bool> CheckConnection() {

            var result  = await apiService.CheckConnection();

            if (!result.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    result.Message,
                    "Aceptar");
                return !result.IsSuccess;
            }
            return result.IsSuccess;
        }
    }
}
