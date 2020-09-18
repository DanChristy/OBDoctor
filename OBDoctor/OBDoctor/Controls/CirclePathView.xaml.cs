using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OBDoctor.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CirclePathView : ContentView {
        public static BindableProperty MinValueProperty = BindableProperty.Create(nameof(MinValue), typeof(double), typeof(CirclePathView));
        public static BindableProperty MaxValueProperty = BindableProperty.Create(nameof(MaxValue), typeof(double), typeof(CirclePathView), 1.0d);
        public static BindableProperty CurrentValueProperty = BindableProperty.Create(nameof(CurrentValue), typeof(double), typeof(CirclePathView));
        public static BindableProperty LineColorProperty = BindableProperty.Create(nameof(LineColor), typeof(Color), typeof(CirclePathView), Color.White);



        public double MinValue {
            get => (double)GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        public double MaxValue {
            get => (double)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public double CurrentValue {
            get => (double)GetValue(CurrentValueProperty);
            set => SetValue(CurrentValueProperty, value);
        }

        public Color LineColor {
            get => (Color)GetValue(LineColorProperty);
            set => SetValue(LineColorProperty, value);
        }

        public CirclePathView() {
            InitializeComponent();
        }

        public Action CurrentValueChanged { get; set; }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            base.OnPropertyChanged(propertyName);

            if (propertyName != null && propertyName.Equals(CurrentValueProperty.PropertyName)) {
                CurrentValueChanged?.Invoke();
            }
        }
    }
}