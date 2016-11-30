using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SeinSport.Grids
{
    class ParticipantGrid : Grid
    {
        List<ParticipantGrid> childs = new List<ParticipantGrid>();
        List<Control> values = new List<Control>()

        public void setupSections<T: Control>(int count,T type)
        {
            for (int i = 0; i < count; i++)
            {
                ParticipantGrid grid = new ParticipantGrid();
                grid.Height = 200;
                grid.Background = new SolidColorBrush(Colors.Red);
                SetRow(grid, i);
                SetColumn(grid, 0);
                Children.Add(grid);
                childs.Add(grid);  
            }
        }

        public void setupRow(int section, int rowCount)
        {
            var grid = childs[section];

            grid.NumberOfRows = rowCount;
        }

        public void setSectionMargin(Thickness margin)
        {
            foreach (ParticipantGrid grid in childs)
            {
                grid.Margin = margin;
            }
        }

        public int NumberOfRows
        {
            get { return RowDefinitions.Count; }
            set
            {
                RowDefinitions.Clear();
                for (int i = 0; i < value; i++)
                {
                    RowDefinition row = new RowDefinition();
                    row.Height = new GridLength(1, GridUnitType.Star);
                    RowDefinitions.Add(row);
                }
                setupSections(value);
                    
            }
        }
    }
}
