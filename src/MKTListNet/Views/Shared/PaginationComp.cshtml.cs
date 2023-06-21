using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MKTListNet.Views.Shared
{
    public record PagingData
    {
        internal readonly int PageNumber;
        internal readonly int TotalPages;
        internal readonly int PageSize;
        internal readonly bool ShowPageCount = true;
        internal readonly string ActionPage = "Index";

        /// <summary>
        /// Create a paging data to use in pagination component.
        /// </summary>
        /// <param name="pgNumber">Page mumber</param>
        /// <param name="totalPg">Total pages</param>
        /// <param name="pgSize">Page size</param>
        /// <param name="showPageCount">Show page counter information</param>
        /// <param name="actionPage">The name of the action</param>
        public PagingData(int pgNumber, int totalPg, int pgSize, string actionPage = "Index", bool showPageCount = true)
        {
            ActionPage = actionPage;
            PageNumber = pgNumber;
            TotalPages = totalPg;
            PageSize = pgSize;
            ShowPageCount = showPageCount;
        }
    }

    public class PaginationCompModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
