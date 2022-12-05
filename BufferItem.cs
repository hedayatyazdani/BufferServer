using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Collections;

namespace BufferServer{
    class BufferItem{
        Dictionary<string, string> mQueryMap;
        public string Path{ get; set; }
        public string Query{ get; set; }
        public string Body{ get; set; }
        public long Time{ get; set; }

        BufferItem(String Url){
            mQueryMap = new Dictionary<string, string>();
            Path = "";
            Query = "";
            Body = "";
            Time = Convert.ToInt32(DateTime.UtcNow);
        }
        
    }
}