using JokeDuo.ViewModels;

namespace JokeDuo.Views
{
    public partial class JokeDuoView : ContentPage
    {
        public JokeDuoView(JokeDuoViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}