// <copyright file="CommentDocumentController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Kursova.BLL.Interfaces;
    using Kursova.DAL.EF;
    using Kursova.DAL.Entities;
    using Kursova.ViewModels;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class CommentDocumentController : Controller
    {
        private readonly KursovaDbContext db;
        private readonly ILogger<CommentDocumentController> log;
        private KursovaPageModel info = new KursovaPageModel();

        public CommentDocumentController(KursovaDbContext context)
        {
            this.db = context;

            // this.info.Students = this.db.Students;
            // this.info.Teachers = this.db.Teachers;
        }
    }
}