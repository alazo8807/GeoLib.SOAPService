﻿using GeoLib.Contracts;
using GeoLib.Proxies;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
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
				EndpointAddress address = new EndpointAddress("net.tcp://localhost:8009/GeoService");
				Binding binding = new NetTcpBinding();

				GeoClient proxy = new GeoClient(binding, address);

				IEnumerable<ZipCodeData> data = proxy.GetZips(txtState.Text);
				if (data != null)
				{
					lstZips.ItemsSource = data;
				}

			}
		}

		private void btnMakeCall_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
