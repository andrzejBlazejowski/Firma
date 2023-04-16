using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Data.CMS
{
    public class Parametry
    {
        [Key]//to co niżej jest klucem podstawowym tabeli
        public int Id { get; set; }

        [Required(ErrorMessage = "Wartosc jest wymagana")]//pole jest wymagane
        [MaxLength(10, ErrorMessage = "Tytuł może zawierac max 10 znakow")]//maksymalna długość
        [Display(Name = "Tutuł odnośnika do strony")]//tą nazę pola będzie widzial uzytkownik
        public string Wartosc { get; set; }

        [Display(Name = "Opis")]
        [Column(TypeName = "nvarchar(MAX)")]//określa jakiego typu to pole będzie w bazie danych
        public string Opis { get; set; }
    }
}
