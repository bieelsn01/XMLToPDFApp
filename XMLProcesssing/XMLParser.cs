using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace XMLProcessing
{
    public static class XMLParser
    {
        public static XMLData Parse(string xmlFilePath)
        {
            var doc = XDocument.Load(xmlFilePath);
            XNamespace ns = "http://www.portalfiscal.inf.br/nfe";

            var data = new XMLData
            {
                ChaveAcesso = doc.Descendants(ns + "infProt").Elements(ns + "chNFe").FirstOrDefault()?.Value ?? "",
                Numero = doc.Descendants(ns + "ide").Elements(ns + "nNF").FirstOrDefault()?.Value ?? "",
                DataEmissao = doc.Descendants(ns + "ide").Elements(ns + "dhEmi").FirstOrDefault()?.Value ?? "",
                EmitenteNome = doc.Descendants(ns + "emit").Elements(ns + "xNome").FirstOrDefault()?.Value ?? "",
                EmitenteCNPJ = doc.Descendants(ns + "emit").Elements(ns + "CNPJ").FirstOrDefault()?.Value ?? "",
                EmitenteEndereco = doc.Descendants(ns + "enderEmit").Elements(ns + "xLgr").FirstOrDefault()?.Value + ", " +
                                   doc.Descendants(ns + "enderEmit").Elements(ns + "nro").FirstOrDefault()?.Value + " - " +
                                   doc.Descendants(ns + "enderEmit").Elements(ns + "xBairro").FirstOrDefault()?.Value + ", " +
                                   doc.Descendants(ns + "enderEmit").Elements(ns + "xMun").FirstOrDefault()?.Value + " - " +
                                   doc.Descendants(ns + "enderEmit").Elements(ns + "UF").FirstOrDefault()?.Value + " - " +
                                   doc.Descendants(ns + "enderEmit").Elements(ns + "CEP").FirstOrDefault()?.Value,
                DestinatarioNome = doc.Descendants(ns + "dest").Elements(ns + "xNome").FirstOrDefault()?.Value ?? "",
                DestinatarioCNPJ = doc.Descendants(ns + "dest").Elements(ns + "CNPJ").FirstOrDefault()?.Value ?? "",
                DestinatarioEndereco = doc.Descendants(ns + "enderDest").Elements(ns + "xLgr").FirstOrDefault()?.Value + ", " +
                                      doc.Descendants(ns + "enderDest").Elements(ns + "nro").FirstOrDefault()?.Value + " - " +
                                      doc.Descendants(ns + "enderDest").Elements(ns + "xBairro").FirstOrDefault()?.Value + ", " +
                                      doc.Descendants(ns + "enderDest").Elements(ns + "xMun").FirstOrDefault()?.Value + " - " +
                                      doc.Descendants(ns + "enderDest").Elements(ns + "UF").FirstOrDefault()?.Value + " - " +
                                      doc.Descendants(ns + "enderDest").Elements(ns + "CEP").FirstOrDefault()?.Value,
                ValorTotalNota = doc.Descendants(ns + "ICMSTot").Elements(ns + "vNF").FirstOrDefault()?.Value ?? "",
                Produtos = doc.Descendants(ns + "det").Select(det => new Produto
                {
                    Descricao = det.Descendants(ns + "xProd").FirstOrDefault()?.Value ?? "",
                    Quantidade = det.Descendants(ns + "qCom").FirstOrDefault()?.Value ?? "",
                    ValorUnitario = det.Descendants(ns + "vUnCom").FirstOrDefault()?.Value ?? "",
                    ValorTotal = det.Descendants(ns + "vProd").FirstOrDefault()?.Value ?? ""
                }).ToList()
            };

            return data;

        }
    }
}   
