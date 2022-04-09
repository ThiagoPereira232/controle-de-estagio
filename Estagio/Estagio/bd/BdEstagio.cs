using Estagio.vo;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Estagio.bd
{
    internal class BdEstagio : Bd
    {
        public BdEstagio()
        {
            User = "root";
            Servidor = "localhost";
            Senha = "vertrigo";
            bd = "estagio";
        }

        public DataTable PreencheTabela()
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            DataTable estagio = new DataTable();
            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from estagiodias order by data";
                cmd.Connection = Connection;
                da.SelectCommand = cmd;
                da.Fill(estagio);
                return estagio;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public void salva(EstagioDias e)
        {
            inserir(e);
            if(VerificaHoras(e))
                atualizaHoras(e);
            else
                inserirHoras(e);
        }

        private void inserir(EstagioDias e)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into estagiodias (id, data, descricao, horaIni, horaFin) values (@id, @data, @descricao, @horaIni, @horaFin)";
                cmd.Parameters.AddWithValue("@id", e.Id);
                cmd.Parameters.AddWithValue("@data", e.Data);
                cmd.Parameters.AddWithValue("@descricao", e.Descricao);
                cmd.Parameters.AddWithValue("@horaIni", e.HoraIni);
                cmd.Parameters.AddWithValue("@horaFin", e.HoraFin);
                cmd.Connection = Connection;
                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();
                Fechar();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void inserirHoras(EstagioDias e)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into horas (id, total) values (@id, @horas)";
                cmd.Parameters.AddWithValue("@id", e.Id);
                cmd.Parameters.AddWithValue("@horas", e.HoraFin - e.HoraIni);
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

        private void atualizaHoras(EstagioDias e)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                somaHora(e);
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update horas set total = @horas";
                cmd.Parameters.AddWithValue("@horas", e.TotalHoras.ToString("HH:mm:ss"));
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

        private void somaHora(EstagioDias e)
        {
            TimeSpan ts = e.HoraFin - e.HoraIni;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            DataTable horaBd = new DataTable();

            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select total from horas";
                cmd.Connection = Connection;
                da.SelectCommand = cmd;
                da.Fill(horaBd);
                Fechar();
                String hora = (horaBd.Rows[0].ItemArray[0]).ToString();
                TimeSpan horaTs = TimeSpan.Parse(hora);
                ts += horaTs;
                e.TotalHoras = DateTime.Parse(ts.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool VerificaHoras(EstagioDias e)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            DataTable qtd = new DataTable();
            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM horas";
                cmd.Connection = Connection;
                da.SelectCommand = cmd;
                da.Fill(qtd);
                Fechar();
                if (qtd.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public TimeSpan HorasFeitas()
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            DataTable totalHoras = new DataTable();
            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select total from horas";
                cmd.Connection = Connection;
                da.SelectCommand = cmd;
                da.Fill(totalHoras);
                if (totalHoras.Rows.Count > 0)
                    return TimeSpan.Parse(totalHoras.Rows[0].ItemArray[0].ToString());
                else
                    return TimeSpan.Parse("00:00:00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return TimeSpan.Parse("00:00:00");
        }
    }
}
