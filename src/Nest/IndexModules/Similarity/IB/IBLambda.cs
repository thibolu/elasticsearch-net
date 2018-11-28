using System.Runtime.Serialization;
using System.Runtime.Serialization;


namespace Nest
{

	public enum IBLambda
	{
		/// <summary>
		/// Nw/N or average number of documents where w occurs
		/// </summary>
		[EnumMember(Value = "df")]
		DocumentFrequency,

		/// <summary>
		/// Fw/N or average number of occurrences of w in the collection
		/// </summary>
		[EnumMember(Value = "ttf")]
		TermFrequency,
	}
}
