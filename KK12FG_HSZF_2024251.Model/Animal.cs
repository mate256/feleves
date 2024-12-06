using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Newtonsoft.Json;

namespace KK12FG_HSZF_2024251.Model
{
    public class Animal
    {
        //nevét, nemét, faját, életkorát, az állateledelek aktuális készletét
        public Animal(string name, string gender, string species, int age)
        {
            Name = name;
            Gender = gender;
            Species = species;
            Age = age;
            Activities = new HashSet<Activity>();
            Foods = new HashSet<Food>();
        }

        public Animal()
        {
            Activities = new HashSet<Activity>();
            Foods = new HashSet<Food>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AnimalId { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Gender")]

        [StringLength(10)]
        public string Gender { get; set; }
        [JsonProperty("Species")]

        [StringLength(20)]
        public string Species { get; set; }
        [JsonProperty("Age")]
        
        public int Age { get; set; }
        [JsonProperty("Activity")]
        public virtual ICollection<Activity> Activities { get; set; }
        [JsonProperty("Food")]
        public virtual ICollection<Food> Foods { get; set; }


    }
}
