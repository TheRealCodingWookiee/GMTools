using Caliburn.Micro;
using DiceRoller.ViewModels;
using System;
using System.Windows;

namespace DiceRoller
{
    public class Bootstrapper : BootstrapperBase
    {

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {

            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
