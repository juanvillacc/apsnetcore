using System.ComponentModel.DataAnnotations;

namespace crud.Code
{
    public class Customer
    {
        public int id { get; set; }
        [Required, MinLength(10,ErrorMessage = "Debe llenar el nombre")]
        public string Name { get; set; }
    }
}