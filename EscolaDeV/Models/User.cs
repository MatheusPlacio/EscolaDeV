using EscolaDeV.Enums;

namespace EscolaDeV.Models
{
    public class User : BaseEntity
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public int Idade { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }


    }
}
