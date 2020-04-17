﻿// <copyright file="TaskItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.DAL.Entities
{
    using System;
    using System.Collections.Generic;

    public class TaskItem
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Grade { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DeadLine { get; set; }

        public TimeSpan EstimatedTime { get; set; }

        public bool IsDone { get; set; }

        public List<TaskChanges> Changes { get; set; }
    }
}
