using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotesPage : ContentPage
	{
		public NotesPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var notes = new List<Note>();

            var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");
            foreach (var fileName in files)
            {
                notes.Add(new Note
                {
                    Filename = fileName,
                    Text = File.ReadAllText(fileName),
                    CreateDate = File.GetCreationTime(fileName)
                
                });
            }

            listView.ItemsSource = notes
                .OrderBy(d => d.CreateDate);
        }

        private async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note(),
            });
        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Note note)
            {
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = note,
                });
            }
        }
    }
}