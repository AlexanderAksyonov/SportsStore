using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportsStore.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }

        [Required(ErrorMessage= "Требуется ввести имя")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage= "Требуется ввести описание")]
        public string Description { get; set; }

        [Required]
        [Range (0.01, double.MaxValue, ErrorMessage= "Введите нормальную цену!")]
        public decimal Price { get; set; }

        [Required(ErrorMessage= "Укажите категорию")]
        public string Category { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType {get; set;}
    }
}
