using MemeGenerator.Model.Type;
using MemeGenerator.Model.Dto;
using MemeGenerator.DataAccessLayer;
using MemeGenerator.DataAccessLayer.Repositories;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Linq;
using MemeGenerator.Model;
using MemeGeneratorServer;

namespace MemeGenerator.Client.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> userRepository;
        private readonly IEncrypter _encrypter;
        private readonly DummyAuthentication dummyAuthentication;

        public UserService(IGenericRepository<User> userRepository, IEncrypter encrypter, DummyAuthentication dummyAuthentication)
        {
            this.userRepository = userRepository;
            _encrypter = encrypter;
            this.dummyAuthentication = dummyAuthentication;
        }

        public void LoginRequest(PacketHeader packetHeader, Connection connection, LoginDto incomingObject)
        {
            Console.WriteLine("\nLogin request received..");
            //response
            var loginResponseDto = new LoginResponseDto();

            // getting requested user
            User user = userRepository
                .GetAllByCondition(x => x.Name == incomingObject.Login)
                .FirstOrDefault();

            if (user == null)
            {
                UserNotFoundMethod(connection, loginResponseDto);
            }

            if (!String.Equals(user.Password, incomingObject.Password))
            {
                WrongPasswordMethod(connection, loginResponseDto);
            }

            Console.WriteLine("Login request successful:");
            Console.WriteLine("User: '{0}' logged to a server.", incomingObject.Login);

            loginResponseDto.Key = dummyAuthentication.AddUser(user.UserId);
            loginResponseDto.Message = "Logging successful.";
      
            connection.SendObject(PacketTypes.Login.Response, loginResponseDto);
        }

        private void WrongPasswordMethod(Connection connection, LoginResponseDto loginResponseDto)
        {
            loginResponseDto.Message = "Logging failed.";
            Console.WriteLine("Invalid login request: wrong password.");
            connection.SendObject(PacketTypes.Login.Response, loginResponseDto);
        }

        private void UserNotFoundMethod(Connection connection, LoginResponseDto loginResponseDto)
        {
            loginResponseDto.Message = "Logging failed.";
            Console.WriteLine("Invalidd login request: user doesn't exist.");
            connection.SendObject(PacketTypes.Login.Response, loginResponseDto);
        }

        public async void RegisterRequest(PacketHeader packetHeader, Connection connection, RegisterDto incomingObject)
        {
            Console.WriteLine("\nRegistration request...");

            // getting requested user
            User user = userRepository
                .GetAllByCondition(x => x.Name == incomingObject.Login)
                .FirstOrDefault();
            if (user != null)
            {
                connection.SendObject(PacketTypes.Register.Response, "User already exists.");
                return;
            }

            //var salt = _encrypter.GetSalt(incomingObject.Password);
            //var hash = new User

            if (incomingObject.Password == incomingObject.ConfrimPassword)
            {
                User newUser = new User()
                {
                    Name = incomingObject.Login,
                    Password = incomingObject.Password,
                    CreatedDate = DateTime.Now,

                };
                userRepository.Add(newUser);

               
                await userRepository.SaveAsync();
                Console.WriteLine("New user added: '{0}'",incomingObject.Login);
                connection.SendObject(PacketTypes.Register.Response, "You are registered.");
            }
            else
            {
                Console.WriteLine("Not same passwords");
                connection.SendObject(PacketTypes.Register.Response, "Error.");
            }
        }
    }
}
