using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Notes
{
    public partial class MainPage : ContentPage
    {
        private const string FileName = "notes.txt";

        private readonly string _filePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            FileName);

        public MainPage()
        {
            InitializeComponent();

            if (File.Exists(_filePath))
            {
                editor.Text = File.ReadAllText(_filePath);
            }
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_filePath, editor.Text);
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            editor.Text = string.Empty;
            if (File.Exists(_filePath))
                File.Delete(_filePath);
        }
    }
}
