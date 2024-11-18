namespace Client.Matter.Models.External.DTOs
{
    public class MatterSearchResult
    {
        public int TotalResults { get; set; }
        public int ReturnedResults { get; set; }
        public int Offset { get; set; }
        public int Index { get; set; }
        public string OrderBy { get; set; }
        public string SearchOrder { get; set; }
        public string SearchError { get; set; }
        public List<MatterResult> Results { get; set; }
    }
}