using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using System.Data;

namespace Projeto_Oficina_Mecânica
{
    class cl_cliente
    {
        public Int32 id_cliente { set; get; }
        public String nome { set; get; }
        public String endereco { set; get; }
        public String telefone { set; get; }
        public String celular { set; get; }
        

        conectaBD BD = new conectaBD();

        public int Salvar()
        {
            int id = 0;
            try
            {
                BD._sql = String.Format(new CultureInfo("en-US"), "INSERT INTO CLIENTE (Nome, endereço, Telefone, Celular) " +
                                        " values ('{0}','{1}','{2}','{3}')", nome, endereco, telefone, celular) ;

                BD.ExecutaComando(false, out id);

                if (id > 0)
                {
                    MessageBox.Show("Cadastro realizado com sucesso!", "Cadastrado com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return id;

        }
        
        public DataTable PesquisaAutomatica()
        {
            try
            {
                BD._sql = "SELECT * FROM CLIENTE";

                return BD.ExecutaSelect();
            }
            catch (Exception)
            {

            }
            return null;
        }

        
        public void Apagar()
            {
                try
                {
                    int exOK = 0;
                    BD._sql = String.Format("DELETE FROM CLIENTE WHERE ID_cliente = '{0}'", id_cliente);

                    exOK = BD.ExecutaComando(false);


                    if (exOK < 0)
                    {
                        MessageBox.Show("Erro ao deletar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Deletado com sucesso!", "Deletado com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
        
    }
}
