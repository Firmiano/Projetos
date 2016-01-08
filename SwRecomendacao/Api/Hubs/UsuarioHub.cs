
using System.Collections.Generic;
using Core.Model;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Api.Hubs
{
    [HubName("usuario")]
    public class UsuarioHub : Hub
    {
        public static void PublicarNovoEndereco(ParceiroEnderecoMd[] endereco)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<UsuarioHub>();
            hubContext.Clients.All.novoEndereco(endereco);
        }
    }
}