using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class StaticData
    {
        [Key]
        public int Id { get; set; }  // Primary Key

        [Required]
        [MaxLength(255)]
        public string Key { get; set; }  // Key Column

        [MaxLength(255)]
        public string Value { get; set; }  // Value Column

        public string Description { get; set; }  // Description Column

        [Required]
        public string Sts { get; set; } = "Active";  // Status Column with a default value of true

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Creation Timestamp

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;  // Update Timestamp
    }

}
