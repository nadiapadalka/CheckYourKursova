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

        public async Task Send(string user, string message, string userId)
        {
            await this.Clients.User(userId).SendAsync("Receive", user, message);
        }

        public async Task SendMessageTeacher(string user, string message)
        {
            await this.Clients.All.SendAsync("ReceiveMessageTeacher", user, message);
        }

        public async Task SendMessageTeacherComment(string user, string message)
        {
            await this.Clients.All.SendAsync("MessageComment", user, message);
        }

        public async Task SendMessageStudentRegister(string user, string message)
        {
            await this.Clients.All.SendAsync("ReceiveMessageReg", user, message);
        }

        public async Task SendMessageTeacherRegister(string user, string message)
        {
            await this.Clients.All.SendAsync("MessageReg", user, message);
        }
    }
}