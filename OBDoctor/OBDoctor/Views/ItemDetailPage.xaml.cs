using System.ComponentModel;
using Xamarin.Forms;
using OBDoctor.ViewModels;

namespace OBDoctor.Views {
    public partial class ItemDetailPage : ContentPage {
        public ItemDetailPage() {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}