using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Canvas.GridDraw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Logic:
    /// - resize when parent resize
    /// - resize sample image when parent resize
    /// - 
    /// </summary>
    public partial class MainWindow : Window
    {
        private Processor _vm;

        public MainWindow()
        {
            InitializeComponent();

            if (this.DataContext is null)
            {
                _vm = new Processor();
                this.DataContext = _vm;
            }

            this.Loaded += _vm.GridLoaded;
        }

        private void MainCanvas_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Debug.WriteLine(e.NewSize);
         /*   double TOLERANCE = Double.MinValue;
            if (Math.Abs(e.NewSize.Height - e.PreviousSize.Height) > TOLERANCE)
            {
                Debug.WriteLine(e.NewSize);
                this.MainCanvas.Width = e.NewSize.Height;
                this.MainCanvas.Height = e.NewSize.Height;
                this.UpdateLayout();
            }

            if (Math.Abs(e.NewSize.Width - e.PreviousSize.Width) > TOLERANCE)
            {
                Debug.WriteLine(e.NewSize);
                this.MainCanvas.Width = e.NewSize.Width;
                this.MainCanvas.Height = e.NewSize.Width;
                this.UpdateLayout();
            }*/
        }

        private void MainCanvas_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("mousedown", e);
        }

        private void MainCanvas_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("mouseup", e);
        }

        private void MainCanvas_OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("mouserightdown", e);
        }

        private void MainCanvas_OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("mouserightup", e);
        }
        private void MainCanvas_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("mouseleftdown", e);
        }

        private void MainCanvas_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("mouseleftup", e);
        }

        public void MakeTileGrid(double tileSize)
        {
            var containerWidth = MainCanvas.RenderSize.Width;
            var numberOfTile = (int) (containerWidth / tileSize);

            //set grid count
/*            SampleTileGrid.ColumnCount = numberOfTile;
            SampleTileGrid.RowCount = numberOfTile;
            SampleTileGrid.ShowGridLines = false;
            //set default column width
            SampleTileGrid.ColumnWidth = new GridLength(tileSize);

            //set default row height
            SampleTileGrid.RowHeight = new GridLength(tileSize);*/


            for (int tileIndex = 0; tileIndex < numberOfTile * numberOfTile; tileIndex++)
            {
                var rowIndex = (int) (tileIndex / numberOfTile);
                var columnIndex= tileIndex % numberOfTile;
                Debug.WriteLine($"{rowIndex}, {columnIndex}");

                var tileContainer = new Border()
                {
                    BorderThickness = new Thickness(0),
                    BorderBrush = Brushes.Transparent,
                    Width = 40,
                    Height = 40,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(40 * rowIndex, 40 * columnIndex, 0, 0),
                };

                var tile = new Rectangle
                {
                    Fill = Brushes.Transparent,
                    Stroke = Brushes.White,
                    StrokeThickness = 1,
                    Margin = new Thickness(-1,-1,0,0),
                    Width = 41,
                    Height = 41,
                };

                tile.MouseEnter += OnMouseEnterTile;
                tile.MouseLeave += OnMouseLeaveTile;

                tileContainer.Child = tile;

                SampleTileGrid.Children.Add(tileContainer);
            }
        }

        private void OnMouseLeaveTile(object sender, MouseEventArgs e)
        {
            if (sender is Rectangle tile) tile.Fill = Brushes.Transparent;
        }

        private static void OnMouseEnterTile(object sender, MouseEventArgs e)
        {
            if (sender is Rectangle tile) tile.Fill = !Equals(tile.Fill, Brushes.Aqua) ? Brushes.Aqua : Brushes.Transparent;
        }

        public Brush GetRandomColor()
        {
            var r = new Random();

            Brush brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
            return brush;
        }
    }
}
