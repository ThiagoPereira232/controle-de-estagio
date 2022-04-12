using MySql.Data.MySqlClient;

namespace Controle_Estagio
{
    internal class Bd
    {
        public string User;
        public string bd;
        public string Senha;
        public string Servidor;
        public MySqlConnection Connection;

        public Bd()
        {
            Connection = new MySqlConnection();
        }

        public void Abrir()
        {
            string strConnString = "server=" + Servidor + ";User id=" + User + ";password=" + Senha + ";database=" + bd + ";sslmode=none;";
            if (Connection.State == System.Data.ConnectionState.Broken || Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection = new MySqlConnection();
                Connection.ConnectionString = strConnString;
                Connection.Open();
            }
        }

        public void Fechar()
        {
            Connection.Close();
        }
    }
}
