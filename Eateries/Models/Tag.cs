using System.Collections.Generic;

namespace Eateries.Models
{
    public class Tag
      {
          public int TagId { get; set;}
          public string Title { get; set; }
          public List<RestaurantsTag> JoinEntities { get;}
      }
}