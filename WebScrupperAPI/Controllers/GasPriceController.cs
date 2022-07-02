using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebScrupperAPI.Model;

namespace WebScrupperAPI.Controllers
{
    public class GasPriceController : Controller
    {
        [Route("[controller]")]
        // GET: GasPrice
        [HttpGet]
        public async Task<string> GetAsync()
        {
            GasPrice gasPrice = new GasPrice();
            string url = "https://www.ok.dk/privat/produkter/ok-kort/benzinpriser";
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);

            var startingPlace = response.Substring(response.IndexOf("gridcell"));
            char[] num = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            var blyfriStep1 = startingPlace.Substring(startingPlace.IndexOfAny(num), startingPlace.IndexOfAny(num) + 10);
            var BlyfriNumber = blyfriStep1.Substring(0, blyfriStep1.LastIndexOfAny(num) + 1);

            var priceStep1 = startingPlace.Substring(startingPlace.IndexOfAny(num), startingPlace.IndexOfAny(num) + 200);
            var priceStep2 = priceStep1.Substring(10, priceStep1.LastIndexOfAny(num) + 1);
            var priceStep3 = priceStep2.Substring(priceStep2.IndexOfAny(num));
            string price = priceStep3.Substring(0, priceStep3.Length - 10);

            gasPrice.Name = BlyfriNumber;
            gasPrice.Value = price;


            var jObject = JsonConvert.SerializeObject(gasPrice);

            return jObject;

        }
            // GET: GasPrice/Details/5
            public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GasPrice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GasPrice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GasPrice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GasPrice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GasPrice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GasPrice/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
