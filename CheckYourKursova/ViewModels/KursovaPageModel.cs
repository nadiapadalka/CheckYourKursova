namespace Kursova.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Kursova.DAL.Entities;
    using Kursova.DAL.EF;

    public class KursovaPageModel
    {
        public IEnumerable<Student> Students { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<Documentation> Documentation { get; set; }
        public string Comment { get; set; }

        public string Document { get; set;
        }

    }
}
