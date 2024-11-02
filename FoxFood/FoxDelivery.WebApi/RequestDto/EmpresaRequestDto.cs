namespace FoxDelivery.Api.RequestDto
{
    public class EmpresaRequestDto
    {
        public string Cnpj { get; set; }
        public string Motivo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string NomeFantasia { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
