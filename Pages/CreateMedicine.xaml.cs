using System;
using System.Collections.Generic;
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

namespace trpo_7.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateMedicine.xaml
    /// </summary>
    public partial class CreateMedicine : Page
    {
        private readonly Http http = new();
        public Medicine medicine { get; set; } = new();
        public CreateMedicine()
        {
            InitializeComponent();
        }

        private async void Create_Click(object sender, RoutedEventArgs e)
        {
            await http.CreateJson(medicine);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
