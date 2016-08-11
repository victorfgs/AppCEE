using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;

namespace CEE_2016.ViewModel
{
    public class designProjetos
    {
        public designProjetos(String uniqueId, String nome, String email, String curso)
        {
            this.nome = uniqueId;
            this.diretoria = nome;
            this.desc = email;
            this.urlFoto = curso;

        }

        public string nome { get; private set; }
        public string diretoria { get; private set; }
        public string desc { get; private set; }
        public string urlFoto { get; private set; }

        public override string ToString()
        {
            return this.nome;
        }
    }
    public class designColaboradores
    {
        public designColaboradores(String uniqueId, String nome, String email, String curso, String urlFoto, string diretoria)
        {
            this.id = uniqueId;
            this.nome = nome;
            this.email = email;
            this.curso = curso;
            this.urlFoto = urlFoto;
            this.diretoria = diretoria;
        }

        public string id { get; private set; }
        public string nome { get; private set; }
        public string email { get; private set; }
        public string curso { get; private set; }
        public string urlFoto { get; private set; }
        public string diretoria { get; private set; }

        public override string ToString()
        {
            return this.nome;
        }
    }

    public sealed class projetosDataSource
    {
        private static projetosDataSource _projetoDataSource=new projetosDataSource();
        private ObservableCollection<designProjetos> _projetos = new ObservableCollection<designProjetos>();
        public ObservableCollection<designProjetos> Projetos
        {
            get { return this._projetos; }
        }

        public static async Task<IEnumerable<designProjetos>> GetGroupsAsync()
        {
            await _projetoDataSource.PegaInfosProjetos();

            return _projetoDataSource.Projetos;
        }

        private async Task PegaInfosProjetos()
        {
            if (this._projetos.Count != 0)
                return;

            Uri dataUri = new Uri("ms-appx:///Dados/Infos.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["Projetos"].GetArray();

            foreach (JsonValue groupValue in jsonArray)
            {
                JsonObject groupObject = groupValue.GetObject();
                designProjetos grupo = new designProjetos(groupObject["nome"].GetString(),
                                                            groupObject["desc"].GetString(),
                                                            groupObject["diretoria"].GetString(),
                                                            groupObject["urlFoto"].GetString());
            }


        }

    }
    public sealed class colaboradoresDataSource
    {
        private static colaboradoresDataSource _colaboradoresDataSource = new colaboradoresDataSource();
        private ObservableCollection<designColaboradores> _colaboradores = new ObservableCollection<designColaboradores>();
        public ObservableCollection<designColaboradores> Colaboradores
        {
            get { return this._colaboradores; }
        }

        public static async Task<IEnumerable<designColaboradores>> GetGroupsAsync()
        {
            await _colaboradoresDataSource.PegaInfosColaboradores();

            return _colaboradoresDataSource.Colaboradores;
        }

        private async Task PegaInfosColaboradores()
        {
            if (this._colaboradores.Count != 0)
                return;

            Uri dataUri = new Uri("ms-appx:///Dados/Infos.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["Colaboradores"].GetArray();

            foreach (JsonValue groupValue in jsonArray)
            {
                JsonObject groupObject = groupValue.GetObject();
                designColaboradores grupo = new designColaboradores(groupObject["id"].GetString(),
                                                            groupObject["nome"].GetString(),
                                                            groupObject["email"].GetString(),
                                                            groupObject["curso"].GetString(),
                                                            groupObject["urlFoto"].GetString(),
                                                            groupObject["diretoria"].GetString()
                                                             );
            }


        }
    }
}
