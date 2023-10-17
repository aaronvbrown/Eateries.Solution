using Microsoft.AspNetCore.Mvc;
using Eateries.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Eateries.Controllers
{
  public class TagsController : Controller
  {
    private readonly EateriesContext _db;
    public TagsController(EateriesContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Tags.ToList());
    }

    public ActionResult Details(int id)
    {
      Tag thisTag = _db.Tags
        .Include(tag => tag.JoinEntities)
        .ThenInclude(join => join.Restaurants)
        .FirstOrDefault(tag => tag.TagId == id);
      return View(thisTag);
    }

  }
}