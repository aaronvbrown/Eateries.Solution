using System.Collections.Generic;

namespace Eateries.Models

{
public class Restaurants
  {

  // Hey all, think I mighta found it! You're gonna be so mad if this is it.
  // public int RestaurantId needs to be public int RestaurantsId (plural)
  // Entity wants it to match the name of the class. 
  // You'll also need to update the name of the column in the database accordingly. 
  // Fingers crossed! -Ryan
  public int RestaurantsId { get; set;  }
  public string Name {get; set; }
  public string Description { get; set; }
  public int CuisineId { get; set; }
  public Cuisine Cuisine { get; set; }
  public List<RestaurantsTag> JoinEntities { get;}
 }
}