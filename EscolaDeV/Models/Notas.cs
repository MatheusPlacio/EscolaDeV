using System.ComponentModel.DataAnnotations.Schema;

namespace EscolaDeV.Models
{
    public class Notas : BaseEntity
    {
        [ForeignKey("User")]
        public int EstudanteId { get; set; }

        [ForeignKey("Curso")]
        public int CursoId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        public virtual User Estudante { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
