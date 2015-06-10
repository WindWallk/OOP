using System;

namespace _05.HTMLDispatcher
{
    class HTMLDispatcherTest
    {
        static void Main(string[] args)
        {
            try
            {
                ElementBuilder div = new ElementBuilder("div");

                div.AddAttribute("id", "page");
                div.AddAttribute("class", "big");
                div.AddContent("<p>Hello</p>");

                Console.WriteLine(div * 2);

                string url = HTMLDispatcher.CreateURL("www.gmail.com", "Gmail", "Link to gmail.com");
                string image = HTMLDispatcher.CreateImage("c://image.jpg", "some image", "Image");
                string input = HTMLDispatcher.CreateInput("text", "username", "user");

                Console.WriteLine(url);
                Console.WriteLine(image);
                Console.WriteLine(input);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
