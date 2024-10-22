namespace OrderProcessingSystem.Models
{
    public class ResponseModel
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
