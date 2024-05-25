using System.Collections.Generic;

namespace XMLProcessing
{
    public class XMLData
    {
        public string ChaveAcesso { get; set; }
        public string Numero { get; set; }
        public string DataEmissao { get; set; }
        public string EmitenteNome { get; set; }
        public string EmitenteCNPJ { get; set; }
        public string EmitenteEndereco { get; set; }
        public string DestinatarioNome { get; set; }
        public string DestinatarioCNPJ { get; set; }
        public string DestinatarioEndereco { get; set; }
        public List<Produto> Produtos { get; set; }
        public string ValorTotalNota { get; set; }
    }

    public class Produto
    {
        public string Descricao { get; set; }
        public string Quantidade { get; set; }
        public string ValorUnitario { get; set; }
        public string ValorTotal { get; set; }
    }
}
