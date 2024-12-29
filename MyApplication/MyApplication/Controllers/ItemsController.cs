using Microsoft.AspNetCore.Mvc;
using MyApplication.Models;

namespace MyApplication.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {
            var item = new Item() { Name = "KeyBoard"};
            return View(item);
        }

        //http://localhost:5046/items/edit?id=4
        //http://localhost:5046/items/edit/4
        public IActionResult Edit(int  id)
        {
            return Content("id : " + id);
        }

    }
}
