using System;
using System.ComponentModel.DataAnnotations;
namespace riel.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Display(Name = "Вид оплати")]
        public string Type { get; set; }
    }
}
