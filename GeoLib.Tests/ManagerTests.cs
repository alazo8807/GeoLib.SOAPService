using GeoLib.Data;
using GeoLib.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GeoLib.Tests
{
	[TestClass]
	public class ManagerTests
	{
		private Mock<IZipCodeRepository> _mockZipCodeRepo;

		[TestInitialize]
		public void Initialize()
		{
			_mockZipCodeRepo = new Mock<IZipCodeRepository>();
		}

		[TestMethod]
		public void GetZipInfo_CalledWithValidZipCode_ReturnCorrectResult()
		{
			var zipCode = new ZipCode()
			{
				City = "Miramar",
				State = new State() { Abbreviation = "Havana" },
				Zip = "11300"
			};

			_mockZipCodeRepo.Setup(z => z.GetByZip("11300")).Returns(zipCode);

			var geoService = new GeoManager(_mockZipCodeRepo.Object);

			var result = geoService.GetZipInfo("11300");

			Assert.IsTrue(result.City.ToUpper() == zipCode.City.ToUpper());
			Assert.IsTrue(result.State == zipCode.State.Abbreviation);
		}
	}
}
