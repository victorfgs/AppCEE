using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEE_2016.Classes_Comuns;
using Facebook;

namespace CEE_2016.Classes_Comuns
{
    class DadosFacebook
    {
        public bool RecolheInformações()
        {
            bool Aux = false;
            Conexao objConexao = new Conexao();
            if (objConexao.verificaConexao())
            {

                
                Aux=true;
            }
            else
            {
                Aux= false;
            }
            return Aux;
        }


    }
}
