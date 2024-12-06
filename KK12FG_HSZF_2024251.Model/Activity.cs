using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK12FG_HSZF_2024251.Model
{
    public class Activity
    {
        public Activity(DateTime date, string type, string description, string animalId)
        {
            Date = date;
            Type = type;
            Description = description;
            AnimalId = animalId;
        }
        public Activity() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ActivityId { get; set; }
        [JsonProperty("Date")]
        public DateTime Date { get; set; }
        [JsonProperty("Type")]
        [StringLength(20)]
        public string Type { get; set; }
        [JsonProperty("Description")]
        [StringLength(500)]
        public string Description { get; set; }

        [ForeignKey("AnimalId")]
        public string AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
