using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ResponsiEga
{
    internal class DeveloperRepository : Developer  
    {
        private const string conn = "Host = localhost; Port = 5432; Username = postgres; Password = informatika; Database = responsi";
        private static NpgsqlConnection connection;
        private static NpgsqlCommand cmd;
        private static DataTable dt;

        private DataGridView dgvData;
        private DataGridViewRow row;
        public DataGridViewRow Row { set { row = value; } }
        public DeveloperRepository(DataGridView _dgvData) { dgvData = _dgvData; }

        // Load
        public void Load()
        {
            connection = new NpgsqlConnection(conn);
            try {
                connection.Open();
                dgvData.DataSource = dt;
                dt = new DataTable();
                string sql = "SELECT * FROM dev_select()";
                cmd = new NpgsqlCommand(sql, connection);

                NpgsqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                dgvData.DataSource = dt;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
            finally { connection.Close(); }
        }
        // Insert
        public void Insert(TextBox tbNama, ComboBox cbProyek, ComboBox cbStatus, TextBox tbFitur, TextBox tbJumlah, Button btnLoad)
        {
            connection = new NpgsqlConnection(conn);
            try
            {
                connection.Open();
                string sql = "SELECT * FROM dev_insert(:_nama_dev, :_id_proyek, :_status_kontrak, :_fitur_selesai, :_jumlah_bug)";
                cmd = new NpgsqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("_nama_dev", tbNama.Text);
                cmd.Parameters.AddWithValue("_id_proyek", cbProyek.Text);
                cmd.Parameters.AddWithValue("_status_kontrak", cbStatus.Text);
                cmd.Parameters.AddWithValue("_fitur_selesai", tbFitur.Text);
                cmd.Parameters.AddWithValue("_jumlah_bug", tbJumlah.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
            finally { connection.Close(); }
        }
    }
}
