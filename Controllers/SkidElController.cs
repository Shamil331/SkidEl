using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SkidEl.Controllers
{
    public class SkidElController : Controller
    {
        public readonly SkidElContext _context;

        // GET: MainPage
        public SkidElController(SkidElContext SkidElcontext)
        {
            _context = SkidElcontext;
        }
        public IActionResult MainPage()
        {
            List<Category> categories = _context.Categories.ToList();
            List<Discount> discounts = _context.Discounts.ToList();
            discounts = discounts.OrderByDescending(x => 1 - (x.NowPrice / x.PreviousPrice)).Take(20).ToList();
            foreach (var i in discounts)
            {
                i.DiscountImages = _context.DiscountImages.Where(t => t.DiscountId == i.Id).ToList();
            }
            //List<string> discountImageUrls = discounts.Select(t => t.DiscountImages.Select(x => x.ImageUrl).FirstOrDefault()).ToList();
            Dictionary<Discount, string> DiscountsAndImages = new Dictionary<Discount, string>();
            foreach(var i in discounts)
            {
                string CurrentDiscountImageUrl = i.DiscountImages.Select(t => t.ImageUrl).FirstOrDefault();
                if (CurrentDiscountImageUrl == null) continue;
                DiscountsAndImages.Add(i, CurrentDiscountImageUrl);
            }
            var tuple = new Tuple<List<Category>, Dictionary<Discount,string>>(categories, DiscountsAndImages);
            return View(tuple);
        }
    }
}
