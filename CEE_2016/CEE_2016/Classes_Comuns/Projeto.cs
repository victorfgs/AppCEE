using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEE_2016.Classes_Comuns
{
    class Projeto
    {
        private string nome { get; set; }
        private string diretoria { get; set; }
        private string descricao { get; set; }
        private string urlFoto { get; set; }


        public Projeto(string nome, string diretoria, string descricao, string urlFoto)
        {
            this.nome = nome;
            this.diretoria = diretoria;
            this.descricao = descricao;
            this.urlFoto = urlFoto;
        }
    }
}
