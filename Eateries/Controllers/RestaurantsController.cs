using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Eateries.Models;
using System.Collections.Generic;
using System.Linq;

namespace Eateries.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly EateriesContext _db;

    public RestaurantsController(EateriesContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Restaurants> model = _db.Restaurants
                            .Include(restaurant => restaurant.Cuisine)
                            .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisine, "CuisineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurants restaurant)
    {
      if (restaurant.CuisineId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Restaurants thisRestaurant = _db.Restaurants
                          .Include(restaurant => restaurant.Cuisine)
                          .FirstOrDefault(restaurant => restaurant.RestaurantsId == id);
      return View(thisRestaurant);
    }

    public ActionResult Edit(int id)
    {
      Restaurants thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantsId == id);
      ViewBag.CuisineId = new SelectList(_db.Cuisine, "CuisineId", "Name");
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult Edit(Restaurants restaurant)
    {
      _db.Restaurants.Update(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Restaurants thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantsId == id);
      return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Restaurants thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantsId == id);
      _db.Restaurants.Remove(thisRestaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}