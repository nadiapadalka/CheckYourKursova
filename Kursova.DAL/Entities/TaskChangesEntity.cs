using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursova.DAL.Entities
{
    public class TaskChangesEntity
    {
        public int Id { get; set; }
        public int TaskItemId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Description { get; set; }
        public DocumentationEntity documentation { get; set; }
    }
}
