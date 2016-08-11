using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;

namespace CEE_2016.Classes_Comuns
{
    class App_Geral
    {
        public bool conectado;
        public string TESTE;
        public List<Colaborador>listaColaboradores;
        public List<Projeto>listaProjetos;
        public List<Evento> listaEventos;
        public List<Diretoria> listaDiretoria;
        private string caminhoInfos = "ms-appx:///Dados/Infos.json";

        //Construtor
        //1º: Verificar conexao com a internet
        //2º: Abrir arquivo .json com informações pertinentes ao app
        //3º: Popular membros da classe com infos do arquivo json
        //4º: Carregar infos na Page
        public App_Geral()
        {
            this.listaColaboradores = new List<Colaborador>();
            this.listaProjetos= new List<Projeto>();
            this.listaEventos = new List<Evento>();
            this.listaDiretoria = new List<Diretoria>();

            this.testaConexao();
            if (this.conectado)
            {
                Uri uriArquivo = new Uri(this.caminhoInfos);
                StorageFile anjFile = StorageFile.GetFileFromApplicationUriAsync(uriArquivo).AsTask().ConfigureAwait(false).GetAwaiter().GetResult();
                string jsonText = FileIO.ReadTextAsync(anjFile).AsTask().ConfigureAwait(false).GetAwaiter().GetResult();
                JsonObject jArquivo= JsonObject.Parse(jsonText).GetObject();
                
                this.populaDiretorias(jArquivo.GetNamedArray("diretorias"));
                this.populaColaboradores(jArquivo.GetNamedArray("colaboradores"));
                this.populaEventos(jArquivo.GetNamedArray("eventos"));
                this.populaProjetos(jArquivo.GetNamedArray("projetos"));
                


            }
            else
            {

            }


        }
        public void populaProjetos(JsonArray jArrProjetos)
        {


            foreach (var item in jArrProjetos)
            {
                JsonObject result = item.GetObject();
                this.listaProjetos.Add(new Projeto(result["nome"].GetString(), 
                                                    result["diretoria"].GetString(), 
                                                    result["desc"].GetString(), 
                                                    result["urlFoto"].GetString()));
                //this.TESTE = result["nome"].ToString();

            }

        }
        public void populaEventos(JsonArray jArrEventos)
        {


            foreach (var item in jArrEventos)
            {
                JsonObject result = item.GetObject();
                this.listaEventos.Add(new Evento(result["nome"].ToString(), result["desc"].ToString(), result["urlFoto"].ToString(), result["textoCompleto"].ToString()));
                //this.TESTE = result["nome"].ToString();

            }

        }
        public void populaDiretorias(JsonArray jArrDirs)
        {
            

            foreach (var item in jArrDirs)
            {
                JsonObject result = item.GetObject();
                this.listaDiretoria.Add(new Diretoria(result["nome"].ToString(), result["desc"].ToString(), result["urlFoto"].ToString()));
                //this.TESTE = result["nome"].ToString();

            }
            
        }

        public void populaColaboradores(JsonArray jArrColaboradores)
        {
            foreach (var item in jArrColaboradores)
            {
                JsonObject result = item.GetObject();
                this.listaColaboradores.Add(new Colaborador(result["id"].ToString().Replace("\"", ""), 
                                                            result["nome"].ToString().Replace("\"", ""),    
                                                            result["email"].ToString().Replace("\"", ""), 
                                                            result["curso"].ToString().Replace("\"", ""), 
                                                            result["urlFoto"].ToString().Replace("\"",""), 
                                                            result["diretoria"].ToString().Replace("\"", "")));
                //this.TESTE = result["nome"].ToString();

            }
        }


        public void testaConexao()
        {
            bool aux=false;
            //Declara e constroi um objeto de conexao
            Conexao objConexao = new Conexao();
            //Se a conexao está ativa, abre o arquivo json e insere infos nas classes
            if (objConexao.verificaConexao())
            {
                aux = true;
            }
            else
            {
                aux = false;
            }
            this.conectado = aux;
        }


    }
}
