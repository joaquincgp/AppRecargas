namespace AppRecargas
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void OnRecargaCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton.IsChecked)
            {
                JCMensajeRecarga.Text = $"Ha seleccionado una recarga de: {radioButton.Content} dolares";
            }
        }
    }

}
