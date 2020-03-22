using System;
using System.Collections.Generic;
using System.Text;

namespace Kursova.DAL.Entities
{
    public class CommentEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
