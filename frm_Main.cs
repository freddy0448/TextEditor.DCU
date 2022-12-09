using System;
using System.IO;
using System.Windows.Forms;

namespace TextEditor.DCU
{
    public partial class frm_Main : Form
    {
        private string archivo;
        public frm_Main()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivo = "";
            rtxt_Main.Clear();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text |*.txt";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                archivo = ofd.FileName;

                using (StreamReader sr = new StreamReader(archivo))
                {
                    rtxt_Main.Text = sr.ReadToEnd();
                }
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text |*.txt";

            if(archivo != null)
            {
                using(StreamWriter sw = new StreamWriter(archivo) )
                {
                    sw.Write(rtxt_Main.Text);
                }
            }
            else 
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    archivo = saveFileDialog.FileName;
                    using (StreamWriter sw = new StreamWriter(archivo) )
                    {
                        sw.Write(rtxt_Main.Text);
                    }
                }
            }
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {

        }

        private void rtxt_Main_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
