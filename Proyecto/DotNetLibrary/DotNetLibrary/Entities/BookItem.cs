using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetLibrary.Entities
{
    public class BookItem
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(4), MinLength(4), Required]
        public string year { get; set; }
        [MaxLength(20)]
        public string genere { get; set; }
        public string edition { get; set; }
        [Required]
        public string author { get; set; }
        public decimal price { get; set; }
    }
}