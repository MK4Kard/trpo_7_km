using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для ChangeMedicine.xaml
    /// </summary>
    public partial class ChangeMedicine : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly Http http = new();
        private int id = 0;
        private Medicine _medicine = new();
        public Medicine medicine
        {
            get => _medicine;
            set
            {
                _medicine = value;
                OnPropertyChanged();
            }
        }

        public ChangeMedicine(int _id)
        {
            InitializeComponent();

            id = _id;
            Get();
        }

        public async void Get()
        {
            medicine = await http.GetJson(id);
        }

        private async void Change_Click(object sender, RoutedEventArgs e)
        {
            await http.PutJson(medicine, id);
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
