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
using System.Net.NetworkInformation;
using CEE_2016.Classes_Comuns;
using Windows.UI.ViewManagement;
using Windows.UI;
using System.Collections.ObjectModel;
using CEE_2016.Dados;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CEE_2016
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    
     
    public sealed partial class MainPage : Page
    {

        ObservableCollection<Colaborador> _OCColaboradores { get; set; }
        ObservableCollection<Projeto> _OCProjetos { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            /**CEE_2016.Classes_Comuns.Conexao objConexao = new CEE_2016.Classes_Comuns.Conexao();
            if (objConexao.verificaConexao())
            {
                teste1.Text = "INTERNET CONECTADA";
                Colaboradores kstColab = new Colaboradores();
                teste1.Text = kstColab.pegaColaboradores();
            }
            else
            {
                teste1.Text = "INTERNET DESCONECTADA";
            }**/
            App_Geral oGeral = new App_Geral();
            //this.teste1.Text = oGeral.TESTE;
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            //var OC = new ObservableCollection<Colaborador>();
            //OC.Add(new Colaborador("1", "1", "1", "1", "1", "1"));

            var OCColaborador = new ObservableCollection<Colaborador>(oGeral.listaColaboradores);
            var OCProjeto = new ObservableCollection<Projeto>(oGeral.listaProjetos);
            //grdConteudo.DataContext = OCColaborador;
            //COLABORADORES SERÁ A PAGINA INICIAL
            this._OCColaboradores = OCColaborador;
            this._OCProjetos = OCProjeto;
            this.frmGeral.Navigate(typeof(PagColaboradores),OCColaborador);

            // Title Bar Content Area
            titleBar.BackgroundColor = Color.FromArgb(0, 19, 28, 43);
            titleBar.ForegroundColor = Colors.White;

            // Title Bar Button Area
            titleBar.ButtonBackgroundColor = Color.FromArgb(0, 19, 28, 43);
            titleBar.ButtonForegroundColor = Colors.White;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
            
        }

        private void MenuButton3_Click(object sender, RoutedEventArgs e)
        {
            this.frmGeral.Navigate(typeof(PagProjetos),this._OCProjetos);
        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            this.frmGeral.Navigate(typeof(PagColaboradores),this._OCColaboradores);
        }

        private void MenuButton4_Click(object sender, RoutedEventArgs e)
        {
            this.frmGeral.Navigate(typeof(PagEventos));
        }
    }



}
