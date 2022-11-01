using EscolaDeV.Enums;
using EscolaDeV.Models;
using System.ComponentModel.DataAnnotations;

namespace EscolaDeV.DTO
{
    public class Authenticate
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        [Required]
        public string NomeUsuario { get; set; }
        [Required]
        public string password { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string Token { get; set; }

        public Authenticate(User user, string token)
        {
            Id = user.Id;
            PrimeiroNome = user.PrimeiroNome;
            UltimoNome = user.UltimoNome;
            NomeUsuario = user.NomeUsuario;
            TipoUsuario = user.TipoUsuario;
            Token = token;
        }
    }
}
