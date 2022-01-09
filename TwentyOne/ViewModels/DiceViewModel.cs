using System;
using Xamarin.Forms;

namespace TwentyOne.ViewModels
{
    public class DiceViewModel : ViewModelBase.ViewModelBase
    {
        private readonly Random _random;
        private Color _color;
        private Color _borderColor;

        private int? _value;
        
        public DiceViewModel(Color color, Color borderColor)
        {
            Color = color;
            BorderColor = borderColor;
            _random = new Random();
        }

        public void RollNext()
        {
            if (Value == 1)
                return;

            Value = _random.Next(1, 7);
        }

        public int? Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public Color BorderColor
        {
            get => _borderColor;
            set => SetProperty(ref _borderColor, value);
        }

        public Color Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }
    }
}
