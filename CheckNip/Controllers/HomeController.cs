using AutoMapper;
using CheckNip.DB;
using CheckNip.DB.Models;
using CheckNip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using CheckNip.MockData;

namespace CheckNip.Controllers
{
    public class HomeController : Controller
    {
        private readonly CheckNipContext _context;
        private readonly IMapper _mapper;
        private static ResultRoot _resultRoot;
        
        public HomeController(CheckNipContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string nip)
        {
            string date = $"?date={DateTime.Now.ToString("yyyy-MM-dd")}";
            string apiUrl = $"https://wl-api.mf.gov.pl/api/search/nip/{nip + date}";

            using (WebClient client = new WebClient())
            {
                try
                {
                    string json = await client.DownloadStringTaskAsync(apiUrl);
                    //string json = Data.jsonResult;//dla testow

                    _resultRoot = JsonConvert.DeserializeObject<ResultRoot>(json);                  
                }
                catch (WebException ex)
                {
                    ViewBag.ErrorMessage = $"Wystąpił błąd podczas pobierania danych. Sprawdź poprawność numeru NIP.";
                    return View("Index");
                }
                try
                {
                    SubjectDb subjectDb = _mapper.Map<SubjectDb>(_resultRoot.Result.Subject);
                    if (subjectDb != null)
                    {
                        _context.Add(subjectDb);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (Exception)
                {
                    ViewBag.ErrorMessage = "Błąd przy zapisie do bazy danych";                   
                }
               
                return View("Result", _resultRoot);
            }
        }
    }
}