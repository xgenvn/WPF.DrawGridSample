using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Canvas.GridDraw.Annotations;

namespace Canvas.GridDraw
{
    public class Processor : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GridLoaded(object sender, RoutedEventArgs e)
        {
            (sender as MainWindow)?.MakeTileGrid(40);
        }
    }
}