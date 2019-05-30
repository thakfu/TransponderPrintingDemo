using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Diagnostics;

namespace TransponderPrinting
{

    public partial class frmTransPrint : Form
    {

        int qty = 0;

        public frmTransPrint()
        {
            InitializeComponent();
        }

        private void txtPart_TextChanged(object sender, EventArgs e)
        {
            lblDesc.Text = String.Format(txtPart.Text);
            lblDate.Text = DateTime.Now.ToString("MMddyyyy");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPart.Text = "";
            txtJob.Text = "";
            txtQty.Text = "";
            lblDesc.Text = "";
            lblDate.Text = "";
            lblStatus.ForeColor = Color.FromArgb(255, 0, 0);
            lblStatus.Text = "Please Enter Part Number";
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtJob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPart.Text))
            {
                lblStatus.ForeColor = Color.FromArgb(255, 0, 0);
                lblStatus.Text = "You haven't entered a part number";
            }
            else if (String.IsNullOrEmpty(txtJob.Text))
            {
                lblStatus.ForeColor = Color.FromArgb(255, 0, 0);
                lblStatus.Text = "You haven't entered a job number";
            }
            else if (String.IsNullOrEmpty(txtQty.Text))
            {
                lblStatus.ForeColor = Color.FromArgb(255, 0, 0);
                lblStatus.Text = "Please enter a quantity greater than 0";
            }
            else
            {
                using (StreamWriter writetext = new StreamWriter("write.txt"))
                {
                    for (int i = 0; i < qty; i++)
                    {
                        writetext.WriteLine(txtPart.Text);
                        writetext.WriteLine(txtJob.Text);
                        writetext.WriteLine(lblDesc.Text);
                        writetext.WriteLine(lblDate.Text);
                        writetext.WriteLine("");
                    }
                    Process.Start("notepad.exe", "write.txt");
                    lblStatus.ForeColor = Color.FromArgb(0, 255, 0);
                    lblStatus.Text = "Successful Print";
                }
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtQty.Text))
            {
                qty = 0;
            }
            else
            {
                qty = Convert.ToInt32(txtQty.Text);
            }
        }
    }
}
