using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    public class CustomerPhone
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        [Display(Name = "كود العميل")]
        public int CustomerId { get; set; }

        [ForeignKey("PhoneType")]
        [Display(Name = "نوع الهاتف")]
        public int PhoneTypeId { get; set; }

        [Display(Name = "رقم الهاتف")]
        [Required(ErrorMessage ="يجب ادخال رقم الهاتف")]
        public string PhoneNo { get; set; }

        public virtual PhoneType PhoneType { get; set; }

        public virtual Customer Customer { get; set; }
    }
}