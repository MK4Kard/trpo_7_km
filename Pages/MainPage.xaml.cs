using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly Http http = new();
        public ObservableCollection<Medicine> medicines { get; set; } = new();
        public Medicine? SelectedMedicine { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateMedicine());
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMedicine != null)
            {
                //NavigationService.Navigate();
            }
            else
            {
                MessageBox.Show("Выберите препарат", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMedicine != null)
            {
                
            }
            else
            {
                MessageBox.Show("Выберите препарат", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ChangePatch_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMedicine != null)
            {
                //NavigationService.Navigate();
            }
            else
            {
                MessageBox.Show("Выберите препарат", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var task = await http.GetFromJsonMedicineAsync();
            foreach (var medic in task)
            {
                medicines.Add(medic);
            }
        }
    }
}
