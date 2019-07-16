using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using System.Collections.Specialized;

namespace TelerikUIToolsTest.Pages
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();

			this.listView.SelectionChanged += ListView_SelectionChanged;
		}

		private void ListView_SelectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			//clear out list selections
			if (this.listView.SelectedItem != null)
			{
				if (this.listView.SelectedItems.Count() > 1)
				{
					Device.BeginInvokeOnMainThread(() =>
					{
						this.listView.SelectedItems.Clear();
					});
				}
			}
		}
	}
}