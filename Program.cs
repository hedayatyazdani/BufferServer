using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace BufferServer{
    class MainProgram{
        public static void Main(String[] args){
            HTTPServer.start();
        }
    }
}