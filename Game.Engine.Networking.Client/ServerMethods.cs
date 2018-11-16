﻿namespace Game.API.Client
{
    using Game.API.Common.Models;
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class ServerMethods
    {
        protected readonly APIClient APIClient;
        public ServerMethods(APIClient apiClient)
        {
            this.APIClient = apiClient;
        }

        public async Task<Server> ServerGetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var server = await APIClient.APICallAsync<Server>(HttpMethod.Get, APIEndpoint.ServerGet, cancellationToken: cancellationToken);
                return server;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> ServerResetAsync()
        {
            try
            {
                await APIClient.APICallAsync<bool>(HttpMethod.Post, APIEndpoint.ServerReset);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}