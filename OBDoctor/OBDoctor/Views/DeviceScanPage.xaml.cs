using OBDoctor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OBDoctor.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceScanPage : ContentPage {
        public DeviceScanPage() {
            InitializeComponent();
        }

        private async void DeviceList_ItemTapped(object sender, ItemTappedEventArgs e) {
            var deviceScanViewModel = (DeviceScanViewModel)BindingContext;

            bool answer = await DisplayAlert("Are you sure?", $"Would you like to connect to the device: {deviceScanViewModel.SelectedDevice.Name}", "Yes", "No");

            if (answer) {
                await deviceScanViewModel.ConnectToDevice();
            }
        }
    }
}