using System;

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


        private async void RecargarClicked(object sender, EventArgs e)
        {
            string numero = JCTelefonoEntry.Text;
            string operador = JCSelectionList.SelectedItem?.ToString();
            decimal cantidad = 0;

            if (JCRecarga3.IsChecked) cantidad = 3;
            if (JCRecarga5.IsChecked) cantidad = 5;
            if (JCRecarga10.IsChecked) cantidad = 10;

            if (string.IsNullOrEmpty(numero) || string.IsNullOrEmpty(operador) || cantidad == 0)
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos", "OK");
                return;
            }

            if (string.IsNullOrEmpty(numero) || numero.Length != 10 || !numero.All(char.IsDigit))
            {
                await DisplayAlert("Error", "El número de teléfono debe tener exactamente 10 dígitos.", "OK");
                return;
            }

            bool confirmacion = await DisplayAlert("Confirmación",
                                                   $"¿Desea recargar {cantidad} dólares a {numero} con el operador {operador}?",
                                                   "Sí", "No");
            if (confirmacion)
            {
                string fecha = DateTime.Now.ToString("dd/MM/yyyy");
                string contenido = $"Se hizo una recarga de {cantidad} dólares en la siguiente fecha; {fecha}";


                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", $"{numero}.txt");


                // Escribir el archivo
                File.WriteAllText(path, contenido);


                await DisplayAlert("Finalizado",$"Recarga de {cantidad} dólares exitosa a {numero} con {operador}.", "Ok");
            }
            else
            {
                await DisplayAlert("Finalizado", "Recarga cancelada", "Ok");
            }
        }
    }
}
    