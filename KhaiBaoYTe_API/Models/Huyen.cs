using System.ComponentModel.DataAnnotations;

namespace KhaiBaoYTe_API.Models
{
    public class Huyen
    {
        [Key]
        public string Ma { get; set; }
        public string MaTP { get; set; }
        public string Ten { get; set; }
        public string Cap { get; set; }
    }
}