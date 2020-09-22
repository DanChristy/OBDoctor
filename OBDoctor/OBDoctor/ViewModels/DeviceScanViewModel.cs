using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;
using Plugin.BLE.Abstractions.Exceptions;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OBDoctor.ViewModels {
    public class DeviceScanViewModel : BaseViewModel {
        private readonly IBluetoothLE bluetoothLE;
        private readonly IAdapter adapter;

        public Command ScanCommand => new Command(OnScanClicked);

        private ObservableCollection<IDevice> devices;
        public ObservableCollection<IDevice> Devices {
            get => devices;
            set {
                devices = value;
                OnPropertyChanged();
            }
        }

        private IDevice selectedDevice;
        public IDevice SelectedDevice {
            get => selectedDevice;
            set {
                selectedDevice = value;
                OnPropertyChanged();
            }
        }

        public DeviceScanViewModel() {
            bluetoothLE = CrossBluetoothLE.Current;
            adapter = bluetoothLE.Adapter;
            Devices = new ObservableCollection<IDevice>();

            adapter.ScanTimeout = 60000;
            adapter.DeviceDiscovered += (sender, foundDevice) => OnDeviceDiscovered(foundDevice);
        }

        public async Task ConnectToDevice() {
            try {
                await adapter.ConnectToDeviceAsync(SelectedDevice);
            } catch (DeviceConnectionException exception) {
                Debug.WriteLine(exception);
            }
        }

        private async void OnScanClicked() {
            Devices.Clear();

            var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            await adapter.StopScanningForDevicesAsync();
            await adapter.StartScanningForDevicesAsync();
        }

        private void OnDeviceDiscovered(DeviceEventArgs deviceEventArgs) {
            if (deviceEventArgs.Device != null && !string.IsNullOrEmpty(deviceEventArgs.Device.Name))
                Devices.Add(deviceEventArgs.Device);
        }
    }
}