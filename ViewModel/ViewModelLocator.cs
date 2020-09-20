/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:Chargily.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using CommonServiceLocator;
using StudentGestion.Services;
using StudentGestion.ViewModel;
using StudentGestion.View;

namespace StudentGestion.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
           
            SimpleIoc.Default.Register<HomeService>();
            SimpleIoc.Default.Register<MainService>();
            SimpleIoc.Default.Register<StudentInformationService>();
            SimpleIoc.Default.Register<StudentModifyService>();
            SimpleIoc.Default.Register<ModuleGestionService>();
            SimpleIoc.Default.Register<LoginService>();
            SimpleIoc.Default.Register<AffichageNoteService>();
            SimpleIoc.Default.Register<NoteGestionService>();
            SimpleIoc.Default.Register<AverageService>();
            SetupNavigation();
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
         
            navigationService.Configure("Home", new Uri("../View/Home.xaml", UriKind.Relative));
            navigationService.Configure("StudentInformation", new Uri("../View/StudentInformation.xaml", UriKind.Relative));
            navigationService.Configure("StudentModify", new Uri("../View/StudentModify.xaml", UriKind.Relative));
            navigationService.Configure("ModuleGestion", new Uri("../View/ModuleGestion.xaml", UriKind.Relative));
            navigationService.Configure("LoginPage", new Uri("../View/LoginPage.xaml", UriKind.Relative));
            navigationService.Configure("AffichageNote", new Uri("../View/AffichageNote.xaml", UriKind.Relative));
            navigationService.Configure("NoteGestion", new Uri("../View/NoteGestion.xaml", UriKind.Relative));
            navigationService.Configure("AverageView", new Uri("../View/AverageView.xaml", UriKind.Relative));
            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }
        public MainService Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainService>();
            }
        }
        public LoginService LoginService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginService>();
            }
        }
      
        public HomeService Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeService>();
            }
        }
        public StudentInformationService StudentInformationService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StudentInformationService>();
            }
        }
        public StudentModifyService StudentModifyService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StudentModifyService>();
            }
        }
        public ModuleGestionService ModuleGestionService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ModuleGestionService>();
            }
        }
       public AffichageNoteService AffichageNoteService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AffichageNoteService>();
            }
        }
        public NoteGestionService NoteGestionService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NoteGestionService>();
            }
        }
        public AverageService AverageService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AverageService>();
            }
        }
        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}