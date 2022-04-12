using Controle_Estagio.vo;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Controle_Estagio.bd
{
    internal class BdEstagio : Bd
    {
        BdAluno bdAluno;
        public BdEstagio()
        {
            User = "root";
            Servidor = "localhost";
            Senha = "vertrigo";
            bd = "estagio";

            bdAluno = new BdAluno();
        }

        public DataTable PreencheTabela()
        {
            int id = bdAluno.getIdAluno();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            DataTable estagio = new DataTable();
            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from estagiodias where idAluno = @idAluno order by data";
                cmd.Parameters.AddWithValue("@idAluno", id);
                cmd.Connection = Connection;
                da.SelectCommand = cmd;
                da.Fill(estagio);
                Fechar();
                return estagio;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public void salva(EstagioDias e)
        {
            inserir(e);
            if (VerificaHoras(e))
                atualizaHoras(e);
            else
                inserirHoras(e);
        }

        private void inserir(EstagioDias e)
        {
            int id = bdAluno.getIdAluno();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into estagiodias (id, data, descricao, horaIni, horaFin, idAluno) values (@id, @data, @descricao, @horaIni, @horaFin, @idAluno)";
                cmd.Parameters.AddWithValue("@id", e.Id);
                cmd.Parameters.AddWithValue("@data", e.Data);
                cmd.Parameters.AddWithValue("@descricao", e.Descricao);
                cmd.Parameters.AddWithValue("@horaIni", e.HoraIni);
                cmd.Parameters.AddWithValue("@horaFin", e.HoraFin);
                cmd.Parameters.AddWithValue("@idAluno", id);
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

        private void inserirHoras(EstagioDias e)
        {
            int id = bdAluno.getIdAluno();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into horas (id, total, idAluno) values (@id, @horas, @idAluno)";
                cmd.Parameters.AddWithValue("@id", e.Id);
                cmd.Parameters.AddWithValue("@horas", e.HoraFin - e.HoraIni);
                cmd.Parameters.AddWithValue("@idAluno", id);
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
            int id = bdAluno.getIdAluno();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                somaHora(e);
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update horas set total = @horas where idAluno = @idAluno";
                cmd.Parameters.AddWithValue("@horas", e.TotalHoras.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("@idAluno", id);
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

        public void deletar(int idEstagio, TimeSpan horaIni, TimeSpan horaFin)
        {
            int idAluno = bdAluno.getIdAluno();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                atualizaHorasSubtrai(horaIni, horaFin);
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from estagiodias where id = @id and idAluno = @idAluno";
                cmd.Parameters.AddWithValue("@idAluno", idAluno);
                cmd.Parameters.AddWithValue("@id", idEstagio);
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

        private void atualizaHorasSubtrai(TimeSpan horaIni, TimeSpan horaFin)
        {
            int id = bdAluno.getIdAluno();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                DateTime novaHora = DateTime.Parse(subtraiHoras(horaIni, horaFin).ToString());
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update horas set total = @horas where idAluno = @idAluno";
                cmd.Parameters.AddWithValue("@horas", novaHora.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("@idAluno", id); ;
                cmd.Connection = Connection;
                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();
                Fechar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "opa2");
            }
        }

        private TimeSpan subtraiHoras(TimeSpan horaIni, TimeSpan horaFin)
        {
            int id = bdAluno.getIdAluno();
            TimeSpan ts = horaFin - horaIni;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            DataTable horaBd = new DataTable();

            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select total from horas where idAluno = @idAluno";
                cmd.Parameters.AddWithValue("@idAluno", id);
                cmd.Connection = Connection;
                da.SelectCommand = cmd;
                da.Fill(horaBd);
                Fechar();
                String hora = (horaBd.Rows[0].ItemArray[0]).ToString();
                if (hora != null)
                {
                    TimeSpan horaTs = TimeSpan.Parse(hora);
                    ts -= horaTs;
                    return -ts;
                }
                else
                {
                    return TimeSpan.Parse("00:00:00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return TimeSpan.Parse("00:00:00");
            }
        }

        private void somaHora(EstagioDias e)
        {
            int id = bdAluno.getIdAluno();
            TimeSpan ts = e.HoraFin - e.HoraIni;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            DataTable horaBd = new DataTable();

            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select total from horas where idAluno = @idAluno";
                cmd.Parameters.AddWithValue("@idAluno", id);
                cmd.Connection = Connection;
                da.SelectCommand = cmd;
                da.Fill(horaBd);
                Fechar();
                String hora = (horaBd.Rows[0].ItemArray[0]).ToString();
                if (hora != null)
                {
                    TimeSpan horaTs = TimeSpan.Parse(hora);
                    ts += horaTs;
                    e.TotalHoras = DateTime.Parse(ts.ToString());
                }
                else
                {
                    e.TotalHoras = DateTime.Parse("00:00:00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool VerificaHoras(EstagioDias e)
        {
            int id = bdAluno.getIdAluno();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            DataTable qtd = new DataTable();
            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM horas where idAluno = @idAluno";
                cmd.Parameters.AddWithValue("@idAluno", id);
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
            int id = bdAluno.getIdAluno();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            DataTable totalHoras = new DataTable();
            try
            {
                Abrir();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select total from horas where idAluno = @idAluno";
                cmd.Parameters.AddWithValue("@idAluno", id);
                cmd.Connection = Connection;
                da.SelectCommand = cmd;
                da.Fill(totalHoras);
                Fechar();
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
