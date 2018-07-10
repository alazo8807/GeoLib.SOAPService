using GeoLib.Contracts;
using GeoLib.Data;
using System.Collections.Generic;

namespace GeoLib.Services
{
	public class GeoManager : IGeoService
	{
		private IZipCodeRepository _zipCodeRepo;
		private IStateRepository _stateRepo;

		public GeoManager()
		{
			_zipCodeRepo = new ZipCodeRepository();
			_stateRepo = new StateRepository();
		}

		public GeoManager(IZipCodeRepository zipCodeRepo)
		{
			_zipCodeRepo = zipCodeRepo;
		}

		public GeoManager(IStateRepository stateRepo)
		{
			_stateRepo = stateRepo;
		}

		public GeoManager(IZipCodeRepository zipCodeRepo, IStateRepository stateRepo) : this(zipCodeRepo)
		{
			_stateRepo = stateRepo;
		}

		public ZipCodeData GetZipInfo(string zip)
		{
			ZipCodeData zipCodeData = null;

			var zipCode = _zipCodeRepo.GetByZip(zip);

			if (zipCode != null)
			{
				zipCodeData = new ZipCodeData()
				{
					City = zipCode.City,
					State = zipCode.State.Abbreviation,
					ZipCode = zipCode.Zip
				};
			}

			return zipCodeData;
		}

		public IEnumerable<string> GetStates(bool primaryOnly)
		{
			List<string> stateData = new List<string>();

			IEnumerable<State> states = _stateRepo.Get(primaryOnly);

			foreach (var state in states)
			{
				stateData.Add(state.Abbreviation);
			}

			return stateData;
		}

		public IEnumerable<ZipCodeData> GetZips(string state)
		{
			List<ZipCodeData> zipCodeData = new List<ZipCodeData>();

			var zips = _zipCodeRepo.GetByState(state);

			foreach (var zip in zips)
			{
				zipCodeData.Add(new ZipCodeData()
				{
					City = zip.City,
					State = zip.State.Abbreviation,
					ZipCode = zip.Zip
				});
			}

			return zipCodeData;
		}

		public IEnumerable<ZipCodeData> GetZips(string zip, int range)
		{
			List<ZipCodeData> zipCodeData = new List<ZipCodeData>();

			ZipCode zipEntity = _zipCodeRepo.GetByZip(zip);

			IEnumerable<ZipCode> zips = _zipCodeRepo.GetZipsForRange(zipEntity, range);

			foreach (var zipCode in zips)
			{
				zipCodeData.Add(new ZipCodeData()
				{
					City = zipCode.City,
					State = zipCode.State.Abbreviation,
					ZipCode = zipCode.Zip
				});
			}

			return zipCodeData;
		}
	}
}
