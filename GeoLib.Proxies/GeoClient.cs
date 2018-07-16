﻿using GeoLib.Contracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace GeoLib.Proxies
{
	public class GeoClient : ClientBase<IGeoService>, IGeoService
	{
		public IEnumerable<string> GetStates(bool primaryOnly)
		{
			return Channel.GetStates(primaryOnly);
		}

		public ZipCodeData GetZipInfo(string zip)
		{
			return Channel.GetZipInfo(zip);
		}

		public IEnumerable<ZipCodeData> GetZips(string state)
		{
			return Channel.GetZips(state);
		}

		public IEnumerable<ZipCodeData> GetZips(string state, int range)
		{
			return Channel.GetZips(state, range);
		}
	}
}
