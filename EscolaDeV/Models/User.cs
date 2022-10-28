using EscolaDeV.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EscolaDeV.Models
{
    public class User : BaseEntity
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public int Idade { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }

        
        public string ConfirmarSenha { get; set; }

        
        public string SenhaAtual { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public ICollection<Curso> CursosProfessor { get; set; }
        [JsonIgnore]
        public ICollection<Curso> CursoEstudando { get; set; }
        [JsonIgnore]
        public List<EstudanteCurso> EstudanteCursos { get; set; }

    }
}
