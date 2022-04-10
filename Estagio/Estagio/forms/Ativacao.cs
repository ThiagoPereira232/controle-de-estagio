using Estagio.bd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estagio.forms
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
    }
}
