using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;

namespace CEE_2016.Classes_Comuns
{
    class Colaboradores
    {
        private List<Colaborador> listaColaboradores;

        public string  pegaColaboradores()
        {

            string Aux = "ms-appx:///Infos.json";
            Uri uriArquivo = new Uri(Aux);
            StorageFile anjFile= StorageFile.GetFileFromApplicationUriAsync(uriArquivo).AsTask().ConfigureAwait(false).GetAwaiter().GetResult();
            string jsonText = FileIO.ReadTextAsync(anjFile).AsTask().ConfigureAwait(false).GetAwaiter().GetResult();
            JsonObject jobjArquivo=JsonObject.Parse(jsonText);
            //TO-DO: Substituir caminho do arquivo para o site do CEE
            var jobjColaboradores =jobjArquivo["colaboradores"];

            return jobjColaboradores.ToString();
        }
    }
}
