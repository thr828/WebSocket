using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace WebSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            //var listener = new HttpListener();
            //listener.Prefixes.Add("http://10.10.13.140:8080/");
            //listener.Start();

            //var context = listener.GetContext();

            //var wsContext = await context.AcceptWebSocketAsync(null);
            //var ws = wsContext.WebSocket;
            //Console.WriteLine("WebSocket connect");

            ////接收数据
            //var wsdata = await ws.ReceiveAsync(abuf, cancel);
            //Console.WriteLine(wsdata.Count);
            //byte[] bRec = new byte[wsdata.Count];
            //Array.Copy(buf, bRec, wsdata.Count);
            //Console.WriteLine(Encoding.Default.GetString(bRec));

            //ws.Dispose();
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost/"); //添加需要监听的url范围         
            listener.Start();   //开始监听端口，接收客户端请求          
            Console.WriteLine("Listening...");
            //阻塞主函数至接收到一个客户端请求为止           
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            string responseString = string.Format("<HTML><BODY> {0}</BODY></HTML>", DateTime.Now);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);             //对客户端输出相应信息.  
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);             //关闭输出流，释放相应资源         
            output.Close();
            listener.Stop();    //关闭HttpListener      
        }
    }
}
