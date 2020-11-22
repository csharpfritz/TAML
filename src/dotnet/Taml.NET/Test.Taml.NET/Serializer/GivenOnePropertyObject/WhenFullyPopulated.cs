using Xunit;

namespace Test.Taml.NET.Serializer.GivenOnePropertyObject
{
  public class WhenFullyPopulated
	{

		public const string GivenTaml = @"PropertyOne			ValueOne";

		[Fact]
		public void ShouldPopulateTheProperty() 
		{

			
			// act
			var outValue = TAML.Serializer.Deserialize<SimpleObject>(GivenTaml);

			// assert
			Assert.NotNull(outValue);
			Assert.Equal("ValueOne", outValue.PropertyOne);


		}

	}

}
