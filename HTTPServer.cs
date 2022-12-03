using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace BufferServer{
    class HTTPServer{
        public static HttpListener listener = new HttpListener();
        public static string default_url        = "http://localhost:8000/";
        public static int requestCount          = 0;
        public static string default_response   = "<Default Response>";

        public static async Task HandleIncomingConnections(){
            bool runServer = true;
            while(runServer){
                HttpListenerContext ctx     = await listener.GetContextAsync();
                HttpListenerRequest req     = ctx.Request;
                HttpListenerResponse resp   = ctx.Response;
                requestCount++;
                Console.WriteLine("Request #{0} [{1}] <{2}>", requestCount, req.HttpMethod,
                                    req.Url!=null ? req.Url.ToString() : "");

                byte[] data = Encoding.UTF8.GetBytes(default_response);
                resp.ContentType = "text/plain";
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;

                await resp.OutputStream.WriteAsync(data, 0, data.Length);
                resp.Close();
            }
        }
        public static void start(){
            listener.Prefixes.Add(default_url);
            listener.Start();
            Console.WriteLine("Listening...");

            //Handle requests
            Task listenTask = HandleIncomingConnections();
            listenTask.GetAwaiter().GetResult();

            //close the listener at the end
            listener.Close();
        }
    }
}