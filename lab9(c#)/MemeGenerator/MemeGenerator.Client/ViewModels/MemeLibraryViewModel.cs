using Caliburn.Micro;
using MemeGenerator.Model;
using MemeGenerator.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Client.ViewModels
{
    public class MemeLibraryViewModel : Screen
    {
        private readonly ClientApp client;

        public List<MemeDto> Memes { get; set; }

        public MemeLibraryViewModel(ClientApp client)
        {
            this.client = client;
        }
        public void LoadMemeByUser()
        {
            Memes = client.ServerConnection
                .SendReceiveObject<string, List<MemeDto>>
                (PacketType.GetMemesByUser, PacketType.GetMemesByUserResponse, 10000, "user");
        }
    }
}
