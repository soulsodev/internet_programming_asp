using Microsoft.Samples.JsonFeeds;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;

namespace lab7
{
    [ServiceContract]
    [ServiceKnownType(typeof(Atom10FeedFormatter))]
    [ServiceKnownType(typeof(Rss20FeedFormatter))]
    [ServiceKnownType(typeof(JsonFeedFormatter))]
    public interface IFeed1
    {
        //http://localhost:8733/Design_Time_Addresses/lab7/Feed/students/1/notes?format=atom
        //http://localhost:8733/Design_Time_Addresses/lab7/Feed/students/1/notes
        [OperationContract]
        [WebGet(UriTemplate = "students/{studentId}/notes", BodyStyle = WebMessageBodyStyle.Bare)]
        SyndicationFeedFormatter GetStudentNotes(string studentId);

        //http://localhost:8733/Design_Time_Addresses/lab7/Feed/json/students/1/notes
        [OperationContract]
        [WebGet(UriTemplate = "json/students/{studentId}/notes", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        object GetStudentNotesJson(string studentId);
    }
}
