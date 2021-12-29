using System;
using System.Diagnostics;
using System.Text;
using System.Web;

namespace Simplex
{
    public class LogModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += this.OnBegin;
        }

        private void OnBegin(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            HttpContext context = app.Context;

            byte[] buffer = new byte[context.Request.InputStream.Length];
            context.Request.InputStream.Read(buffer, 0, buffer.Length);
            context.Request.InputStream.Position = 0;

            string soapMessage = Encoding.ASCII.GetString(buffer);

            Debug.WriteLine("LogModule");
            Debug.WriteLine(soapMessage);
        }

        public void Dispose() { }
    }
}
