namespace OBDoctor.ViewModels {
    public class DashboardViewModel : BaseViewModel {
        public RadialGaugeViewModel SpeedRadialGauge { get; set; }
        public RadialGaugeViewModel RPMRadialGauge { get; set; }

        public DashboardViewModel() {
            SpeedRadialGauge = new RadialGaugeViewModel {
                MinValue = 0,
                MaxValue = 140,
                CurrentValue = 60,
                GaugeText = "MPH"
            };

            RPMRadialGauge = new RadialGaugeViewModel {
                MinValue = 0,
                MaxValue = 6,
                CurrentValue = 1.5,
                GaugeText = "x1000 RPM"
            };
        }
    }
}