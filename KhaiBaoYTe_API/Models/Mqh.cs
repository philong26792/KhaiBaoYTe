using System.ComponentModel.DataAnnotations;

namespace KhaiBaoYTe_API.Models
{
    public class Mqh
    {
        [Key]
        public int Ma { get; set; }
        public string Ten { get; set; }
        public string GhiChu { get; set; }
    }
}