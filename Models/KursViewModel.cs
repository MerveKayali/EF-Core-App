using System.ComponentModel.DataAnnotations;
using efcoreApp.Data;

namespace efcoreApp.Models
{
    public class KursViewModel
    {
        public int KursId { get; set; }
        [Required]
        public string? Baslik { get; set; }
        public int OgretmenId{get; set;}
        public ICollection<KursKayit> KursKayitlari { get; set; }= new List<KursKayit>();
        
    }
}