namespace AlexDemo.CustomerHub.Core.Enums
{
	public enum Status : byte
	{
		/// <summary>
		/// entity was created but not yet visible in UI, default state then record is created unless is defined explicitly
		/// </summary>
		Draft = 1,

		/// <summary>
		/// entity was published and visible in UI
		/// </summary>
		Active = 2,

		/// <summary>
		/// entity was disabled
		/// </summary>
		Disabled = 3,

        /// <summary>
        /// indication that entity has been logically deleted
        /// </summary>
		Deleted = 4
	}
}
