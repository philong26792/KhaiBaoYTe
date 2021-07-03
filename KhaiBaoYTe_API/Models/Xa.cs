using System.ComponentModel.DataAnnotations;

namespace KhaiBaoYTe_API.Models
{
    public class Xa
    {
        [Key]
        public string Ma { get; set; }
        public string MaQH { get; set; }
        public string Ten { get; set; }
        public string Cap { get; set; }
    }
}