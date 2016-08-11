using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEE_2016.Classes_Comuns
{
    class Projeto
    {
        public string nome { get; set; }
        public string diretoria { get; set; }
        public string desc { get; set; }
        public string urlFoto { get; set; }


        public Projeto(string nome, string diretoria, string descricao, string urlFoto)
        {
            this.nome = nome;
            this.diretoria = diretoria;
            this.desc = descricao;
            this.urlFoto = urlFoto;
        }
    }
}
