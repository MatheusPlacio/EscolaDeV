using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EscolaDeV.Models
{
    public class Curso : BaseEntity
    {
        public int ProfessorId { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public Notas Notas { get; set; }
        public int NotasId { get; set; }
        public virtual  User Professor { get; set; }
        [JsonIgnore]
        public ICollection<User> Estudantes { get; set; }
        [JsonIgnore]
        public List<EstudanteCurso> EstudanteCursos { get; set; }
    }
}
