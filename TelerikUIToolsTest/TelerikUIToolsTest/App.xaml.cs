using System;
using FreshMvvm;
using TelerikUIToolsTest.PageModels;
using TelerikUIToolsTest.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TelerikUIToolsTest
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//FreshMvvm
			var page = FreshPageModelResolver.ResolvePageModel<MainPageModel>();
			var basicNavContainer = new FreshNavigationContainer(page);
			MainPage = basicNavContainer;

			//Non-FreshMvvm
			//MainPage = new MainPage
			//{
			//	BindingContext = new MainPageModel()
			//};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
