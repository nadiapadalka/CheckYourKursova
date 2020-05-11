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