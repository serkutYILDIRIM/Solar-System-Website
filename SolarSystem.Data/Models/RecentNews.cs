using System.ComponentModel.DataAnnotations;

namespace SolarSystem.Data.Models
{
    public class RecentNews
    {
        public int NewsId { get; set; }
        [MaxLength(50)]
        public string NewsName { get; set; }
        [MaxLength(100)]
        public string NewsSubject { get; set; }
        public string NewsContent { get; set; }
        [MaxLength(250)]
        public string Picture { get; set; }
    }
}
