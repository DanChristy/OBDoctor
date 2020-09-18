using System;
using Xamarin.Forms;

namespace OBDoctor {
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e) {
            await Current.GoToAsync("//LoginPage");
        }
    }
}