using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HTTPServer
{
	class Program
	{
		static Task Main(string[] args)
		{
			TcpListener listener = new TcpListener(90); 
			listener.Start();
			while(true)
			{
				TcpClient client = listener.AcceptTcpClient();
				Console.WriteLine("Connected");
				StreamWriter writer = new StreamWriter(client.GetStream());
				StreamReader file = new StreamReader("your html file"); //for dynamic file name form url use streamreader and get file name from it.
				writer.WriteLine("HTTP/1.0 200 OK\n");
				string content = file.ReadToEnd();
				if(content!=null) writer.WriteLine(content);
				writer.Flush();

			}
		}
	}
}
