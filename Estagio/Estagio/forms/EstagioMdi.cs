using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estagio.forms
{
    public partial class EstagioMdi : Form
    {
        bool formActivated = true;
        public EstagioMdi()
        {
            InitializeComponent();
            HorizontalScroll.Visible = false;
        }

        private void EstagioMdi_Activated(object sender, EventArgs e)
        {
            if (formActivated)
            {
                formActivated = false;
                TabelaEstagio te = new TabelaEstagio(this);
                te.StartPosition = FormStartPosition.CenterScreen;
                te.Show();
            }
        }
    }
}
