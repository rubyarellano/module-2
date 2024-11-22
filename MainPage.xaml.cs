using System;
using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace SimpleApp
{
    public partial class MainPage : ContentPage
    {
        public string _currentEntry = "";
        public string _operator = "";
        public double _firstNumber = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            string buttonText = button.Text;

            if ("0123456789".Contains(buttonText))
            {
                _currentEntry += buttonText;
                ResultLabel.Text = _currentEntry;
            }
            else
            {
                _operator = buttonText;
                _firstNumber = double.Parse(_currentEntry);
                _currentEntry = "";
            }
        }

        private void OnEqualClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentEntry))
            {
                double secondNumber = double.Parse(_currentEntry);
                double result = _operator switch
                {
                    "+" => _firstNumber + secondNumber,
                    "-" => _firstNumber - secondNumber,
                    "*" => _firstNumber * secondNumber,
                    "/" => _firstNumber / secondNumber,
                    _ => 0
                };

                ResultLabel.Text = result.ToString();
                _currentEntry = ""; _operator = ""; _firstNumber = 0;

            }
        }
    }
}
