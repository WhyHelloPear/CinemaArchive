namespace Core.Application.DTOs
{
    public class FilmDto
    {
        public int FilmId { get; set; }
        public string FilmTitle { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public decimal GrossRevenue { get; set; }
    }
}