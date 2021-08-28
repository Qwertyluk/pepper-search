using Ninject;
using System.Windows;

namespace PepperSearch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel kernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            InitializeKernel();

            InitializeMainWindow();
        }

        private void InitializeKernel()
        {
            this.kernel = new StandardKernel();
            this.kernel.Load(new IocConfiguration());
        }

        private void InitializeMainWindow()
        {
            Current.MainWindow = this.kernel.Get<MainWindow>();
            Current.MainWindow.Show();
        }
    }
}
