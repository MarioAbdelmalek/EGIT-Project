﻿using BLL;
using EGITBackend.HubConfig;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EGITBackend
{
    public sealed class SignalRService : BackgroundService
    {
        private IServiceProvider serviceProvider;
        private readonly IHubContext<EGITHub> EGITHub;

        public SignalRService(IServiceProvider serviceProvider, IHubContext<EGITHub> EGITHub)
        {
            this.serviceProvider = serviceProvider;
            this.EGITHub = EGITHub;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var hostedServices = scope.ServiceProvider.GetRequiredService<IEGITService>();

                    var updatedLunList = hostedServices.GetUpdatedLuns();
                    if (updatedLunList.Count != 0)
                    {
                        await EGITHub.Clients.All.SendAsync("UpdatedLuns", Newtonsoft.Json.JsonConvert.SerializeObject(updatedLunList));
                    }

                    var updatedStorageList = hostedServices.GetUpdatedStorages();
                    if (updatedStorageList.Count != 0)
                    {
                        await EGITHub.Clients.All.SendAsync("UpdatedStorages", Newtonsoft.Json.JsonConvert.SerializeObject(updatedStorageList));
                    }

                    var updatedClusterList = hostedServices.GetUpdatedClusters();
                    if (updatedClusterList.Count != 0)
                    {
                        await EGITHub.Clients.All.SendAsync("UpdatedClusters", Newtonsoft.Json.JsonConvert.SerializeObject(updatedClusterList));
                    }

                    var updatedNodeList = hostedServices.GetUpdatedNodes();
                    if (updatedNodeList.Count != 0)
                    {
                        await EGITHub.Clients.All.SendAsync("UpdatedNodes", Newtonsoft.Json.JsonConvert.SerializeObject(updatedNodeList));
                    }


                    var updatedVMList = hostedServices.GetUpdatedVMs();
                    if (updatedVMList.Count != 0)
                    {
                        await EGITHub.Clients.All.SendAsync("UpdatedVMs", Newtonsoft.Json.JsonConvert.SerializeObject(updatedVMList));
                    }

                    var updatedVPNList = hostedServices.GetUpdatedVPNs();
                    if (updatedVPNList.Count != 0)
                    {
                        await EGITHub.Clients.All.SendAsync("UpdatedVPNs", Newtonsoft.Json.JsonConvert.SerializeObject(updatedVPNList));
                    }

                    var updatedClientList = hostedServices.GetUpdatedClients();
                    if (updatedClientList.Count != 0)
                    {
                        await EGITHub.Clients.All.SendAsync("UpdatedClients", Newtonsoft.Json.JsonConvert.SerializeObject(updatedClientList));
                    }
                }

                await Task.Delay(new TimeSpan(0, 0, 5));
            }
        }
    }
}
