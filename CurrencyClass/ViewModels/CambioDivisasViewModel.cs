using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CurrencyClass.ViewModels
{
    class CambioDivisasViewModel : INotifyPropertyChanged
    {

        private string _valorUSD;
        private string _valorEUR;

        public string ValorUSD { 
            get => _valorUSD;
            set
            {
                if (_valorUSD != value)
                {
                    _valorUSD = value;
                    OnPropertyChanged();
                    ConvertirDeUSDAEuros(); 
                }
            }
        }
        public string ValorEUR
        {
            get => _valorEUR;
            set
            {
                if (_valorEUR != value)
                {
                    _valorEUR = value;
                    OnPropertyChanged();
                    ConvertirDeEurosAUSD();
                }
            }
        }

        public ICommand MostrarResultadosCommand { get; set; }

        public CambioDivisasViewModel()
        {
            MostrarResultadosCommand = new Command(async () => await MostrarResultados());

               
        }

        public async Task MostrarResultados()
        {
            ValorEUR = "0";
            ValorUSD = "0";
        }


        public void ConvertirDeUSDAEuros()
        {
            var valorEuros = Double.Parse(_valorUSD) * 0.86;
            ValorEUR = valorEuros.ToString("F2");
        }

        public void ConvertirDeEurosAUSD()
        {
            var valorUSD = Double.Parse(_valorEUR) /0.86 ;
            ValorUSD = valorUSD.ToString("F2");
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
