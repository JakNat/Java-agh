using Caliburn.Micro;
using MemeGenerator.Client.Requests;
using MemeGenerator.Client.Services;
using MemeGenerator.Model.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemeGenerator.Client.ViewModels
{
    public class MemeLibraryViewModel : Screen
    {
        private readonly IClientApp client;
        private readonly MemeLibraryService memeLibraryService;

        public MemeLibraryViewModel(IClientApp client, MemeLibraryService memeLibraryService)
        {
            this.client = client;
            this.memeLibraryService = memeLibraryService;
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
        public async Task<List<MemeDto>> LoadMemeByUser()
        {
            Memes = await memeLibraryService.LoadMemeByUserAction();
            return Memes;
        }

        /// <summary>
        /// button -> Load memes by typed tittle
        /// </summary>
        public async Task<List<MemeDto>> LoadMemeByTitle()
        {
            Memes = await memeLibraryService.LoadMemeByTitleAction(SearchByNameProperty);
            return Memes;
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
                return client?.ServerConnection != null;
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
