using Microsoft.Samples.JsonFeeds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using WSTVIModel;

namespace lab7
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Feed1 : IFeed1
    {

        public SyndicationFeedFormatter GetStudentNotes(string studentId)
        {
            IncomingWebRequestContext woc = WebOperationContext.Current.IncomingRequest;
            OutgoingWebResponseContext cow = WebOperationContext.Current.OutgoingResponse;


            cow.Headers.Add("Access-Control-Allow-Origin", "*");
            if (woc.Method == "OPTIONS")
            {
                cow.Headers.Add("Access-Control-Allow-Origin", "*");
                cow.Headers.Add("Access-Control-Allow-Methods", "POST, PUT, DELETE,GET,OPTIONS");
                cow.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept");
                cow.Headers.Add("Access-Control-Max-Age", "1728000");
            }

            SyndicationFeed feed = new SyndicationFeed("Subjects & Notes", "Get list of notes by all subjects for this student", null);
            List<SyndicationItem> items = new List<SyndicationItem>();
            WSTVIEntities wds = new WSTVIEntities(new Uri("http://localhost:54801/WcfDataService1.svc/"));
            foreach (var note in wds.Notes.AsEnumerable().Where(i => i.StudentId == int.Parse(studentId)))
            {
                items.Add(new SyndicationItem(note.Subj, note.Note1.ToString(), null));
            }
            feed.Items = items;

            string query = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["format"];
            SyndicationFeedFormatter formatter = null;
            if (query == "atom")
            {
                formatter = new Atom10FeedFormatter(feed);
            }
            //else if(query == "json")
            //{
            //    formatter = new JsonFeedFormatter(feed);
            //}
            else
            {
                formatter = new Rss20FeedFormatter(feed);
            }

            return formatter;
        }

        public object GetStudentNotesJson(string studentId)
        {
            return GetStudentNotes(studentId);
        }
    }
}
