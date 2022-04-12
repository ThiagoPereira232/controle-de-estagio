using Controle_Estagio.bd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle_Estagio.form
{
    public partial class TabelaEstagio : Form
    {
        BdEstagio bd = new BdEstagio();
        public TabelaEstagio(Form parent)
        {
            InitializeComponent();
            MdiParent = parent;
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

        private void bNovo_Click(object sender, EventArgs e)
        {
            CadastraDia cd = new CadastraDia(MdiParent);
            cd.Show();
            Close();
        }

        private void bExcluir_Click(object sender, EventArgs e)
        {
            int codigo = -1;
            int linha = dgFiltro.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (linha > -1)
            {
                codigo = (int)dgFiltro.Rows[linha].Cells[0].Value;
                TimeSpan horaIni = (TimeSpan)dgFiltro.Rows[linha].Cells[3].Value;
                TimeSpan horaFin = (TimeSpan)dgFiltro.Rows[linha].Cells[4].Value;
                bd.deletar(codigo, horaIni, horaFin);
                dgFiltro.Rows.Clear();
                foreach (DataRow dr in bd.PreencheTabela().Rows)
                {
                    dgFiltro.Rows.Add(dr.ItemArray);
                    dgFiltro.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                txtHoras.Text = Convert.ToString(bd.HorasFeitas());
            }
            else
            {
                MessageBox.Show("Selecione um dia");
            }
        }
    }
}
