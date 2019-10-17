
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using SQLAzureRampUpExecise.UiServices;
using SQLAzureRampUpExecise.ViewModleDesign;

namespace SQLAzureRampUpExecise.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                SimpleIoc.Default.Register<IMakeOrderViewModel, MakeOrderViewModelDesign>();
                SimpleIoc.Default.Register<IQueryOfOrdersViewModel, QueryOfOrdersViewModelDesign>();
            }
            else
            {
                // Create run time view services and models
                SimpleIoc.Default.Register<IMakeOrderViewModel, MakeOrderViewModel>();
                SimpleIoc.Default.Register<IQueryOfOrdersViewModel, QueryOfOrdersViewModel>();
                SimpleIoc.Default.Register<IMakeOrderUiService, MakeOrderUiService>();
            }

        }

        public T GetInstance<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }


        public IMakeOrderViewModel MakeOrderViewModel => GetInstance<IMakeOrderViewModel>();
        public IQueryOfOrdersViewModel QueryOfOrdersViewModel => GetInstance<IQueryOfOrdersViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}