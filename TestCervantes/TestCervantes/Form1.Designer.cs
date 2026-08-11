namespace TestCervantes
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgVeiculo = new DataGridView();
            label1 = new Label();
            txtCodigo = new TextBox();
            txtPlaca = new TextBox();
            label2 = new Label();
            txtModelo = new TextBox();
            label3 = new Label();
            txtAno = new TextBox();
            label4 = new Label();
            txtMarcaCodigo = new TextBox();
            label5 = new Label();
            btnAdicionar = new Button();
            btnEditar = new Button();
            btnRemover = new Button();
            cbmTipoVeiculo = new ComboBox();
            label6 = new Label();
            btnRemoverMarca = new Button();
            btnEditarMarca = new Button();
            btnAddMarca = new Button();
            Codigo = new Label();
            txtCodMarca = new TextBox();
            txtMarca = new TextBox();
            label8 = new Label();
            dgMarca = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgVeiculo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgMarca).BeginInit();
            SuspendLayout();
            // 
            // dgVeiculo
            // 
            dgVeiculo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgVeiculo.Location = new Point(12, 318);
            dgVeiculo.Name = "dgVeiculo";
            dgVeiculo.RowHeadersWidth = 51;
            dgVeiculo.Size = new Size(861, 290);
            dgVeiculo.TabIndex = 0;
            dgVeiculo.CellClick += dgVeiculo_CellClick;
            dgVeiculo.CellContentClick += dgVeiculo_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 1;
            label1.Text = "Codigo";
            label1.Click += label1_Click;
            // 
            // txtCodigo
            // 
            txtCodigo.Enabled = false;
            txtCodigo.Location = new Point(12, 43);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(197, 27);
            txtCodigo.TabIndex = 2;
            txtCodigo.TextChanged += txtCodigo_TextChanged;
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(12, 97);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(197, 27);
            txtPlaca.TabIndex = 4;
            txtPlaca.TextChanged += txtPlaca_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 74);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 3;
            label2.Text = "Placa";
            label2.Click += label2_Click;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(12, 156);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(197, 27);
            txtModelo.TabIndex = 6;
            txtModelo.TextChanged += txtModelo_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 133);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 5;
            label3.Text = "Modelo";
            label3.Click += label3_Click;
            // 
            // txtAno
            // 
            txtAno.Location = new Point(12, 221);
            txtAno.Name = "txtAno";
            txtAno.Size = new Size(197, 27);
            txtAno.TabIndex = 8;
            txtAno.TextChanged += txtAno_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 198);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 7;
            label4.Text = "Ano";
            label4.Click += label4_Click;
            // 
            // txtMarcaCodigo
            // 
            txtMarcaCodigo.Location = new Point(12, 276);
            txtMarcaCodigo.Name = "txtMarcaCodigo";
            txtMarcaCodigo.Size = new Size(197, 27);
            txtMarcaCodigo.TabIndex = 10;
            txtMarcaCodigo.TextChanged += txtMarcaCodigo_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 253);
            label5.Name = "label5";
            label5.Size = new Size(126, 20);
            label5.TabIndex = 9;
            label5.Text = "Código Da Marca";
            label5.Click += label5_Click;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(307, 274);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(94, 29);
            btnAdicionar.TabIndex = 11;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(421, 274);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(545, 274);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(94, 29);
            btnRemover.TabIndex = 13;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += btnRemover_Click;
            // 
            // cbmTipoVeiculo
            // 
            cbmTipoVeiculo.FormattingEnabled = true;
            cbmTipoVeiculo.Items.AddRange(new object[] { "MOTO", "CARRO" });
            cbmTipoVeiculo.Location = new Point(225, 42);
            cbmTipoVeiculo.Name = "cbmTipoVeiculo";
            cbmTipoVeiculo.Size = new Size(149, 28);
            cbmTipoVeiculo.TabIndex = 14;
            cbmTipoVeiculo.SelectedIndexChanged += cbmTipoVeiculo_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(225, 19);
            label6.Name = "label6";
            label6.Size = new Size(113, 20);
            label6.TabIndex = 15;
            label6.Text = "Tipo do Veiculo";
            // 
            // btnRemoverMarca
            // 
            btnRemoverMarca.Location = new Point(1299, 124);
            btnRemoverMarca.Name = "btnRemoverMarca";
            btnRemoverMarca.Size = new Size(94, 29);
            btnRemoverMarca.TabIndex = 18;
            btnRemoverMarca.Text = "Remover";
            btnRemoverMarca.UseVisualStyleBackColor = true;
            btnRemoverMarca.Click += btnRemoverMarca_Click;
            // 
            // btnEditarMarca
            // 
            btnEditarMarca.Location = new Point(1155, 124);
            btnEditarMarca.Name = "btnEditarMarca";
            btnEditarMarca.Size = new Size(94, 29);
            btnEditarMarca.TabIndex = 17;
            btnEditarMarca.Text = "Editar";
            btnEditarMarca.UseVisualStyleBackColor = true;
            btnEditarMarca.Click += btnEditarMarca_Click_1;
            // 
            // btnAddMarca
            // 
            btnAddMarca.Location = new Point(1012, 124);
            btnAddMarca.Name = "btnAddMarca";
            btnAddMarca.Size = new Size(94, 29);
            btnAddMarca.TabIndex = 16;
            btnAddMarca.Text = "Adicionar";
            btnAddMarca.UseVisualStyleBackColor = true;
            btnAddMarca.Click += btnAddMarca_Click;
            // 
            // Codigo
            // 
            Codigo.AutoSize = true;
            Codigo.Location = new Point(1012, 19);
            Codigo.Name = "Codigo";
            Codigo.Size = new Size(58, 20);
            Codigo.TabIndex = 20;
            Codigo.Text = "Codigo";
            // 
            // txtCodMarca
            // 
            txtCodMarca.Enabled = false;
            txtCodMarca.Location = new Point(1012, 43);
            txtCodMarca.Name = "txtCodMarca";
            txtCodMarca.Size = new Size(206, 27);
            txtCodMarca.TabIndex = 21;
            txtCodMarca.TextChanged += txtCodMarca_TextChanged;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(1275, 43);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(206, 27);
            txtMarca.TabIndex = 23;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1275, 19);
            label8.Name = "label8";
            label8.Size = new Size(116, 20);
            label8.TabIndex = 22;
            label8.Text = "Nome da Marca";
            // 
            // dgMarca
            // 
            dgMarca.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgMarca.Location = new Point(1012, 159);
            dgMarca.Name = "dgMarca";
            dgMarca.RowHeadersWidth = 51;
            dgMarca.Size = new Size(709, 290);
            dgMarca.TabIndex = 24;
            dgMarca.CellClick += dgMarca_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1744, 774);
            Controls.Add(dgMarca);
            Controls.Add(txtMarca);
            Controls.Add(label8);
            Controls.Add(txtCodMarca);
            Controls.Add(Codigo);
            Controls.Add(btnRemoverMarca);
            Controls.Add(btnEditarMarca);
            Controls.Add(btnAddMarca);
            Controls.Add(label6);
            Controls.Add(cbmTipoVeiculo);
            Controls.Add(btnRemover);
            Controls.Add(btnEditar);
            Controls.Add(btnAdicionar);
            Controls.Add(txtMarcaCodigo);
            Controls.Add(label5);
            Controls.Add(txtAno);
            Controls.Add(label4);
            Controls.Add(txtModelo);
            Controls.Add(label3);
            Controls.Add(txtPlaca);
            Controls.Add(label2);
            Controls.Add(txtCodigo);
            Controls.Add(label1);
            Controls.Add(dgVeiculo);
            Name = "Form1";
            Text = " Crud de Veiculos";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgVeiculo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgMarca).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgVeiculo;
        private Label label1;
        private TextBox txtCodigo;
        private TextBox txtPlaca;
        private Label label2;
        private TextBox txtModelo;
        private Label label3;
        private TextBox txtAno;
        private Label label4;
        private TextBox txtMarcaCodigo;
        private Label label5;
        private Button btnAdicionar;
        private Button btnEditar;
        private Button btnRemover;
        private ComboBox comboBox1;
        private Label label6;
        private ComboBox cb;
        private ComboBox cbTipoVeiculo;
        private ComboBox cbmTipoVeiculo;
        private Button btnRemoverMarca;
        private Button btnEditarMarca;
        private Button btnAddMarca;
        private Label Codigo;
        private TextBox txtCodMarca;
        private TextBox txtMarca;
        private Label label8;
        private DataGridView dgMarca;
    }
}
