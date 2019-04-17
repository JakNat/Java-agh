using System.Collections.Generic;
using MemeGenerator.Model.Dto;

namespace MemeGenerator.Client.Requests
{
    /// <summary>
    /// Interface for storing all client requests to server
    /// </summary>
    public interface IClientRequests
    {
        /// <summary>
        /// Sending 'create new meme request' to a server
        /// </summary>
        /// <returns> Expected CreateMemeResponse message </returns>
        BaseResponseDto CreateRequest(MemeDto memeDto);

        /// <summary>
        /// Sending 'load memes by user id request' to a server
        /// </summary>
        /// <returns> User memes </returns>
        List<MemeDto> LoadMemeByUser();

        /// <summary>
        /// Sending 'load memes by title request' to a server
        /// </summary>
        /// <returns> Memes by title </returns>
        List<MemeDto> LoadMemeByTitle(string title);

        /// <summary>
        /// Sending 'login request' to server
        /// </summary>
        /// <returns> Expected user auth key </returns>
        LoginResponseDto LoginRequest(LoginDto loginDto);

        /// <summary>
        /// Sending registration reqest to a server
        /// </summary>
        /// <returns> Register response </returns>
        BaseResponseDto RegisterRequest(RegisterDto registerDto);
    }
}