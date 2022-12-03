using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace BufferServer{
    class HTTPServer{
        public static HttpListener listener;
        public static string url            = "http://localhost:8000/";
        public static int requestCount      = 0;
        public static string pageData       = "<Default Response>";

        public static async Task HandleIncomingConnections(){
            bool runServer = true;
            while(runServer){
                HttpListenerContext ctx     = await listener.GetContextAsync();
                HttpListenerRequest req     = ctx.Request;
                HttpListenerResponse resp   = ctx.Response;
                requestCount++;
                Console.WriteLine("Request #{0} [{1}] <{2}>", requestCount, req.HttpMethod,
                                    req.Url!=null ? req.Url.ToString() : "");
                
            }
        }
    }
}