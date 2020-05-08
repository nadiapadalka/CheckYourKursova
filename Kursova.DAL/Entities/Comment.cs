// <copyright file="Comment.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
