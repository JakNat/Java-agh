using MemeGenerator.Model;
using MemeGenerator.Models;
using MemeGeneratorDataAccess;
using MemeGeneratorServer.DAL;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;

namespace MemeGeneratorServer.Services
{
    public static class UserService
    {
        private static UserRepository _userRepository = new UserRepository(new MemeGeneratorDBContext());

        public static void Login(PacketHeader packetHeader, Connection connection, LoginDto incomingObject)
        {
            User user = null;
            Console.WriteLine("\nLogin request received..");
            try
            {
                user = _userRepository.GetByUserName(incomingObject.Login);
              
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid login request: user doesn't exist");
            }
            if(user != null)
            {
                if(String.Equals(user.Password, incomingObject.Password))
                {
                    Console.WriteLine("Login request successful:");
                    Console.WriteLine("User: +" + incomingObject.Login + " logged to a server");

                }
                else
                {
                    Console.WriteLine("Invalid login request: wrong password");
                }
            }
            else
            {
                Console.WriteLine("Invalidd login request: user doesn't exist");
            }
        }

        internal static void Register(PacketHeader packetHeader, Connection connection, RegisterDto incomingObject)
        {
            Console.WriteLine("\nRegistration request...");
            if(incomingObject.Password == incomingObject.ConfrimPassword)
            {
                User newUser = new User()
                {
                    UserName = incomingObject.Login,
                    Password = incomingObject.Password,
                    CreatedDate = DateTime.Now,

                };
                try
                {
                    _userRepository.Add(newUser);
                    _userRepository.SaveChanges();
                    Console.WriteLine("New user added: " + incomingObject.Login);
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                Console.WriteLine("Not same passwords");
            }
 
        }
    }
}
