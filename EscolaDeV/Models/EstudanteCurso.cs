namespace EscolaDeV.Models
{
    public class EstudanteCurso
    {
        public int EstudanteId { get; set; }
        public int CursoId { get; set; }
        public User Estudante { get; set; }
        public Curso Curso { get; set; }
    }
}
