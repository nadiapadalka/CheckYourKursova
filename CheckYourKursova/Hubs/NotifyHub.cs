using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Kursova.ViewModels;
using Microsoft.AspNetCore.Http;
using Kursova.DAL.EF;
using Microsoft.AspNetCore.Authorization;

namespace Kursova.Hubs
{
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