using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Pim2019WEB.Models
{
    public class Abastecimento
    {
       [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        public string RazaoSocial { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Fornecedor { get; set; }
        public string Combustivel { get; set; }
        public double Litros { get; set; }
        public decimal ValorLitro { get; set; }
        public decimal ValorTotal { get; set; }

        public Abastecimento(DateTime data, string razaoSocial, string placa, string modelo, string marca, string fornecedor, string combustivel, double litros, decimal valorLitro, decimal valorTotal)
        {
            Data = data;
            RazaoSocial = razaoSocial;
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            Fornecedor = fornecedor;
            Combustivel = combustivel;
            Litros = litros;
            ValorLitro = valorLitro;
            ValorTotal = valorTotal;
        }

        public Abastecimento()
        {
        }

        public List<Abastecimento> ListaAbastecimento()
        {
            ConnectionDataBase conn = new ConnectionDataBase();
            string sqlCmd = "SELECT FORMAT (getdate(), 'dd/MM/yyyy') as 'Data' , tc.razaoSocial AS 'Razão Social',tv.placa AS 'Placa',  tmv.modelo AS 'Modelo', tmv2.marca AS 'Marca', " +
                            "tf.razaoSocial AS 'Fornecedor',tc2.combustivel AS 'Combustivel' ,convert(decimal(10, 2), (ta.valorTotal / ta.valorLitro)) AS 'Litros',ta.valorLitro AS 'Valor/Litro', ta.valorTotal AS 'Valor Total' " +
                            "FROM dbo.tbAbastecimento ta, dbo.tbVeiculo tv, dbo.tbCliente tc, dbo.tbMarcaModelo tmm, dbo.tbModeloVeiculo tmv, dbo.tbMarcaVeiculo tmv2, dbo.tbFornecedor tf, dbo.tbCombustivel tc2 " +
                            "WHERE ta.idVeiculo = tv.idVeiculo AND tv.idVeiculo = tmm.idVeiculo AND tmm.idModeloVeiculo = tmv.idModeloVeiculo AND tmm.idMarcaVeiculo = tmv2.idMarcaVeiculo AND tv.idCliente = tc.idCliente AND tf.idFornecedor = ta.idFornecedor AND tc2.idCombustivel = ta.idCombustivel; ";
           
            return conn.DataReaderSQL(sqlCmd);
        }
    }
}
