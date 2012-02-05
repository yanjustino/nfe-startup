namespace nfebox.presentation.desktop
{
    partial class IconMenuControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.configuracoesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.controleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuracoesMenuItem,
            this.sairMenuItem,
            this.toolStripMenuItem1,
            this.controleMenuItem,
            this.sobreMenuItem,
            this.enviarToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(182, 142);
            // 
            // configuracoesMenuItem
            // 
            this.configuracoesMenuItem.Name = "configuracoesMenuItem";
            this.configuracoesMenuItem.Size = new System.Drawing.Size(181, 22);
            this.configuracoesMenuItem.Text = "&Configurações";
            // 
            // sairMenuItem
            // 
            this.sairMenuItem.Name = "sairMenuItem";
            this.sairMenuItem.Size = new System.Drawing.Size(181, 22);
            this.sairMenuItem.Text = "&Sair";
            this.sairMenuItem.Click += new System.EventHandler(this.sairMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // controleMenuItem
            // 
            this.controleMenuItem.Name = "controleMenuItem";
            this.controleMenuItem.Size = new System.Drawing.Size(181, 22);
            this.controleMenuItem.Text = "Iniciar sincronização";
            // 
            // sobreMenuItem
            // 
            this.sobreMenuItem.Name = "sobreMenuItem";
            this.sobreMenuItem.Size = new System.Drawing.Size(181, 22);
            this.sobreMenuItem.Text = "Sobre a aplicação";
            // 
            // enviarToolStripMenuItem
            // 
            this.enviarToolStripMenuItem.Name = "enviarToolStripMenuItem";
            this.enviarToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.enviarToolStripMenuItem.Text = "Enviar";
            this.enviarToolStripMenuItem.Click += new System.EventHandler(this.enviarToolStripMenuItem_Click);
            // 
            // IconMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "IconMenuControl";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem configuracoesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sobreMenuItem;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem controleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarToolStripMenuItem;

    }
}
