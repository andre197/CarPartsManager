using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarPartsManager.Logic.Helpers;

namespace CarPartsManager.App.Controls
{
    public partial class DetailsControl : UserControl
    {
        private LinkedListNode<Image> currentImage;

        public DetailsControl()
        {
            InitializeComponent();
        }

        public LinkedList<Image> Images { get; set; }
        public CarPartsViewHelper CarPartInfo { get; set; }

        private void DetailsControl_Load(object sender, EventArgs e)
        {
            currentImage = Images.First;
            pictureBox1.Image = currentImage.Value;
            EnableDisableBackwardsAndForwardButtons();

            labelInfo.Text = $"Част {CarPartInfo.PartName} (наличност: {CarPartInfo.Quantity}) за {CarPartInfo.MakerName} модел {CarPartInfo.Model} от {CarPartInfo.CreationDate.ToString("yyyy")} с уникален номер {CarPartInfo.PartUniqueNumber}";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var dialogPb = new PictureBox();
            dialogPb.Image = currentImage.Value;
            dialogPb.Size = currentImage.Value.Size;

            var panel = new Panel();
            panel.AutoScroll = true;
            panel.HorizontalScroll.Visible = true;
            panel.Dock = DockStyle.Fill;
            panel.Controls.Add(dialogPb);

            var dialog = new GeneralForm();
            dialog.panel1.Visible = false;
            dialog.WindowState = FormWindowState.Maximized;
            dialog.TopMost = true;

            dialog.Controls.Add(panel);
            panel.BringToFront();
            dialogPb.BringToFront();

            dialog.ShowDialog();
        }

        private void buttonBackwards_Click(object sender, EventArgs e)
        {
            currentImage = currentImage.Previous;
            pictureBox1.Image = currentImage.Value;
            EnableDisableBackwardsAndForwardButtons();
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            currentImage = currentImage.Next;
            pictureBox1.Image = currentImage.Value;
            EnableDisableBackwardsAndForwardButtons();
        }

        private void EnableDisableBackwardsAndForwardButtons()
        {
            if (currentImage == null)
            {
                buttonBackwards.Enabled = false;
                buttonForward.Enabled = false;
                return;
            }

            if (currentImage.Previous == null)
            {
                buttonBackwards.Enabled = false;
            }
            else
            {
                buttonBackwards.Enabled = true;
            }
            if (currentImage.Next == null)
            {
                buttonForward.Enabled = false;
            }
            else
            {
                buttonForward.Enabled = true;
            }
        }
    }
}
