namespace FoxDelivery.Dominio.Entites
{
    public class Empresa
    {
        public long Id { get; set; }
        public string Cep { get; set; }
        public int? Numero { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public long IdUsuario { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cnpj { get; set; }
        public string RazacaoSocial { get; set; }
    }
}
