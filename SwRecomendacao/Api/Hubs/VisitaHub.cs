
using Api.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Api.Hubs
{
    [HubName("visita")]
    public class VisitaHub : Hub
    {
        public static void PublicarNovaVisita(Visita visita)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<VisitaHub>();
            hubContext.Clients.All.novaVisita(visita);
            
        }
    }
}