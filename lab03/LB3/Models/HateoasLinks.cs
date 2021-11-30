using System.Runtime.Serialization;

namespace lab03.Models
{
	[DataContract]
	public class HateoasLinks
    {
		[DataMember]
		public string allStudents;
		[DataMember]
		public string self;

		public HateoasLinks(string allStudents, string self)
		{
			this.allStudents = allStudents;
			this.self = self;
		}
	}
}