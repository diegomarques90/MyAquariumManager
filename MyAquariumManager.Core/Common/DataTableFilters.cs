namespace MyAquariumManager.Core.Common
{
    public class DataTableFilters
    {
        public DataTableFilters(string draw, int start, int length, string sortColumnIndex, string sortDirection)
        {
            Draw = draw;
            Start = start;
            Length = length;
            SortColumnIndex = sortColumnIndex;
            SortDirection = sortDirection;
        }

        public string Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public string SortColumnIndex { get; set; }
        public string SortDirection { get; set; }
        public string SortColumnName { get; set; }

        public void SetSortColumnName(string sortColumnName)
        {
            SortColumnName = sortColumnName;
        }
    }
}
