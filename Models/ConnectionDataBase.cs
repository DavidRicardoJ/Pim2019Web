using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pim2019WEB.Models
{
    public class ConnectionDataBase
    {
        private string Server = @"XBLADE\SQLEXPRESS";
        private string Database = "dbPim2019";


        SqlConnection conn = new SqlConnection();


        public void OpenConnection()
        {
            try
            {

                conn.ConnectionString = (string.Format("Server={0}; Database ={1}; Trusted_Connection = True", Server, Database));
                conn.Open();
                //System.Windows.Forms.MessageBox.Show(conn.State.ToString());
            }
            catch (SqlException )
            {
                // MessageBox.Show("Erro na Conexão. \n" + ex.Message);
            }
        }



        public List<Abastecimento> DataReaderSQL(string query)
        {

            try
            {

                if (conn.State == ConnectionState.Closed)
                {
                    OpenConnection();
                }
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = query;
                sqlCommand.Connection = conn;
                List<Abastecimento> list = new List<Abastecimento>();


                SqlDataReader valor = (sqlCommand.ExecuteReader());


                while (valor.Read())
                {
                    Abastecimento obj = new Abastecimento();
                    obj.Data = DateTime.Parse(valor[0].ToString());
                    obj.RazaoSocial = valor[1].ToString();
                    obj.Placa = valor[2].ToString();
                    obj.Modelo = valor[3].ToString();
                    obj.Marca = valor[4].ToString();
                    obj.Fornecedor = valor[5].ToString();
                    obj.Combustivel = valor[6].ToString();
                    obj.Litros = double.Parse(valor[7].ToString());
                    obj.ValorLitro = decimal.Parse(valor[8].ToString());
                    obj.ValorTotal = decimal.Parse(valor[9].ToString());
                    list.Add(obj);
                }

                return list;


            }
            catch (SqlException )
            {
                return null;
            }
            finally
            {

                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();

                }
            }

        }

    }
}
