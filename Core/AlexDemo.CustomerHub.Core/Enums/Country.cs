using System.ComponentModel;

namespace AlexDemo.CustomerHub.Core.Enums
{
	public enum Country : byte
	{
		[Description("Not defined")]
		NotDefined = 0,

		[Description("United Kingdom")]
		UnitedKingdom = 1,
		Sweden = 2,
		Germany = 3,

		[Description("Check Republic")]
		CzechRepublic = 4,

		USA = 5,

		Japan = 6
	}
}
