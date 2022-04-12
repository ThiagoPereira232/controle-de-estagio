using Controle_Estagio.bd;
using Controle_Estagio.vo;
using System;
using System.Windows.Forms;

namespace Controle_Estagio.form
{
    public partial class CadastraDia : Form
    {
        EstagioDias estagio = new EstagioDias();
        BdEstagio bdEstagio;
        public CadastraDia(Form parent)
        {
            InitializeComponent();
            bdEstagio = new BdEstagio();
            MdiParent = parent;
        }

        private void telaToEstagio()
        {
            estagio.Id = Convert.ToInt32(txtId.Text);
            estagio.Data = Convert.ToDateTime(txtData.Text).Date;
            estagio.Descricao = txtDescricao.Text;
            estagio.HoraIni = Convert.ToDateTime(txtHoraIni.Text);
            estagio.HoraFin = Convert.ToDateTime(txtHoraFin.Text);
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            telaToEstagio();
            bdEstagio.salva(estagio);
            TabelaEstagio fe = new TabelaEstagio(MdiParent);
            fe.Show();
            Close();
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            TabelaEstagio f = new TabelaEstagio(MdiParent);
            f.Show();
            Close();
        }
    }
}
