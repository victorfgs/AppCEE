using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEE_2016.Classes_Comuns
{
    class Evento
    {
        private string nome { get; set; }
        private string descricao { get; set; }
        private string urlFoto { get; set; }
        private string textoCompleto { get; set; }

        public Evento(string nome, string descricao, string urlFoto, string textoCompleto)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.urlFoto = urlFoto;
            this.textoCompleto = textoCompleto;
        }
    }
}
