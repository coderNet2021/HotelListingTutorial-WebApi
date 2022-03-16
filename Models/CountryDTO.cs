using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
    public class CreateCountryDTO
    {
        //creating a DTO per OPERATION!!!
        [Required]
        [StringLength(maximumLength:50,ErrorMessage ="Country Name is Too Long!")]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength:2,ErrorMessage ="Short Country Name is Too Long!")]
        public string  ShortName { get; set; }
    }

    public class CountryDTO:CreateCountryDTO
    {
        //creating a DTO per OPERATION!!!
        public int Id { get; set; }
        public  IList<HotelDTO> Hotels { get; set; }
    }
}