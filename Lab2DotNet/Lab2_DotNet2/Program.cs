using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
    
    Program program = new Program();
    await program.ReadFromWeb();

        
    }

     async Task ReadFromWeb()
    {

        using (HttpClient client = new HttpClient())
        {

            string text = await client.GetStringAsync("https://books.toscrape.com/");
                
            Console.WriteLine(text);
            return text;
        
        }
    }
}
