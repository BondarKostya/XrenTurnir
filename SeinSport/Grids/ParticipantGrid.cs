using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SeinSport.Grids
{
    class ParticipantGrid : Grid
    {
        public List<ParticipantRow> rows = new List<ParticipantRow>();

        //public setupRow
    }

    class ParticipantRow
    {
        Label name = new Label();
        Label year = new Label();
        Label club = new Label();
        Label weight = new Label();
        Label sity = new Label();
    }
}
