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
            //foreach (var i in discounts)
            //{
            //    i.DiscountImages = _context.DiscountImages.Where(t => t.DiscountId == i.Id).ToList();
            //}
            discounts.ForEach(i => i.DiscountImages.Union(_context.DiscountImages.Where(t => t.DiscountId == i.Id)).ToList());
            //List<string> discountImageUrls = discounts.Select(t => t.DiscountImages.Select(x => x.ImageUrl).FirstOrDefault()).ToList();
            Dictionary<Discount, string> DiscountsAndImages = new Dictionary<Discount, string>();
            foreach (var i in discounts)
            {
                string CurrentDiscountImageUrl = i.DiscountImages.Select(t => t.ImageUrl).FirstOrDefault();
                if (CurrentDiscountImageUrl == null) continue;
                DiscountsAndImages.Add(i, CurrentDiscountImageUrl);
            }
            var tuple = new Tuple<List<Category>, Dictionary<Discount, string>>(categories, DiscountsAndImages);
            return View(tuple);
        }
        public IActionResult DiscountPage(int _discount)
        {
            Discount discount = _context.Discounts.Where(d => d.Id==_discount).FirstOrDefault();
            discount.DiscountImages.Union(_context.DiscountImages.Where(t => t.DiscountId == discount.Id).ToList());
            List<Discount> _similarDiscounts = _context.Discounts.Where(d => d.SubcategoryId == discount.SubcategoryId && d.Id!=discount.SubcategoryId).ToList();
            Random rnd = new Random();
            _similarDiscounts=_similarDiscounts.OrderBy(item => rnd.Next()).Take(10).ToList();
            _similarDiscounts.ForEach(i => i.DiscountImages.Union(_context.DiscountImages.Where(t => t.DiscountId == i.Id)).ToList());
            Dictionary<Discount, string> similarDiscountsAndImages = new Dictionary<Discount, string>();
            foreach (var i in _similarDiscounts)
            {
                string CurrentDiscountImageUrl = i.DiscountImages.Select(t => t.ImageUrl).FirstOrDefault();
                if (CurrentDiscountImageUrl == null) continue;
                similarDiscountsAndImages.Add(i, CurrentDiscountImageUrl);
            }
            Tuple<Discount, Dictionary<Discount, string>> tuple = new Tuple<Discount, Dictionary<Discount, string>>(discount, similarDiscountsAndImages);
            return View(tuple);
        }
        public IActionResult DiscountsListPage(string category=null)
        {
            List<Discount> discounts = new List<Discount>();
            List<Subcategory> subcategories= _context.Subcategories.Where(c => c.CategorieId == _context.Categories.Where(c => c.Name==category).Select(c=>c.Id).FirstOrDefault()).ToList();
            if (category == null)
            {
                discounts = _context.Discounts.ToList();
                
            }
            else
            {
                foreach (var i in subcategories)
                {
                    discounts.AddRange(_context.Discounts.Where(x => x.SubcategoryId == i.Id).ToList());
                }
            }
            discounts.ForEach(i => i.DiscountImages.Union(_context.DiscountImages.Where(t => t.DiscountId == i.Id)).ToList());
            Dictionary<Discount, string> DiscountsAndImages = new Dictionary<Discount, string>();
            foreach (var i in discounts)
            {
                string CurrentDiscountImageUrl = i.DiscountImages.Select(t => t.ImageUrl).FirstOrDefault();
                if (CurrentDiscountImageUrl == null) continue;
                DiscountsAndImages.Add(i, CurrentDiscountImageUrl);
            }
            var tuple = new Tuple<Dictionary<Discount, string>, string, List<Category>, List<Shop>>(DiscountsAndImages, category, _context.Categories.ToList(), _context.Shops.ToList());
            return View(tuple);
        }
    }
}
