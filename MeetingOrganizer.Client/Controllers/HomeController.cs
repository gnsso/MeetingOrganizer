using MeetingOrganizer.Server.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MeetingOrganizer.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly string baseUrl = "http://localhost:52507/";

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            using (var client = SetupClient())
            {
                using (var response = await client.GetAsync("api/meetings"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var meetings = JsonConvert.DeserializeObject<List<MeetingModel>>(json);
                        return View(meetings);
                    }
                    else
                    {
                        return Redirect("Error");
                    }
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            using (var client = SetupClient())
            {
                using (var response = await client.GetAsync($"api/meetings/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var meeting = JsonConvert.DeserializeObject<MeetingModel>(json);
                        return View(meeting);
                    }
                    else
                    {
                        return View("Error");
                    }
                }
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([System.Web.Http.FromBody]MeetingModel model)
        {
            using (var client = SetupClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("api/meetings/plan", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("Error");
                    }
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            using (var client = SetupClient())
            {
                using (var response = await client.GetAsync($"api/meetings/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var meeting = JsonConvert.DeserializeObject<MeetingModel>(json);
                        return View(meeting);
                    }
                    else
                    {
                        return View("Error");
                    }
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> Save([System.Web.Http.FromBody]MeetingModel model)
        {
            using (var client = SetupClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("api/meetings/update", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("Error");
                    }
                }
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            using (var client = SetupClient())
            {
                using (var response = await client.PostAsync($"api/meetings/{id}/delete", null))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("Error");
                    }
                }
            }
        }

        private HttpClient SetupClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}