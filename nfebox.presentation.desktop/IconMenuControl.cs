using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using nfebox.communication;

namespace nfebox.presentation.desktop
{
    public partial class IconMenuControl : UserControl
    {
        public IconMenuControl()
        {
            InitializeComponent();
        }

        private void sairMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void enviarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var key = "yanlimaj@gmail.com2baa3bde07cd13257b5e63b9bff0c55436767c9faf3ed6a7ace0575cdc97d7fa1a5cbbc911b13318ea99bf330ba58d7f75fee282c3fba9c13bcc276f";
            var xml = File.ReadAllText("D:\\nfe24110604385909000166550010000000521001535245.xml");

            var request = new communication.EFDRequest(key);
            var response = request.Send(xml, EFDRequest.EFDRequestType.NFe);

            MessageBox.Show(response.Codigo + " " +response.Status);

        }
    }
}
