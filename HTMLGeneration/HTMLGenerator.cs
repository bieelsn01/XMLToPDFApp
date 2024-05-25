using System.IO;
using System.Text;
using XMLProcessing;

namespace HTMLGeneration
{
    public static class HTMLGenerator
    {
        public static string Generate(XMLData data, string templatePath)
        {
            string templateContent = File.ReadAllText(templatePath);

            templateContent = templateContent.Replace("{{chNFe}}", data.ChaveAcesso);
            templateContent = templateContent.Replace("{{nNF}}", data.Numero);
            templateContent = templateContent.Replace("{{dhEmi}}", data.DataEmissao);
            templateContent = templateContent.Replace("{{emitenteNome}}", data.EmitenteNome);
            templateContent = templateContent.Replace("{{emitenteCNPJ}}", data.EmitenteCNPJ);
            templateContent = templateContent.Replace("{{emitenteEndereco}}", data.EmitenteEndereco);
            templateContent = templateContent.Replace("{{destinatarioNome}}", data.DestinatarioNome);
            templateContent = templateContent.Replace("{{destinatarioCNPJ}}", data.DestinatarioCNPJ);
            templateContent = templateContent.Replace("{{destinatarioEndereco}}", data.DestinatarioEndereco);
            templateContent = templateContent.Replace("{{valorTotalNota}}", data.ValorTotalNota);

            StringBuilder produtosBuilder = new StringBuilder();
            foreach (var produto in data.Produtos)
            {
                produtosBuilder.Append("<tr>");
                produtosBuilder.Append($"<td>{produto.Descricao}</td>");
                produtosBuilder.Append($"<td>{produto.Quantidade}</td>");
                produtosBuilder.Append($"<td>{produto.ValorUnitario}</td>");
                produtosBuilder.Append($"<td>{produto.ValorTotal}</td>");
                produtosBuilder.Append("</tr>");
            }
            templateContent = templateContent.Replace("{{#produtos}}", produtosBuilder.ToString());

            return templateContent;
        }
    }
}
