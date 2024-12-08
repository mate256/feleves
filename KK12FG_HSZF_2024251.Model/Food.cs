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
    public class Food
    {
        public Food(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
            Animals = new HashSet<Animal>();
        }

        public Food()
        {
            Animals = new HashSet<Animal>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string FoodId { get; set; }
        [JsonProperty("Name")]
        [StringLength(20)]
        public string Name { get; set; }
        [JsonProperty("Quantity")]
        public int Quantity { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
        
        [ForeignKey("AnimalId")]
        public string AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
