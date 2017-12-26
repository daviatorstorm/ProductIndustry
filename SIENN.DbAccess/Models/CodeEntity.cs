using System;
using System.ComponentModel.DataAnnotations;

namespace SIENN.DbAccess.Models
{
    public class CodeEntity
    {
        [Key]
        public Guid Code { get; set; } = Guid.NewGuid();
    }
}
