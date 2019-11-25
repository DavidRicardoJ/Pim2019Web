using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pim2019WEB.Models
{
    public class Contato
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Mensagem { get; set; }

        public bool SalvarMensagemContato(Contato contato)
        {
            ConnectionDataBase conn = new ConnectionDataBase();
            string sqlCmd = $"insert into tbContato (nome,email,telefone,mensagem) values ('{contato.Nome.Trim()}', '{contato.Email.Trim()}', '{contato.Telefone}', '{contato.Mensagem}');";
            return conn.SqlExecuteNonQuery(sqlCmd);
        }
    }
}
