using System.Collections.Generic;
using System.ServiceModel;

namespace GeoLib.Contracts
{
	[ServiceContract]
	public interface IGeoService
	{
		[OperationContract]
		ZipCodeData GetZipInfo(string zip);

		[OperationContract]
		IEnumerable<string> GetStates(bool primaryOnly);

		[OperationContract(Name = "GetZipsByState")]
		IEnumerable<ZipCodeData> GetZips(string state);

		[OperationContract(Name ="GetZipsByRange")]
		IEnumerable<ZipCodeData> GetZips(string state, int range);
	}
}
