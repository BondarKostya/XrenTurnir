using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SeinSport.Grids
{
    class CategoryGrid : Grid
    {
        List<ParticipantGrid> sections = new List<ParticipantGrid>();

        public void setupSections(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ParticipantGrid grid = new ParticipantGrid();
                grid.Height = 200;
                grid.Background = new SolidColorBrush(Colors.Red);
                SetRow(grid, i);
                SetColumn(grid, 0);
                Children.Add(grid);
                sections.Add(grid);
            }
        }

        public void setSectionMargin(Thickness margin)
        {
            foreach (ParticipantGrid grid in sections)
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
