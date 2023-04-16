using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.Sklep
{
    public class Towar
    {
        [Key]
        public int IdTowaru { get; set; }

        [Required(ErrorMessage = "Kod jest wymagany")]
        public string Kod { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagany")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Cena jest wymagany")]
        [Column(TypeName = "money")]
        public decimal Cena { get; set; }

        [Display(Name = "Wybierz zdjęcie")]
        [Required(ErrorMessage = "Foto jest wymagane")]
        public string FotoURL { get; set; }
        public string Opis { get; set; }

        //to jest realizacja klucza obcego
        public int RodzajId { get; set; }
        public Rodzaj Rodzaj { get; set; }
    }
}
