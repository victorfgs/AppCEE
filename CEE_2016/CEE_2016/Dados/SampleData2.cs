using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;



namespace CEE_2016.Info
{

    public class SampleDataItem2
    {
        public SampleDataItem2(String uniqueId, String title, String subtitle, String imagePath, String description, String content)
        {
            this.nome = uniqueId;
            this.desc = title;
            this.diretoria= subtitle;
            this.urlFoto = description;
            
        }

        public string nome { get; private set; }
        public string desc { get; private set; }
        public string diretoria { get; private set; }
        public string urlFoto { get; private set; }
        

        public override string ToString()
        {
            return this.nome;
        }
    }

    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class SampleDataGroup2
    {
        public SampleDataGroup2(String uniqueId, String nome, String email, String curso)
        {
            this.nome = uniqueId;
            this.diretoria = nome;
            this.desc = email;
            this.urlFoto = curso;
            
        }

        public string nome { get; private set; }
        public string diretoria{ get; private set; }
        public string desc { get; private set; }
        public string urlFoto { get; private set; }
        
        //public ObservableCollection<SampleDataItem> Items { get; private set; }

        public override string ToString()
        {
            return this.nome;
        }
    }

    /// <summary>
    /// Creates a collection of groups and items with content read from a static json file.
    /// 
    /// SampleDataSource initializes with data read from a static json file included in the 
    /// project.  This provides sample data at both design-time and run-time.
    /// </summary>
    public sealed class SampleDataSource2
    {
        private static SampleDataSource2 _sampleDataSource = new SampleDataSource2();

        private ObservableCollection<SampleDataGroup2> _groups = new ObservableCollection<SampleDataGroup2>();
        public ObservableCollection<SampleDataGroup2> Groups
        {
            get { return this._groups; }
        }

        public static async Task<IEnumerable<SampleDataGroup2>> GetGroupsAsync()
        {
            await _sampleDataSource.GetSampleDataAsync();

            return _sampleDataSource.Groups;
        }



        private async Task GetSampleDataAsync()
        {
            if (this._groups.Count != 0)
                return;

            Uri dataUri = new Uri("ms-appx:///Dados/Infos.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["Projetos"].GetArray();

            foreach (JsonValue groupValue in jsonArray)
            {
                JsonObject groupObject = groupValue.GetObject();
                SampleDataGroup2 grupo = new SampleDataGroup2( groupObject["nome"].GetString(),
                                                            groupObject["desc"].GetString(),
                                                            groupObject["diretoria"].GetString(),
                                                            groupObject["urlFoto"].GetString() );
            }
            

        }
    }
}