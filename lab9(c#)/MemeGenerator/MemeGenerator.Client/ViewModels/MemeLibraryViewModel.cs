using Caliburn.Micro;
using MemeGenerator.Client.Requests;
using MemeGenerator.Model.Dto;
using System;
using System.Collections.Generic;

namespace MemeGenerator.Client.ViewModels
{
    public class MemeLibraryViewModel : Screen
    {
        private readonly ClientApp client;
        private readonly IClientRequests clientRequests;

        public MemeLibraryViewModel(ClientApp client, IClientRequests clientRequests)
        {
            this.client = client;
            this.clientRequests = clientRequests;
        }

        private string _searchByNameProperty;
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
                NotifyOfPropertyChange(() => CanLoadMemeByTitle);
            }
        }


        #region Buttons

        /// <summary>
        /// button -> Load memes by user id 
        /// </summary>
        public void LoadMemeByUser()
        {
            Memes = clientRequests.LoadMemeByUser();
        }

        /// <summary>
        /// button -> Load memes by typed tittle
        /// </summary>
        public void LoadMemeByTitle()
        {
            Memes = clientRequests.LoadMemeByTitle(SearchByNameProperty);
        }

        #endregion

        #region Validators

        /// <summary>
        /// turn on or off button -> Load memes by user id
        /// </summary>
        public bool CanLoadMemeByUser
        {
            get
            {
                return client?.ServerConnection != null
                && !String.IsNullOrWhiteSpace(SearchByNameProperty);
            }
        }

        /// <summary>
        /// turn on or off button -> Load memes by typed tittle
        /// </summary>
        public bool CanLoadMemeByTitle
        {
            get
            {
                return client?.ServerConnection != null
                && !String.IsNullOrWhiteSpace(SearchByNameProperty);
            }
        }

        #endregion
    }
}
