using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.vo
{
    internal class EstagioDias
    {
        private int id;
        private DateTime data;
        private string descricao;
        private DateTime horaIni;
        private DateTime horaFin;
        private DateTime totalHoras;

        public int Id { get => id; set => id = value; }
        public DateTime Data { get => data; set => data = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public DateTime HoraIni { get => horaIni; set => horaIni = value; }
        public DateTime HoraFin { get => horaFin; set => horaFin = value; }
        public DateTime TotalHoras { get => totalHoras; set => totalHoras = value; }
    }
}
