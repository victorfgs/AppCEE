using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace CEE_2016.Classes_Comuns
{
    class Diretoria
    {
       
        private string nome { get; set; }
        private string desc { get; set; }
        private string urlFoto { get; set; }
        //private List<Colaborador> listaColaboradores;


        public Diretoria(string nome, string desc, string urlFoto)
        {
            this.nome = nome;
            this.desc = desc;
            this.urlFoto = urlFoto ;

        }
    }
}
