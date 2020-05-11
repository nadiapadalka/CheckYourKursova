// <copyright file="Comment.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int PageId { get; set; }

        public string Initials { get; set; }

        public string CourseWork { get; set; }
        public string Filename { get; set; }
        public string Description { get; set; }
    }
}
