using Core.Models.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.NotifyApp.Service
{
    public class ApiService
    {
        public async Task<Response> CheckConnection() {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Revisar conexion a internet."
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable("google.com");
            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Revisar conexion a internet."
                };
            }

            return new Response
            {
                IsSuccess = true,
                Message = "Conexion estable."
            };
        }
    }
}
