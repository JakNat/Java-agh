using MemeGenerator.Model.Type;
using MemeGenerator.Model.Dto;
using MemeGenerator.ClientDataAccess;
using MemeGenerator.ClientDataAccess.Repositories;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Linq;

namespace MemeGenerator.Client.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public void LoginRequest(PacketHeader packetHeader, Connection connection, LoginDto incomingObject)
        {
            Console.WriteLine("\nLogin request received..");

            // getting requested user
            User user = userRepository
                .GetAllByCondition(x => x.UserName == incomingObject.Login)
                .FirstOrDefault();

            if(user != null)
            {
                if(String.Equals(user.Password, incomingObject.Password))
                {
                    Console.WriteLine("Login request successful:");
                    Console.WriteLine("User: '{0}' logged to a server.",incomingObject.Login);

                    connection.SendObject("LoginResponse", "You are logged.");
                }
                else
                {
                    Console.WriteLine("Invalid login request: wrong password.");
                    connection.SendObject("LoginResponse", "Wrong password.");
                }
            }
            else
            {
                Console.WriteLine("Invalidd login request: user doesn't exist.");
                connection.SendObject("LoginResponse", "User douesn't exist.");
            }
        }

        public async void RegisterRequest(PacketHeader packetHeader, Connection connection, RegisterDto incomingObject)
        {
            Console.WriteLine("\nRegistration request...");

            // getting requested user
            User user = userRepository
                .GetAllByCondition(x => x.UserName == incomingObject.Login)
                .FirstOrDefault();
            if (user != null)
            {
                connection.SendObject("RegisterResponse", "User already exists.");
                return;
            }

            if (incomingObject.Password == incomingObject.ConfrimPassword)
            {
                User newUser = new User()
                {
                    UserName = incomingObject.Login,
                    Password = incomingObject.Password,
                    CreatedDate = DateTime.Now,

                };
                userRepository.Add(newUser);

               
                await userRepository.SaveAsync();
                Console.WriteLine("New user added: '{0}'",incomingObject.Login);
                connection.SendObject("RegisterResponse", "You are registered.");
            }
            else
            {
                Console.WriteLine("Not same passwords");
                connection.SendObject("RegisterResponse", "Error.");
            }
        }
    }
}
