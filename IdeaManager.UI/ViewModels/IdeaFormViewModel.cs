using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Interfaces;
using IdeaManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaFormViewModel : ObservableObject
    {
        private readonly IIdeaService _ideaService;
        public IdeaFormViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }
        [ObservableProperty]
        private string title;
        [ObservableProperty]
        private string description;
        [ObservableProperty]
        private string errorMessage;
        [RelayCommand]
        private async Task SubmitAsync()
        {
            try
            {
                var idea = new Idea
                {
                    Title = title,
                    Description = description
                };

                await _ideaService.SubmitIdeaAsync(idea);
                errorMessage = string.Empty;

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
    }
}