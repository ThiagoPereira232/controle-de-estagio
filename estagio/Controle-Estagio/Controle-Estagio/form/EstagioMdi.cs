using Controle_Estagio.bd;
using System;
using System.Windows.Forms;

namespace Controle_Estagio.form
{
    public partial class EstagioMdi : Form
    {
        BdAluno bd;
        bool formActivated = true;

        public EstagioMdi()
        {
            InitializeComponent();
            HorizontalScroll.Visible = false;
            bd = new BdAluno();
        }

        private void EstagioMdi_Activated(object sender, EventArgs e)
        {
            if (formActivated)
            {
                if (bd.verificaKey())
                {
                    formActivated = false;
                    TabelaEstagio te = new TabelaEstagio(this);
                    te.StartPosition = FormStartPosition.CenterScreen;
                    te.Show();
                }
                else
                {
                    formActivated = false;
                    Ativacao te = new Ativacao(this);
                    te.StartPosition = FormStartPosition.CenterScreen;
                    te.Show();
                }
            }
            
        }
    }
}
