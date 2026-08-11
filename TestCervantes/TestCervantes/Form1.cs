using Npgsql;
using TestCervantes.Repositorios;

namespace TestCervantes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var veiculoRepositorio = new VeiculoRepositorio();
            GetVeiculos(veiculoRepositorio);

            var marcaRepositorio = new MarcaRepositorio();
            BuscarTodasAsMarcas(marcaRepositorio);
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtModelo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtAno_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtMarcaCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private bool ValidarDados()
        {
            // fiz umas confirmações antes de continuar o restante do codigo pra tentar cobrir possiveis erros
            if (string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                MessageBox.Show(
                    "Informe a placa do veiculo.",
                    "Campo obrigatório",
                    MessageBoxButtons.OK
                );

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MessageBox.Show(
                    "Informe o modelo do veículo.",
                    "Campo obrigatório",
                    MessageBoxButtons.OK
                );

                return false;
            }

            if (!int.TryParse(txtMarcaCodigo.Text, out _))
            {
                MessageBox.Show(
                    "O código da marca deve ser um numero",
                    "Código inválido",
                    MessageBoxButtons.OK
                );

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAno.Text))
            {
                MessageBox.Show(
                    "Informe o ano do veículo.",
                    "Campo obrigatório",
                    MessageBoxButtons.OK
                );

                return false;
            }

            if (!int.TryParse(txtAno.Text, out int ano))
            {
                MessageBox.Show(
                    "Use apenas numeros, ex: 2026",
                    "Ano inválido",
                    MessageBoxButtons.OK
                );

                return false;
            }

            if (ano < 1950 || ano > DateTime.Now.Year)
            {
                MessageBox.Show(
                    $"O ano deve estar entre 1950 e {DateTime.Now.Year}.",
                    "Ano inválido",
                    MessageBoxButtons.OK
                );

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMarcaCodigo.Text))
            {
                MessageBox.Show(
                    "Informe o código da marca.",
                    "Campo obrigatório",
                    MessageBoxButtons.OK
                );

                return false;
            }

            return true;
        }

        private void ValidarBanco(PostgresException ex)
        {
            if (ex.SqlState == "23503")
            {
                MessageBox.Show(
                    "O código da marca informado não existe. Por favor, insira um código de marca válido.",
                    "Marca inválida",
                    MessageBoxButtons.OK
                );
            }
            else if (ex.SqlState == "23505")
            {
                MessageBox.Show(
                    "Já existe um veículo com a placa informada.",
                    "Placa duplicada",
                    MessageBoxButtons.OK
                );
            }
            else if (ex.SqlState == "23514")
            {
                MessageBox.Show(
                    "Os dados fornecidos não atendem aos critérios de validação.",
                    "Dados inválidos",
                    MessageBoxButtons.OK
                );
            }
            
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            try
            {
                if (!ValidarDados())
                {
                    return;
                }

                Veiculo veiculo;

                if (cbmTipoVeiculo.Text == "CARRO")
                {
                    veiculo = new Carro(
                        0,
                        txtPlaca.Text,
                        txtModelo.Text,
                        Convert.ToInt32(txtAno.Text),
                        Convert.ToInt32(txtMarcaCodigo.Text)
                    );
                }
                else if (cbmTipoVeiculo.Text == "MOTO")
                {
                    veiculo = new Moto(
                        0,
                        txtPlaca.Text,
                        txtModelo.Text,
                        Convert.ToInt32(txtAno.Text),
                        Convert.ToInt32(txtMarcaCodigo.Text)
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Selecione o tipo de veículo.",
                        "Tipo obrigatório",
                        MessageBoxButtons.OK
                    );

                    return;
                }

                var veiculoRepositorio = new VeiculoRepositorio();

                veiculoRepositorio.Create(veiculo);

                LimparCampos();
                GetVeiculos(veiculoRepositorio);
            }

            // fiz algumas mensagens para o tratamento de alguns possiveis erros
            catch (PostgresException ex)
            {
                ValidarBanco(ex);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    MessageBox.Show(
                        "Informe o código do veículo.",
                        "Campo obrigatório",
                        MessageBoxButtons.OK
                    );

                    return;
                }

                if (!ValidarDados())
                {
                    return;
                }

                Veiculo veiculo;

                if (cbmTipoVeiculo.Text == "CARRO")
                {
                    veiculo = new Carro(
                        Convert.ToInt32(txtCodigo.Text),
                        txtPlaca.Text,
                        txtModelo.Text,
                        Convert.ToInt32(txtAno.Text),
                        Convert.ToInt32(txtMarcaCodigo.Text)
                    );
                }
                else if (cbmTipoVeiculo.Text == "MOTO")
                {
                    veiculo = new Moto(
                        Convert.ToInt32(txtCodigo.Text),
                        txtPlaca.Text,
                        txtModelo.Text,
                        Convert.ToInt32(txtAno.Text),
                        Convert.ToInt32(txtMarcaCodigo.Text)
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Selecione o tipo de veículo.",
                        "Tipo obrigatório",
                        MessageBoxButtons.OK
                    );

                    return;
                }

                var veiculoRepositorio = new VeiculoRepositorio();
                veiculoRepositorio.Update(veiculo);
                LimparCampos();
                GetVeiculos(veiculoRepositorio);
            }
            catch (PostgresException ex)
            {
                ValidarBanco(ex);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    MessageBox.Show(
                        "Selecione um veiculo para remover",
                        "Veiculo não selecionado",
                        MessageBoxButtons.OK
                    );

                    return;
                }

                var veiculoRepositorio = new VeiculoRepositorio();
                veiculoRepositorio.Delete(Convert.ToInt32(txtCodigo.Text));
                LimparCampos();
                GetVeiculos(veiculoRepositorio);
            }
            catch (PostgresException ex)
            {
                ValidarBanco(ex);
            }
        }

        private void dgVeiculo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LimparCampos()
        {
            txtCodigo.Text = string.Empty;
            txtPlaca.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtAno.Text = string.Empty;
            txtMarcaCodigo.Text = string.Empty;
            cbmTipoVeiculo.Text = string.Empty;
        }

        private void GetVeiculos(VeiculoRepositorio veiculoRepositorio)
        {
            var veiculos = veiculoRepositorio.GetAll();
            dgVeiculo.DataSource = veiculos;
        }

        private void dgVeiculo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;

            txtCodigo.Text = dgv.CurrentRow.Cells["codigo"]?.Value?.ToString();
            txtPlaca.Text = dgv.CurrentRow.Cells["placa"]?.Value?.ToString();
            txtModelo.Text = dgv.CurrentRow.Cells["modelo"]?.Value?.ToString();
            txtAno.Text = dgv.CurrentRow.Cells["ano"]?.Value?.ToString();
            txtMarcaCodigo.Text = dgv.CurrentRow.Cells["marcaCodigo"]?.Value?.ToString();
            cbmTipoVeiculo.Text = dgv.CurrentRow.Cells["tipo"]?.Value?.ToString();
        }

        private void cbmTipoVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        // MARCA
        private void txtCodMarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void LimparCamposMarca()
        {
            txtCodMarca.Text = string.Empty;
            txtMarca.Text = string.Empty;
        }

        private void BuscarTodasAsMarcas(MarcaRepositorio marcaRepositorio)
        {
            var marcas = marcaRepositorio.GetAllMarca();
            dgMarca.DataSource = marcas.ToList();
        }

        private void dgMarca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddMarca_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show(
                    "Informe o nome da marca.",
                    "Campo obrigatório",
                    MessageBoxButtons.OK
                );

                return;
            }
            try
            {
                var marca = new Marca(0, txtMarca.Text);
                var marcaRepositorio = new MarcaRepositorio();
                marcaRepositorio.InserirMarca(marca);
                LimparCamposMarca();
                BuscarTodasAsMarcas(marcaRepositorio);
            }
            catch (PostgresException ex)
            {
                if (ex.SqlState == "23505")
                {
                    MessageBox.Show(
                        "Já existe uma marca com o nome informado.",
                        "Marca duplicada",
                        MessageBoxButtons.OK
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Ocorreu um erro ao adicionar a marca.",
                        "Erro",
                        MessageBoxButtons.OK
                    );
                }
            }

        }

        private void btnRemoverMarca_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodMarca.Text))
                {
                    MessageBox.Show(
                        "Selecione uma marca para remover",
                        "Marca não selecionada",
                        MessageBoxButtons.OK
                        );
                    return;
                }
                var marcaRepositorio = new MarcaRepositorio();
                marcaRepositorio.DeletarMarca(Convert.ToInt32(txtCodMarca.Text));
                LimparCamposMarca();
                BuscarTodasAsMarcas(marcaRepositorio);
            }
            catch (PostgresException ex)
            {
                ValidarBanco(ex);
            }
            
        }

        private void dgMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtCodMarca.Text = dgMarca.Rows[e.RowIndex]
                .Cells["codigo"].Value?.ToString();

            txtMarca.Text = dgMarca.Rows[e.RowIndex]
                .Cells["nome"].Value?.ToString();
        }

        private void btnEditarMarca_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodMarca.Text))
            {
                MessageBox.Show(
                    "Selecione uma marca para editar",
                    "Marca não selecionada",
                    MessageBoxButtons.OK
                    );
                return;
            }
            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                MessageBox.Show(
                    "Informe o nome da marca",
                    "Campo obrigatório",
                    MessageBoxButtons.OK
                    );
                return;
            }
            try
            {
                var marca = new Marca(Convert.ToInt32(txtCodMarca.Text), txtMarca.Text);
                var marcaRepositorio = new MarcaRepositorio();
                marcaRepositorio.AtualizarMarca(marca);
                LimparCamposMarca();
                BuscarTodasAsMarcas(marcaRepositorio);
            }
            catch (PostgresException ex)
            {
                if (ex.SqlState == "23505")
                {
                    MessageBox.Show(
                        "Ja existe uma marca com esse nome",
                        "Marca ja existente",
                        MessageBoxButtons.OK
                        );
                }
            }
        }
    }
}
    