using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "كود العميل")]
        public int Id { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال اسم العميل بالعربية")]
        [Display(Name = "اسم العميل")]
        public string NameArab { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال اسم العميل بالانجليزية")]
        [Display(Name = "اسم العميل بالانجليزية")]
        public string NameEng { get; set; }

        [Display(Name = "عنوان العميل")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "رقم الهوية")]
        public string IdNumber { get; set; }

        [Display(Name = "رقم الهوية للوكيل أو الولي")]
        public string IdNumberForAgent { get; set; }

        [Display(Name = "محل الميلاد")]
        public string IdissuePlace { get; set; }

        [Display(Name = "تاريخ انتهاء البطاقة")]
        public DateTime?  IdExpiryDate { get; set; }

        [Display(Name = "المهنة")]
        public string Occupation { get; set; }

        [Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }

        [ForeignKey("Nationality")]
        [Display(Name = "الجنسية")]
        public int? NationalityId { get; set; }
        public Nationality Nationality { get; set; }

        [ForeignKey("Religion")]
        [Display(Name = "الديانة")]
        public int? ReligionId { get; set; }
        public Religion Religion { get; set; }

        [ForeignKey("TypeId")]
        [Display(Name = "نوع الهوية")]
        public int? IDTypeId { get; set; }
        public TypeId TypeId { get; set; }

        [Display(Name = "الدولة")]
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [Display(Name = "المدينة")]
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        [Display(Name = "المركز/الحي")]
        public int? DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District District { get; set; }

        public virtual ICollection<CustomerPhone> CustomerPhones { get; set; }

    }



}