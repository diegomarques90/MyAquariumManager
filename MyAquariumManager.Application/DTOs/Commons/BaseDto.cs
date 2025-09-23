namespace MyAquariumManager.Application.DTOs.Commons
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public string CodigoConta { get; set; }
        public DateTime DataCriacao { get; set; }
        public string UsuarioCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string UsuarioExclusao { get; set; }
    }
}
