using System;
using System.Net;
using System.IO;

namespace Way2Teste01
{
    class Program
    {
        static void Main(string[] args)
        {
            String word = Console.ReadLine();
            int i = 0;
            string responseFromServer = string.Empty;
            while(word.ToLower() != responseFromServer.ToLower())
            {
                WebRequest request = WebRequest.Create("http://teste.way2.com.br/dic/api/words/" + i);
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.
                WebResponse response = request.GetResponse();
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                responseFromServer = reader.ReadToEnd();             
                // Clean up the streams and the response.
                reader.Close();
                response.Close();
                i++;
            }
            // Display the content.
            Console.WriteLine(responseFromServer + " encontrado na posicao: " + i);
            Console.ReadLine();
        }
    }
}
