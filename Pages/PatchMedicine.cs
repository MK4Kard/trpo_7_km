using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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
using static System.Net.WebRequestMethods;

namespace trpo_7.Pages
{
    /// <summary>
    /// Логика взаимодействия для PatchMedicine.xaml
    /// </summary>
    public partial class PatchMedicine : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly Http http = new();
        private int id = 0;
        private MedicineDto _medicine = new();
        public MedicineDto medicine
        {
            get => _medicine;
            set
            {
                _medicine = value;
                OnPropertyChanged();
            }
        }

        public PatchMedicine(int _id)
        {
            InitializeComponent();

            id = _id;
            Get();
        }

        public async void Get()
        {
            (Medicine? _medicine, string mess) task = await http.GetJson(id);

            if (task._medicine != null)
            {
                medicine = new MedicineDto
                {
                    Name = task._medicine.Name,
                    Manufacturer = task._medicine.Manufacturer,
                    Price = task._medicine.Price,
                    ExpirationDate = task._medicine.ExpirationDate,
                    IsAvailable = task._medicine.IsAvailable
                };
            }

            MessageBox.Show(task.mess);
        }

        private async void Change_Click(object sender, RoutedEventArgs e)
        {
            var mess = await http.PatchJson(medicine, id);
            MessageBox.Show(mess);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
