using Estagio.bd;
using System;
using System.Data;
using System.Windows.Forms;

namespace Estagio.forms
{
    public partial class TabelaEstagio : Form
    {
        BdEstagio bd = new BdEstagio();
        public TabelaEstagio(Form parent)
        {
            InitializeComponent();
            MdiParent = parent;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            CadastraDia cd = new CadastraDia(MdiParent);
            cd.Show();
            Close();
        }

        private void TabelaEstagio_Load(object sender, EventArgs e)
        {
            foreach (DataRow dr in bd.PreencheTabela().Rows)
            {
                dgFiltro.Rows.Add(dr.ItemArray);
                dgFiltro.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            txtHoras.Text = Convert.ToString(bd.HorasFeitas()); 
        }
    }
}
