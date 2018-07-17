using GeoLib.Contracts;
using GeoLib.Proxies;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace GeoLib.Client
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			this.Title = "UI Running on Thread " + Thread.CurrentThread.ManagedThreadId +
				" | Process " + Process.GetCurrentProcess().Id.ToString();
		}

		private void btnGetInfo_Click(object sender, RoutedEventArgs e)
		{
			if (txtZipCode.Text != "")
			{
				GeoClient proxy = new GeoClient("tcpEP");	//Pass tcpEP or httpEP

				ZipCodeData data = proxy.GetZipInfo(txtZipCode.Text);
				if (data != null)
				{
					lblCity.Content = data.City;
					lblState.Content = data.State;
				}
			}
		}

		private void btnGetZipCodes_Click(object sender, RoutedEventArgs e)
		{
			if (txtState.Text != null)
			{

			}
		}

		private void btnMakeCall_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
