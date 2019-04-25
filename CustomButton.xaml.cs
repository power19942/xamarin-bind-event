using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace TelerikListViewDrag
{
    public partial class CustomButton : ContentView
    {
        public CustomButton()
        {
            InitializeComponent();
            InnerButton.Clicked += OnClicked;
            InnerButton2.Clicked += OnClicked2;
        }

        public event EventHandler Clicked = delegate { };
        public event EventHandler Clicked2 = delegate { };

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(CustomButton), propertyChanged: CommandUpdated);
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(CustomButton), propertyChanged: CommandParameterUpdated);


        public ICommand Command
        {
            get => (ICommand)this.GetValue(CommandProperty);
            set => this.SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => this.GetValue(CommandParameterProperty);
            set => this.SetValue(CommandParameterProperty, value);
        }


        private static void CommandUpdated(object sender, object oldValue, object newValue)
        {
            if (sender is CustomButton activityButton && newValue is ICommand newCommand)
            {
                activityButton.InnerButton.Command = newCommand;
            }
        }

        private static void CommandParameterUpdated(object sender, object oldValue, object newValue)
        {
            if (sender is CustomButton activityButton && newValue != null)
            {
                activityButton.InnerButton.CommandParameter = newValue;
            }


        }

        private void OnClicked(object sender, EventArgs args)
        {
            this.Clicked?.Invoke(sender, args);
        }

        private void OnClicked2(object sender, EventArgs args)
        {
            this.Clicked2?.Invoke(sender, args);
        }
    }

}