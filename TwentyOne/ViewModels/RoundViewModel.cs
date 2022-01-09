using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace TwentyOne.ViewModels
{
    public class RoundViewModel : ViewModelBase.ViewModelBase
    {
        private ObservableCollection<DiceViewModel> _dices;
        private bool _canRollAgain;
        private int _rollCount;
        private bool _nextPlayerEnabled;

        public RoundViewModel()
        {
            _rollCount  = 0;
            NextPlayerEnabled = false;
            CanRollAgain = true;
            var greenDice = new DiceViewModel(Color.FromHex("#C5FFE7"), Color.FromHex("#14C160"));
            var redDice = new DiceViewModel(Color.FromHex("#FFBBBE"), Color.FromHex("#D00000"));
            var blackDice = new DiceViewModel(Color.FromHex("#DBDBDB"), Color.FromHex("#000000"));
            var whiteDice = new DiceViewModel(Color.FromHex("#EDEDED"), Color.FromHex("#A5A5A5"));
            var yellowDice = new DiceViewModel(Color.FromHex("#FFF4CA"), Color.FromHex("#FFC100"));
            var blueDice = new DiceViewModel(Color.FromHex("#D8E1F4"), Color.FromHex("#446BC7"));

            Dices = new ObservableCollection<DiceViewModel>
            {
                greenDice,
                redDice,
                blackDice,
                whiteDice,
                yellowDice,
                blueDice
            };

            RollAsyncCommand = new AsyncCommand(RollAsync, allowsMultipleExecutions: false);
        }


        public ObservableCollection<DiceViewModel> Dices
        {
            get => _dices;
            set => SetProperty(ref _dices, value);
        }

        private async Task RollAsync()
        {
            if (!_canRollAgain)
                return;
            
            NextPlayerEnabled = true;
            _rollCount++;
            if (_rollCount >= 2)
                CanRollAgain = false;
            
            foreach (var diceViewModel in Dices)
            {
                diceViewModel.RollNext();
            }
        }

        public IAsyncCommand RollAsyncCommand { get; }

        public bool NextPlayerEnabled
        {
            get => _nextPlayerEnabled;
            set =>  SetProperty(ref _nextPlayerEnabled, value);
        }

        public bool CanRollAgain
        {
            get => _canRollAgain;
            set => SetProperty(ref _canRollAgain, value);
        }
    }
}
