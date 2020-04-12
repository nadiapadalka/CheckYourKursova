// <copyright file="TaskChanges.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Kursova.DAL.Entities
{
    using System;

    public class TaskChanges
    {
        public int Id { get; set; }

        public int TaskItemId { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string Description { get; set; }

        public Documentation Documentation { get; set; }
    }
}
