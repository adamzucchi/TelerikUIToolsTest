﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FreshMvvm;
using Newtonsoft.Json;
using Telerik.XamarinForms.DataControls.ListView.Commands;
using TelerikUIToolsTest.Models;
using Xamarin.Forms;

namespace TelerikUIToolsTest.PageModels
{
	public class MainPageModel : FreshBasePageModel
	{
		private ObservableCollection<Monkey> _monkeys;

		public MainPageModel()
		{
			this.ItemTapCommand = new Command<ItemTapCommandContext>(async(obj) => await this.ItemTapped(obj));

			Task.Run(async () =>
			{
				List<Monkey> monkeys = await GetMonkeys();
				Monkeys = new ObservableCollection<Monkey>(monkeys);
			});
		}

		public async Task<List<Monkey>> GetMonkeys()
		{
			string json = @"[{""Id"":""1"",""Name"":""Baboon"",""Location"":""Africa & Asia"",""Details"":""Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae."",""Image"":""http://upload.wikimedia.org/wikipedia/commons/thumb/9/96/Portrait_Of_A_Baboon.jpg/314px-Portrait_Of_A_Baboon.jpg"",""Population"":10000,""Latitude"":-8.783195,""Longitude"":34.508523},{""Id"":""2"",""Name"":""Capuchin Monkey"",""Location"":""Central & South America"",""Details"":""The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus."",""Image"":""http://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"",""Population"":23000,""Latitude"":12.769013,""Longitude"":-85.602364},{""Id"":""3"",""Name"":""Blue Monkey"",""Location"":""Central and East Africa"",""Details"":""The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia"",""Image"":""http://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg"",""Population"":12000,""Latitude"":1.957709,""Longitude"":37.297204},{""Id"":""4"",""Name"":""Squirrel Monkey"",""Location"":""Central & South America"",""Details"":""The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers."",""Image"":""http://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Saimiri_sciureus-1_Luc_Viatour.jpg/220px-Saimiri_sciureus-1_Luc_Viatour.jpg"",""Population"":11000,""Latitude"":-8.783195,""Longitude"":-55.491477},{""Id"":""5"",""Name"":""Golden Lion Tamarin"",""Location"":""Brazil"",""Details"":""The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae."",""Image"":""http://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Golden_lion_tamarin_portrait3.jpg/220px-Golden_lion_tamarin_portrait3.jpg"",""Population"":19000,""Latitude"":-14.235004,""Longitude"":-51.92528},{""Id"":""6"",""Name"":""Howler Monkey"",""Location"":""South America"",""Details"":""Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae."",""Image"":""http://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/Alouatta_guariba.jpg/200px-Alouatta_guariba.jpg"",""Population"":8000,""Latitude"":-8.783195,""Longitude"":-55.491477},{""Id"":""7"",""Name"":""Japanese Macaque"",""Location"":""Japan"",""Details"":""The Japanese macaque, is a terrestrial Old World monkey species native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each"",""Image"":""http://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Macaca_fuscata_fuscata1.jpg/220px-Macaca_fuscata_fuscata1.jpg"",""Population"":1000,""Latitude"":36.204824,""Longitude"":138.252924},{""Id"":""8"",""Name"":""Mandrill"",""Location"":""Southern Cameroon, Gabon, Equatorial Guinea, and Congo"",""Details"":""The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Gabon, Equatorial Guinea, and Congo."",""Image"":""http://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Mandrill_at_san_francisco_zoo.jpg/220px-Mandrill_at_san_francisco_zoo.jpg"",""Population"":17000,""Latitude"":7.369722,""Longitude"":12.354722},{""Id"":""9"",""Name"":""Proboscis Monkey"",""Location"":""Borneo"",""Details"":""The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey that is endemic to the south-east Asian island of Borneo."",""Image"":""http://upload.wikimedia.org/wikipedia/commons/thumb/e/e5/Proboscis_Monkey_in_Borneo.jpg/250px-Proboscis_Monkey_in_Borneo.jpg"",""Population"":15000,""Latitude"":0.961883,""Longitude"":114.55485},{""Id"":""10"",""Name"":""Sebastian"",""Location"":""Seattle"",""Details"":""This little trouble maker lives in Seattle with James and loves traveling on adventures with James and tweeting @MotzMonkeys. He by far is an Android fanboy and is getting ready for the new Nexus 6P!"",""Image"":""http://www.refractored.com/images/sebastian.jpg"",""Population"":1,""Latitude"":47.606209,""Longitude"":-122.332071},{""Id"":""11"",""Name"":""Henry"",""Location"":""Phoenix"",""Details"":""An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. His favorite platform is iOS by far and is excited for the new iPhone 6s!"",""Image"":""http://www.refractored.com/images/henry.jpg"",""Population"":1,""Latitude"":33.448377,""Longitude"":-112.074037}]";

			List<Monkey> monkeys = null;
			monkeys = await Task.Run(() => JsonConvert.DeserializeObject<List<Monkey>>(json)).ConfigureAwait(false);
			return monkeys;
		}

		public ObservableCollection<Monkey> Monkeys
		{
			get
			{
				return _monkeys;
			}
			set
			{
				_monkeys = value;
				RaisePropertyChanged();
			}
		}

		public Command<ItemTapCommandContext> ItemTapCommand { get; private set; }
		private async Task ItemTapped(ItemTapCommandContext context)
		{
			Monkey monkey = (Monkey)context.Item;

			//FreshMvvm Display Alert
			await CoreMethods.DisplayAlert("Monkey Tapped", $"{monkey.Name} was clicked", "OK");

			//Non-FreshMvvm Display Alert
			//await Application.Current.MainPage.DisplayAlert("Monkey Tapped", $"{monkey.Name} was clicked", "OK");
		}
	}
}