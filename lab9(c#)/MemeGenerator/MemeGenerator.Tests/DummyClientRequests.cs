using MemeGenerator.Client.Requests;
using MemeGenerator.Client.Server.Services;
using MemeGenerator.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Tests
{
    public class DummyClientRequests : IClientRequests
    {
        private readonly IUserService userService;

        public DummyClientRequests(IUserService userService)
        {
            this.userService = userService;
        }
        public string CreateRequest(MemeDto memeDto)
        {
            throw new NotImplementedException();
        }

        public List<MemeDto> LoadMemeByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public List<MemeDto> LoadMemeByUser()
        {
            throw new NotImplementedException();
        }

        public LoginResponseDto LoginRequest(LoginDto loginDto)
        {
            userService.LoginRequest(null, null, loginDto);
            throw new NotImplementedException();
        }

        public string RegisterRequest(RegisterDto registerDto)
        {
            throw new NotImplementedException();
        }
    }
}
