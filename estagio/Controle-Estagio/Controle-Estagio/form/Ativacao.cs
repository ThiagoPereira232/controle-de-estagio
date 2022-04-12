using Controle_Estagio.bd;
using System;
using System.IO;
using System.Windows.Forms;

namespace Controle_Estagio.form
{
    public partial class Ativacao : Form
    {
        BdAluno bd;
        public Ativacao(Form parent)
        {
            InitializeComponent();
            MdiParent = parent;
            bd = new BdAluno();
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            if (bd.verificaExiste(txtKey.Text))
            {
                if (!bd.verificaUsando(txtKey.Text))
                {
                    string path = @".\key.txt";
                    StreamWriter writer = new StreamWriter(path);
                    string key = txtKey.Text;
                    writer.WriteLine(key);
                    writer.Close();
                    bd.atualiza(key);
                    TabelaEstagio f = new TabelaEstagio(MdiParent);
                    f.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Chave de ativação em uso");
                }

            }
            else
            {
                MessageBox.Show("Chave de ativação não existe");
            }

        }
    }
}
