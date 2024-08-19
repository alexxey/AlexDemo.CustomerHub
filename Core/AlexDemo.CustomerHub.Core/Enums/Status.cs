namespace AlexDemo.CustomerHub.Core.Enums
{
	public enum Status : byte
	{
		/// <summary>
		/// entity was created but not yet visible 
		/// </summary>
		Created = 1,

		/// <summary>
		/// entity was published and visible in UI
		/// </summary>
		Active = 2,

		/// <summary>
		/// entity was disabled
		/// </summary>
		Disabled = 3,

		Deleted = 4
	}
}
