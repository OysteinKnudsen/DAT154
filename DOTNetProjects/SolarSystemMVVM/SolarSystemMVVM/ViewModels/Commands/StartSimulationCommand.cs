using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SolarSystemMVVM.ViewModels.Commands
{
    public class StartSimulationCommand : ICommand
    {
        public MainWindowViewModel _viewModel;

        public StartSimulationCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.StartSimulation();
        }
    }
}
