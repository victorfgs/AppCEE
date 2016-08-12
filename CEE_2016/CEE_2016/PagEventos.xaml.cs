using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CEE_2016.ViewModel;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CEE_2016.Dados
{

    public sealed partial class PagEventos : Page
    {
        private ObservableCollection<designEventos> dataViewEventos;
        public PagEventos()
        {

            this.InitializeComponent();

            
            this.grdGeral.DataContext = eventosDataSource.PegaEventosAsync();
            
        }
    }
}
