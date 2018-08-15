using System.Windows;
using System.Windows.Input;

namespace DropDownButtonSample
{
    public class ViewModel
    {

        public ICommand AddCommand => new RelayCommand(() =>
        {
            MessageBox.Show("Add command executed");
        });

        public ICommand MoveCommand => new RelayCommand(() =>
        {
            MessageBox.Show("Move command executed");
        });

        public ICommand DeleteCommand => new RelayCommand(() =>
        {
            MessageBox.Show("Delete command executed");
        });
    }
}