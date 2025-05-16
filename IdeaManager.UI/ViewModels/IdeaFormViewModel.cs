using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using System.Threading.Tasks;

namespace IdeaManager.UI.ViewModels
{

    /// ViewModel responsable de la gestion du formulaire de création d'idées.
    /// Gère la saisie et la soumission des nouvelles idées.

    public partial class IdeaFormViewModel : ObservableObject
    {
        private readonly IIdeaService _ideaService;


        /// Titre de l'idée en cours de saisie.
        /// Propriété observable qui se met à jour automatiquement dans l'interface.

        [ObservableProperty]
        private string title;

  
        /// Description détaillée de l'idée en cours de saisie.
        /// Propriété observable qui se met à jour automatiquement dans l'interface.

        [ObservableProperty]
        private string description;


        /// Constructeur du ViewModel.
        /// Service d'idées injecté pour la communication avec le backend
        public IdeaFormViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }


        /// Commande asynchrone pour soumettre une nouvelle idée.
        /// Vérifie la validité des données et envoie l'idée au service.
        [RelayCommand]
        private async Task SubmitAsync()
        {
            // Vérification de la validité du titre
            if (string.IsNullOrWhiteSpace(Title))
            {
                return;
            }

            // Création d'une nouvelle idée avec les données du formulaire
            var idea = new Idea
            {
                Title = Title,
                Description = Description
            };

            // Envoi de l'idée au service et réinitialisation du formulaire
            await _ideaService.SubmitIdeaAsync(idea);
            Title = string.Empty;
            Description = string.Empty;
        }
    }
}
