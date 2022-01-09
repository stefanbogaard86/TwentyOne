using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TwentyOne.Pages.Base;
using TwentyOne.ViewModels;
using TwentyOne.ViewModels.PageViewModels;
using Xamarin.CommunityToolkit.Behaviors;
using Xamarin.Forms;

namespace TwentyOne.Pages
{
    public partial class GameScreenPage 
    {

        public GameScreenPage()
        {
            InitializeComponent();
            RegisterViewModel();
        }

        protected sealed override void RegisterViewModel()
        {
            this.ViewModel = new GameScreenViewModel();
        }
        
        private async void OnRollClickedAsync(object sender, EventArgs e)
        {

            var animationTasks = new List<AnimationTask>()
            {
                new AnimationTask(Dice1, ViewModel.CurrentRoundViewModel.Dices[0].Value.GetValueOrDefault()),
                new AnimationTask(Dice2, ViewModel.CurrentRoundViewModel.Dices[1].Value.GetValueOrDefault()),
                new AnimationTask(Dice3, ViewModel.CurrentRoundViewModel.Dices[2].Value.GetValueOrDefault()),
                new AnimationTask(Dice4, ViewModel.CurrentRoundViewModel.Dices[3].Value.GetValueOrDefault()),
                new AnimationTask(Dice5, ViewModel.CurrentRoundViewModel.Dices[4].Value.GetValueOrDefault()),
                new AnimationTask(Dice6, ViewModel.CurrentRoundViewModel.Dices[5].Value.GetValueOrDefault()),
            };

            await Task.WhenAll(animationTasks.Select(it => it.AnimateAsync()));
            AnimationTask.IsRotated = !AnimationTask.IsRotated;
            await ViewModel.CurrentRoundViewModel.RollAsyncCommand.ExecuteAsync();
            await Task.WhenAll(animationTasks.Select(it => it.ReverseAnimateAsync()));
        }
    }

    public class AnimationTask
    {
        private readonly VisualElement _element;
        private readonly int _value;
        private readonly int _animationId;
        private readonly uint _duration;
        readonly Random _random = new Random();
        private readonly int _rotation;
        private readonly int _rotationMin;

        public static bool IsRotated { get; set; }


        public AnimationTask(VisualElement element, int value)
        {
            _element = element;
            _value = value;
            _duration = (uint)_random.Next(350, 450);
            _animationId = _random.Next(1, 7);
            _rotation = IsRotated ? 0 : 180;
            _rotationMin = IsRotated ? 0 : -180;
        }

        public Task AnimateAsync()
        {
            if (_value == 1)
                return Task.CompletedTask;

            if (_animationId == 1)
                return _element.RotateXTo(_rotation, _duration, easing: Easing.Linear);
            if (_animationId == 2)
                return _element.RotateYTo(_rotation, _duration, easing: Easing.Linear);
            if (_animationId == 3)
                return _element.ScaleTo(0, _duration, easing: Easing.Linear);
            if (_animationId == 4)
                return _element.RotateXTo(_rotationMin, _duration, easing: Easing.Linear);
            if (_animationId == 5)
                return _element.RotateYTo(_rotationMin, _duration, easing: Easing.Linear);
            return _element.FadeTo(0, _duration, easing: Easing.Linear);
        }

        public Task ReverseAnimateAsync()
        {
            if (_value == 1)
                return Task.CompletedTask;

            if (_animationId == 3)
                return _element.ScaleTo(1, _duration, easing: Easing.Linear);
            
            if (_animationId == 6)
                return _element.FadeTo(1, _duration, easing: Easing.Linear);

            return Task.CompletedTask;
        }


    }
}
