namespace Gu.Wpf.PropertyGrid
{
    using System.CodeDom;
    using System.ComponentModel;

    [TypeConverter(typeof(GridCellConverter))]
    public class GridCell
    {
        public GridCell()
        {
        }

        public GridCell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}