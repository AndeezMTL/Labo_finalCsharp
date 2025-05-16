using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace IdeaManager.UI.ViewModels
{

    /// ViewModel responsable de l'affichage et de la gestion de la liste des idées.
    /// Gère le chargement et le rafraîchissement des idées.

    public partial class IdeaListViewModel : ObservableObject
    {
        private readonly IIdeaService _ideaService;


        /// Collection observable contenant toutes les idées.
        /// Se met à jour automatiquement dans l'interface lors des modifications.

        [ObservableProperty]
        private ObservableCollection<Idea> ideas;


        /// Constructeur du ViewModel.
        /// Initialise la collection d'idées et charge les données.

        /// Service d'idées injecté pour la communication avec le backend
        public IdeaListViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
            Ideas = new ObservableCollection<Idea>();
            LoadIdeas();
        }


        /// Charge la liste complète des idées depuis le service.
        /// Met à jour la collection observable avec les nouvelles données.

        private async void LoadIdeas()
        {
            var ideasList = await _ideaService.GetAllAsync();
            Ideas.Clear();
            foreach (var idea in ideasList)
            {
                Ideas.Add(idea);
            }
        }


        /// Commande pour rafraîchir la liste des idées.
        /// Relance le chargement des données depuis le service.

        [RelayCommand]
        private void Refresh()
        {
            LoadIdeas();
        }
    }
}
