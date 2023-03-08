using Newtonsoft.Json;
using System;

namespace Process.WithJsonResult
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = JsonConvert.SerializeObject(new User()
            {
                Email = "user@email.com",
                Username = "username"
            });
            
            Console.Write(json);
        }
    }

    class User
    {
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
