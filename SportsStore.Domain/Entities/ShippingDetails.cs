using System.ComponentModel.DataAnnotations;

namespace SportsStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Слышь! Веди имя!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Куда отправлять?!")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Город, сука, укажи!")]
        public string  City { get; set; }

        [Required(ErrorMessage = "Штат?!")]
        public string State { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage = "А страна кака?")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
