using System;
using System.Windows.Forms;

namespace WaixingDecrypter
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog wxfile = new OpenFileDialog();
            wxfile.Filter="Waixing encrypted NES games|*.wxn";
            wxfile.ShowDialog();

            if (wxfile.FileName != "")
            {
                if (mapperchange.Checked)
                {
                    byte mapper=0;
                    if (byte.TryParse(newmapper.Text, out mapper))
                        romprocess.decryptwxn(wxfile.FileName, compare.Checked, nes.Checked, head.Checked, mapsave.Checked, mapper);
                    else
                    {
                        MessageBox.Show("Invalid mapper number (must be 0-255), using default");
                        romprocess.decryptwxn(wxfile.FileName, compare.Checked, nes.Checked, head.Checked, mapsave.Checked);
                    }
                }
                else 
                    romprocess.decryptwxn(wxfile.FileName, compare.Checked, nes.Checked, head.Checked, mapsave.Checked);
                MessageBox.Show("done"); 
            }
        }

        private void nes_CheckedChanged(object sender, EventArgs e)
        {
            if (!nes.Checked) { mapperchange.Enabled = false; mapsave.Enabled = false; newmapper.Enabled = false; }
            else { mapperchange.Enabled = true; mapsave.Enabled = true; if (mapperchange.Checked) newmapper.Enabled = true; }
        }

        private void mapper4_CheckedChanged(object sender, EventArgs e)
        {
            if (!mapperchange.Checked) { newmapper.Enabled = false; }
           else { newmapper.Enabled = true; }
        }

        private void convert_Click(object sender, EventArgs e)
        {
            OpenFileDialog wxfile = new OpenFileDialog();
            wxfile.Filter = "NES ROM or WXN decrypted|*.nes;*.wxn.dec";
            wxfile.ShowDialog();

            if (wxfile.FileName != "") {
                romprocess.convertbin(wxfile.FileName, meth2.Checked);
                MessageBox.Show("done"); 
            }
        }

    }
}
