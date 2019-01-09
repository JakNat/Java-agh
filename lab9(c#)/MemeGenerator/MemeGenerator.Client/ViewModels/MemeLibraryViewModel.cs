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


        private string _searchByNameProperty = "meme";
        private List<MemeDto> _memes;

        public List<MemeDto> Memes
        {
            get { return _memes; }
            set
            {
                _memes = value;
                NotifyOfPropertyChange(() => Memes);
            }
        }

        public string SearchByNameProperty
        {
            get { return _searchByNameProperty; }
            set
            {
                _searchByNameProperty = value;
                NotifyOfPropertyChange(() => SearchByNameProperty);
            }
        }


        public MemeLibraryViewModel(ClientApp client)
        {
            this.client = client;
        }
        public void LoadMemeByUser()
        {
            Memes = client.ServerConnection
                .SendReceiveObject<string, List<MemeDto>>
                (PacketType.GetMemesByUser, PacketType.GetMemesByUserResponse, 20000, "user");
        }

        public void LoadMemeByTitle()
        {
            Memes = client.ServerConnection.
                SendReceiveObject<string, List<MemeDto>>
                (PacketType.GetMemesByTitle, PacketType.GetMemeByTitleResponse, 20000, SearchByNameProperty);
        }
    }
}
