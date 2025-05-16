using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;

namespace IdeaManager.UI.ViewModels
{
    /// ViewModel principal qui gère la navigation entre les différentes vues de l'application.
    /// Implémente un système de navigation simple basé sur le changement de UserControl.
    public partial class MainViewModel : ObservableObject
    {
        /// Contrôle utilisateur actuellement affiché dans l'interface.
        /// Cette propriété observable permet de mettre à jour automatiquement la vue.

        [ObservableProperty]
        private UserControl currentView;

        /// ViewModel pour la liste des idées, injecté via le constructeur.

        private readonly IdeaListViewModel ideaListViewModel;


        /// ViewModel pour le formulaire de création d'idées, injecté via le constructeur.

        private readonly IdeaFormViewModel ideaFormViewModel;


        /// Constructeur du ViewModel principal.
        /// Initialise les ViewModels et affiche la liste des idées par défaut.

        /// ViewModel pour la liste des idées
        /// ViewModel pour le formulaire de création
        public MainViewModel(IdeaListViewModel ideaListViewModel, IdeaFormViewModel ideaFormViewModel)
        {
            this.ideaListViewModel = ideaListViewModel;
            this.ideaFormViewModel = ideaFormViewModel;
            NavigateToIdeaList();
        }


        /// Commande de navigation vers la vue de liste des idées.
        /// Crée une nouvelle instance de IdeaListView et l'associe à son ViewModel.

        [RelayCommand]
        private void NavigateToIdeaList()
        {
            CurrentView = new Views.IdeaListView { DataContext = ideaListViewModel };
        }


        /// Commande de navigation vers le formulaire de création d'idée.
        /// Crée une nouvelle instance de IdeaFormView et l'associe à son ViewModel.
  
        [RelayCommand]
        private void NavigateToIdeaForm()
        {
            CurrentView = new Views.IdeaFormView { DataContext = ideaFormViewModel };
        }
    }
} 