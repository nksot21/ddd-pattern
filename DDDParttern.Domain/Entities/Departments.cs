using DDDParttern.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDParttern.Domain.Entities
{
    [Table("Departments")]
    public class Departments : IBaseEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Column("DeletedAt")]
        public DateTime? DeletedAt { get; set; } = null;

        public Departments() { }
        public Departments(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }   
}
