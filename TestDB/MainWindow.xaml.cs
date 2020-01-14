using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestDB
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private BaseDeDatosCarlosClemenEntities ctx;
        private CLIENTE _CLIENTE = new CLIENTE();

        public MainWindow()
        {
            InitializeComponent();

            ctx = new BaseDeDatosCarlosClemenEntities();
            ctx.CLIENTES.Load();

            ClientsListBox.DataContext = ctx.CLIENTES.Local;
            ClientsModifyComboBox.DataContext = ctx.CLIENTES.Local;
            ClientsRemoveComboBox.DataContext = ctx.CLIENTES.Local;
            InsertarStackPanel.DataContext = _CLIENTE;
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            ctx.CLIENTES.Add(_CLIENTE);
            ctx.SaveChanges();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            ctx.CLIENTES.Remove((CLIENTE)ClientsRemoveComboBox.SelectedItem);
            ctx.SaveChanges();
        }

        private void ModificarButton_Click(object sender, RoutedEventArgs e)
        {
            ctx.SaveChanges();
        }
    }
}
