using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace trpo_7.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly Http http = new();
        public ObservableCollection<Medicine> medicines { get; set; } = new();
        public Medicine? SelectedMedicine { get; set; }
        private string _manufacturer;
        public string manufacturer
        {
            get => _manufacturer;
            set
            {
                _manufacturer = value;
                OnPropertyChanged();
            }
        }
        private bool _available = new();
        public bool available
        {
            get => _available;
            set
            {
                _available = value;
                OnPropertyChanged();
            }
        }

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
                NavigationService.Navigate(new ChangeMedicine(SelectedMedicine.Id));
            }
            else
            {
                MessageBox.Show("Выберите препарат", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMedicine != null)
            {
                var medicine = await http.GetJson(SelectedMedicine.Id);
                await http.DeleteJson(medicine.Id);
                medicines.Remove(SelectedMedicine);
                SelectedMedicine = null;
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
                NavigationService.Navigate(new PatchMedicine(SelectedMedicine.Id));
            }
            else
            {
                MessageBox.Show("Выберите препарат", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async Task Button_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        public async void Update()
        {
            if (medicines != null)
            {
                medicines.Clear();

                var task = await http.GetFromJsonMedicineAsync(manufacturer, available);
                foreach (var medic in task)
                {
                    medicines.Add(medic);
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
