using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Controle_Estagio.bd
{
    internal class BdAluno : Bd
    {
        public BdAluno()
        {
            User = "root";
            Servidor = "localhost";
            Senha = "vertrigo";
            bd = "estagio";
        }

        public void atualiza(string key)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update ativacao set status = 1 where keyCode=@keyCode";
                cmd.Parameters.AddWithValue("@keyCode", key);
                cmd.Connection = Connection;
                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();
                Fechar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int getIdAluno()
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            DataTable ids = new DataTable();
            try
            {
                String keyPc;
                try
                {
                    string path = @".\key.txt";
                    StreamReader reader = new StreamReader(path);
                    keyPc = reader.ReadLine();
                }
                catch (Exception ex)
                {
                    keyPc = "";
                }
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select id from ativacao where keyCode = @keyCode";
                cmd.Parameters.AddWithValue("@keyCode", keyPc);
                cmd.Connection = Connection;
                da.SelectCommand = cmd;
                da.Fill(ids);
                Fechar();
                int idAluno = Int32.Parse(ids.Rows[0].ItemArray[0].ToString());
                return idAluno;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public bool verificaKey()
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            DataTable key = new DataTable();
            String keyPc;
            try
            {
                string path = @".\key.txt";
                StreamReader reader = new StreamReader(path);
                keyPc = reader.ReadLine();
            }
            catch (Exception ex)
            {
                keyPc = "";
            }

            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select status from ativacao where keyCode = @keyCode";
                cmd.Parameters.AddWithValue("@keyCode", keyPc);
                cmd.Connection = Connection;
                da.SelectCommand = cmd;
                da.Fill(key);
                Fechar();
                String status = (key.Rows[0].ItemArray[0]).ToString();
                if (status == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool verificaExiste(string keyDigitada)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            DataTable key = new DataTable();
            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select status from ativacao where keyCode = @keyCode";
                cmd.Parameters.AddWithValue("@keyCode", keyDigitada);
                cmd.Connection = Connection;
                da.SelectCommand = cmd;
                da.Fill(key);
                Fechar();
                String status = (key.Rows[0].ItemArray[0]).ToString();
                if (status == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public bool verificaUsando(string keyDigitada)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            DataTable key = new DataTable();
            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select status from ativacao where keyCode = @keyCode";
                cmd.Parameters.AddWithValue("@keyCode", keyDigitada);
                cmd.Connection = Connection;
                da.SelectCommand = cmd;
                da.Fill(key);
                Fechar();
                String status = (key.Rows[0].ItemArray[0]).ToString();
                if (status == "0")
                {
                    return false;
                }
                else if (status == "2")
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
