﻿using CourseworkUI.Models.Clients;
using CourseworkUI.Services;
using System.Windows;
using System.Windows.Controls;

namespace CourseworkUI.Pages.Register
{
	/// <summary>
	/// Interaction logic for NaturalPersonPage.xaml
	/// </summary>
	public partial class NaturalPersonPage : Page
	{
		private ApplicationContext _database { get; } = new ApplicationContext();

		public NaturalPersonPage()
		{
			InitializeComponent();
		}

		private void TxtUser_GotFocus(object sender, RoutedEventArgs e)
		{
			txtUser.ShadowText().CheckGotFocus("Username");
		}

		private void TxtPas_GotFocus(object sender, RoutedEventArgs e)
		{
			txtPas.ShadowText().CheckGotFocus("Password");
		}

		private void TxtUser_LostFocus(object sender, RoutedEventArgs e)
		{
			txtUser.ShadowText().CheckLostFocus("Username");
		}

		private void TxtPas_LostFocus(object sender, RoutedEventArgs e)
		{
			txtPas.ShadowText().CheckLostFocus("Password");
		}

		private void txtFirstName_GotFocus(object sender, RoutedEventArgs e)
		{
			txtFirstName.ShadowText().CheckGotFocus("First name");
		}

		private void txtFirstName_LostFocus(object sender, RoutedEventArgs e)
		{
			txtFirstName.ShadowText().CheckLostFocus("First name");
		}

		private void txtLastName_GotFocus(object sender, RoutedEventArgs e)
		{
			txtLastName.ShadowText().CheckGotFocus("Last name");
		}

		private void txtLastName_LostFocus(object sender, RoutedEventArgs e)
		{
			txtLastName.ShadowText().CheckLostFocus("Last name");
		}

		private void txtMiddleName_LostFocus(object sender, RoutedEventArgs e)
		{
			txtMiddleName.ShadowText().CheckLostFocus("Middle name");
		}

		private void txtMiddleName_GotFocus(object sender, RoutedEventArgs e)
		{
			txtMiddleName.ShadowText().CheckGotFocus("Middle name");
		}

		private void HouseNumber_GotFocus(object sender, RoutedEventArgs e)
		{
			HouseNumber.ShadowText().CheckGotFocus("House number");
		}

		private void HouseNumber_LostFocus(object sender, RoutedEventArgs e)
		{
			HouseNumber.ShadowText().CheckLostFocus("House number");
		}

		private void LocalityText_LostFocus(object sender, RoutedEventArgs e)
		{
			LocalityText.ShadowText().CheckLostFocus("Locality");
		}

		private void LocalityText_GotFocus(object sender, RoutedEventArgs e)
		{
			LocalityText.ShadowText().CheckGotFocus("Locality");
		}

		private void ApartmentNumber_GotFocus(object sender, RoutedEventArgs e)
		{
			ApartmentNumber.ShadowText().CheckGotFocus("Apartment number");
		}

		private void ApartmentNumber_LostFocus(object sender, RoutedEventArgs e)
		{
			ApartmentNumber.ShadowText().CheckLostFocus("Apartment number");
		}

		private void RegisterButton_Click(object sender, RoutedEventArgs e)
		{
			txtFirstName.Rules().MinCharacters(3)
								.OnlyText()
								.ValidateControl();

			txtLastName.Rules().MinCharacters(3)
								.OnlyText()
								.ValidateControl();

			txtMiddleName.Rules().MinCharacters(3)
								.OnlyText()
								.ValidateControl();

			txtUser.Rules().MinCharacters(3)
							.CorrectUsername()
							.ValidateControl();

			txtPas.Rules().MinCharacters(5)
							.ValidateControl();

			LocalityText.Rules().MinCharacters(2)
								.MaxCharacters(12)
								.OnlyText()
								.ValidateControl();

			HouseNumber.Rules().MinCharacters(1)
								.MaxCharacters(4)
								.ValidateControl();

			ApartmentNumber.Rules().MinCharacters(1)
									.MaxCharacters(4)
									.ValidateControl();

			if (txtFirstName.IsCorrect() &&
				txtLastName.IsCorrect() &&
				txtMiddleName.IsCorrect() &&
				txtUser.IsCorrect() &&
				txtPas.IsCorrect() &&
				LocalityText.IsCorrect() &&
				HouseNumber.IsCorrect() &&
				ApartmentNumber.IsCorrect())
			{
				var naturalPesron = new NaturalPerson(
					txtUser.Text,
					txtPas.Password,
					txtFirstName.Text,
					txtLastName.Text,
					txtMiddleName.Text,
					LocalityText.Text,
					HouseNumber.Text,
					ApartmentNumber.Text
					);

				_database.NaturalPersons.Add(naturalPesron);
				_database.SaveChanges();

				var window = new MainWindow();
				Application.Current.MainWindow = window;

				window.Show();
				Application.Current.Windows[0].Close();
			}
		}
	}
}
