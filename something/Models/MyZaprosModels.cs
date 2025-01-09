using System.ComponentModel.DataAnnotations;

namespace something.Models
{
    public class MyZaprosModels
    {
        public class zapros1
        {
            [Key] public int id { get; set; }
            public string? name { get; set; }
            public string? surname { get; set; }
            public string? father_name { get; set; }

            public int rating { get; set; }

        }
    }
}
