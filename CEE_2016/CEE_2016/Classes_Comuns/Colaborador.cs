using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEE_2016.Classes_Comuns
{
    class Colaborador
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string curso { get; set; }
        public string urlFoto { get; set; }
        public string diretoria { get; set; }

        public Colaborador(string id, string nome, string email, string curso, string urlFoto, string diretoria)
        {
            this.id = id;
            this.nome= nome;
            this.email = email;
            this.curso = curso;
            this.urlFoto = urlFoto;
            this.diretoria = diretoria;


        }
    }
}
