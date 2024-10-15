using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Ogretmen
    {
        [Key]
        public int OgretmenId { get; set; }
        public string? Ad {get; set;}
        public string? Soyad { get; set; }
        public string AdSoyad  { 
            get
            {
                return this.Ad+" "+Soyad;
            } 
        }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime BaslamaTarihi {get; set;}
        public ICollection<KursKayit> Kurslar { get; set; }= new List<KursKayit>();
    }
}