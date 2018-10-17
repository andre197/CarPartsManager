using CarPartsManager.App.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarPartsManager.App
{
    public partial class GeneralForm : Form
    {
        public GeneralForm()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GeneralForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                return;
            }

            foreach (Control control in Controls)
            {
                if (control is BaseControl bc)
                {
                    if (!bc.Validator.Validate())
                    {
                        e.Cancel = true;
                    }
                    break;
                }
            }
        }
    }
}
