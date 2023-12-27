using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tyuiu.BakhtiyarovDR.Sprint7.Project.V15.Lib;

namespace Tyuiu.BakhtiyarovDR.Sprint7.Project.V15
{
    public partial class FormWriteText : Form
    {
        public FormWriteText()
        {
            InitializeComponent();
        }

        DataService ds = new DataService();

        private void buttonOK_BDR_Click(object sender, EventArgs e)
        {
            DataService.Text = textBoxInputLabelColumn_BDR.Text;
            this.Close();
        }

        private void FormWriteText_Load(object sender, EventArgs e)
        {

        }
    }
}
