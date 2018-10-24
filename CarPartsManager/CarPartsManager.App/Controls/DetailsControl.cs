namespace CarPartsManager.App.Controls
{
    using Logic.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class DetailsControl : UserControl
    {
        private LinkedListNode<Image> currentImage;
        private Image pictureToDraw;

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
            panel.ContextMenuStrip = new ContextMenuStrip();
            panel.ContextMenuStrip.Items.Add("Принтиране", Properties.Resources.print_button, Panel_ContextMenu_ItemClick);
            panel.Controls.Add(dialogPb);


            var dialog = new GeneralForm();
            dialog.panel1.Visible = false;
            dialog.WindowState = FormWindowState.Maximized;
            //dialog.TopMost = true;

            dialog.Controls.Add(panel);
            panel.BringToFront();
            dialogPb.BringToFront();

            dialog.ShowDialog();
        }
        private void Panel_ContextMenu_ItemClick(object sender, EventArgs e)
        {
            var printDialog = new PrintDialog();

            var pd = new PrintDocument();
            pd.PrintPage -= new PrintPageEventHandler(PrintPageEvent);
            pd.PrintPage += new PrintPageEventHandler(PrintPageEvent);

            var panelControls = ((ContextMenuStrip)((ToolStripItem)sender).GetCurrentParent()).SourceControl.Controls;
            foreach (var control in panelControls)
            {
                if (control is PictureBox pb)
                {
                    printDialog.Document = pd;
                    var res = printDialog.ShowDialog();

                    if (res == DialogResult.OK)
                    {
                        pictureToDraw = pb.Image;
                        pd.Print();
                    }

                    break;
                }
            }
        }

        private void PrintPageEvent(object sender, PrintPageEventArgs e)
        {
            int A4FormatWidth = e.PageBounds.Size.Width;
            int A4FormatHeight = e.PageBounds.Size.Height;

            var graphics = e.Graphics;

            if (pictureToDraw.Size.Height < pictureToDraw.Size.Width)
            {
                pictureToDraw.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            graphics.DrawImage(pictureToDraw, e.MarginBounds.X, e.MarginBounds.Y, e.MarginBounds.Height, e.MarginBounds.Width);
            e.HasMorePages = false;
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
