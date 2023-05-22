namespace ProjecteCarregarDades_JanCasanova_AaronLuna.view
{
    partial class FormulariInsert
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btInsertar = new Button();
            lbTitol = new Label();
            lbGenere = new Label();
            lbDirector = new Label();
            lbAny = new Label();
            lbPuntuacio = new Label();
            tbTitol = new TextBox();
            tbGenere = new TextBox();
            tbDirector = new TextBox();
            tbAny = new TextBox();
            tbPuntuacio = new TextBox();
            SuspendLayout();
            // 
            // btInsertar
            // 
            btInsertar.Location = new Point(676, 404);
            btInsertar.Name = "btInsertar";
            btInsertar.Size = new Size(112, 34);
            btInsertar.TabIndex = 1;
            btInsertar.Text = "Insertar";
            btInsertar.UseVisualStyleBackColor = true;
            // 
            // lbTitol
            // 
            lbTitol.AutoSize = true;
            lbTitol.Location = new Point(27, 29);
            lbTitol.Name = "lbTitol";
            lbTitol.Size = new Size(46, 25);
            lbTitol.TabIndex = 2;
            lbTitol.Text = "Titol";
            // 
            // lbGenere
            // 
            lbGenere.AutoSize = true;
            lbGenere.Location = new Point(27, 163);
            lbGenere.Name = "lbGenere";
            lbGenere.Size = new Size(67, 25);
            lbGenere.TabIndex = 3;
            lbGenere.Text = "Genere";
            // 
            // lbDirector
            // 
            lbDirector.AutoSize = true;
            lbDirector.Location = new Point(27, 309);
            lbDirector.Name = "lbDirector";
            lbDirector.Size = new Size(75, 25);
            lbDirector.TabIndex = 4;
            lbDirector.Text = "Director";
            // 
            // lbAny
            // 
            lbAny.AutoSize = true;
            lbAny.Location = new Point(383, 89);
            lbAny.Name = "lbAny";
            lbAny.Size = new Size(43, 25);
            lbAny.TabIndex = 5;
            lbAny.Text = "Any";
            // 
            // lbPuntuacio
            // 
            lbPuntuacio.AutoSize = true;
            lbPuntuacio.Location = new Point(383, 229);
            lbPuntuacio.Name = "lbPuntuacio";
            lbPuntuacio.Size = new Size(90, 25);
            lbPuntuacio.TabIndex = 6;
            lbPuntuacio.Text = "Puntuacio";
            // 
            // tbTitol
            // 
            tbTitol.Location = new Point(27, 89);
            tbTitol.Name = "tbTitol";
            tbTitol.Size = new Size(218, 31);
            tbTitol.TabIndex = 7;
            // 
            // tbGenere
            // 
            tbGenere.Location = new Point(27, 229);
            tbGenere.Name = "tbGenere";
            tbGenere.Size = new Size(218, 31);
            tbGenere.TabIndex = 8;
            // 
            // tbDirector
            // 
            tbDirector.Location = new Point(27, 370);
            tbDirector.Name = "tbDirector";
            tbDirector.Size = new Size(218, 31);
            tbDirector.TabIndex = 9;
            // 
            // tbAny
            // 
            tbAny.Location = new Point(383, 157);
            tbAny.Name = "tbAny";
            tbAny.Size = new Size(218, 31);
            tbAny.TabIndex = 10;
            // 
            // tbPuntuacio
            // 
            tbPuntuacio.Location = new Point(383, 309);
            tbPuntuacio.Name = "tbPuntuacio";
            tbPuntuacio.Size = new Size(218, 31);
            tbPuntuacio.TabIndex = 11;
            // 
            // FormulariInsert
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbPuntuacio);
            Controls.Add(tbAny);
            Controls.Add(tbDirector);
            Controls.Add(tbGenere);
            Controls.Add(tbTitol);
            Controls.Add(lbPuntuacio);
            Controls.Add(lbAny);
            Controls.Add(lbDirector);
            Controls.Add(lbGenere);
            Controls.Add(lbTitol);
            Controls.Add(btInsertar);
            Name = "FormulariInsert";
            Text = "FormulariInsert";
            Load += FormulariInsert_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btInsertar;
        private Label lbTitol;
        private Label lbGenere;
        private Label lbDirector;
        private Label lbAny;
        private Label lbPuntuacio;
        private TextBox tbTitol;
        private TextBox tbGenere;
        private TextBox tbDirector;
        private TextBox tbAny;
        private TextBox tbPuntuacio;
    }
}