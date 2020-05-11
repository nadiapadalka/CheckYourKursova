// <copyright file="NotifyHub.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.Hubs
{
    using System.Threading.Tasks;
    using Kursova.DAL.EF;
    using Kursova.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.SignalR;

    [Authorize]
    public class NotifyHub : Hub
    {
        private readonly KursovaDbContext db;

        public NotifyHub(KursovaDbContext dbContext)
        {
            this.db = dbContext;
        }

        public async Task SendMessageStudent(string user, string message)
        {
            await this.Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendMessageStudentfile(string user, string message)
        {
            await this.Clients.All.SendAsync("ReceiveMessagefile", user, message);
        }

        public async Task Send(string user, string message, string to)
        {
            await this.Clients.User(to).SendAsync("Receive", user, message);
        }

        public async Task SendMessageTeacher(string user, string message)
        {
            await this.Clients.All.SendAsync("ReceiveMessageTeacher", user, message);
        }
    }
}