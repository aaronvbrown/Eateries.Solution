namespace Eateries.Models
{
    public class RestaurantsTag
    {
        public int RestaurantsTagId { get; set; }
        public int RestaurantsId { get; set; }
        public Restaurants Restaurants { get; set; }
        public int TagId {get; set; }
        public Tag Tag {get; set; }
    }
}