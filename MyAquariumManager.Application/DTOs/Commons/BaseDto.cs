namespace MyAquariumManager.Application.DTOs.Commons
{
    public class BaseDto
    {
        public Guid Id { get; private set; }
        public string CodigoConta { get; set; }
        public DateTime DataCriacao { get; private set; }
        public string UsuarioCriacao { get; private set; }
        public DateTime? DataAlteracao { get; private set; }
        public string UsuarioAlteracao { get; private set; }
        public DateTime? DataExclusao { get; private set; }
        public string UsuarioExclusao { get; private set; }
    }
}
