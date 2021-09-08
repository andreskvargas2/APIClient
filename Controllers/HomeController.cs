using Newtonsoft.Json;
using PruebaTecnicaSxo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using static APICliente.ViewModels.Result;

namespace APICliente.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var urlAPI = WebConfigurationManager.AppSettings["urlAPI"];
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(urlAPI+"getFacturas");
            List<Factura> listFacturas = JsonConvert.DeserializeObject<List<Factura>>(json);

            return View(listFacturas);
        }

        [HttpPost]
        public async Task<ActionResult> AgregarFactura(Factura nuevaFactura)
        {
            var urlAPI = WebConfigurationManager.AppSettings["urlAPI"];
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(nuevaFactura);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(urlAPI+ "postNuevaFactura", httpContent);
            if (response.IsSuccessStatusCode)
                return Json(new ResultHttpRequest { estado = true }, JsonRequestBehavior.AllowGet);
            else
                return Json(new ResultHttpRequest { estado = false}, JsonRequestBehavior.AllowGet);
        }
    }
}