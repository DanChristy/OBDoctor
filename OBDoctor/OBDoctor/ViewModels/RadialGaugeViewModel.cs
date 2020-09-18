namespace OBDoctor.ViewModels {
    public class RadialGaugeViewModel : BaseViewModel {
        public string GaugeText { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double CurrentValue { get; set; }
    }
}