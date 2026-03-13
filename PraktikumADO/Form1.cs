using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PraktikumADO
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Koneksi()
        {

            conn = new SqlConnection(
                "Data Source=MSI\\UNKNOWNMEMBER; Initial Catalog=DBAkademikADO; Integrated Security=True"
            );
        }

        // Praktikum 1
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                MessageBox.Show("Koneksi ke database berhasil");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Praktikum 2
        private void btnHitungMhs_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "SELECT COUNT(*) FROM Mahasiswa";
                cmd = new SqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();

                MessageBox.Show("Jumlah Mahasiswa: " + jumlah.ToString());

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Praktikum 3
        private void btnHitungMK_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "SELECT COUNT(*) FROM MataKuliah";
                cmd = new SqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();

                MessageBox.Show("Jumlah Mata Kuliah: " + jumlah.ToString());

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Praktikum 4
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "UPDATE Mahasiswa SET Alamat='Yogyakarta' WHERE NIM='23110100001'";
                cmd = new SqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();
                MessageBox.Show("Jumlah baris terpengaruh : " + hasil);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // Latihan 1: Menghitung Jumlah Dosen
        private void btnLatihan1_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "SELECT COUNT(*) FROM Dosen"; //
                cmd = new SqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar(); // [cite: 88]

                MessageBox.Show("Jumlah Dosen: " + jumlah.ToString());
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Latihan 2: Update SKS Mata Kuliah
        private void btnLatihan2_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "UPDATE MataKuliah SET SKS = 4 WHERE KodeMK = 'IF210101'"; //
                cmd = new SqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery(); //

                MessageBox.Show("Update SKS Berhasil! Baris terpengaruh: " + hasil);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Latihan 3: Insert Program Studi
        private void btnLatihan3_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "INSERT INTO ProgramStudi VALUES ('MI01','Manajemen Informatika')"; //
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery(); //

                MessageBox.Show("Data Program Studi Berhasil Ditambahkan!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}