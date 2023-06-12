using AutoMapper;
using CheckNip.DB;
using CheckNip.DB.Models;
using CheckNip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

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
                    //string json = await client.DownloadStringTaskAsync(apiUrl);
                    string json = "{\r\n  \"result\" : {\r\n    \"subject\" : {\r\n      \"authorizedClerks\" : [ ],\r\n      \"regon\" : \"regon\",\r\n      \"restorationDate\" : \"2019-02-21\",\r\n      \"workingAddress\" : \"ul/ Prosta 49 00-838 Warszawa\",\r\n      \"hasVirtualAccounts\" : true,\r\n      \"statusVat\" : \"Zwolniony\",\r\n      \"krs\" : \"0000636771\",\r\n      \"restorationBasis\" : \"Ustawa o podatku od towarów i usług art. 96\",\r\n      \"accountNumbers\" : [ \"90249000050247256316596736\", \"90249000050247256316596736\" ],\r\n      \"registrationDenialBasis\" : \"Ustawa o podatku od towarów i usług art. 96\",\r\n      \"nip\" : \"1111111111\",\r\n      \"removalDate\" : \"2019-02-21\",\r\n      \"partners\" : [ ],\r\n      \"name\" : \"ABC Jan Nowak\",\r\n      \"registrationLegalDate\" : \"2018-02-21\",\r\n      \"removalBasis\" : \"Ustawa o podatku od towarów i usług Art. 97\",\r\n      \"pesel\" : null,\r\n      \"representatives\" : [ {\r\n        \"firstName\" : \"Jan\",\r\n        \"lastName\" : \"Nowak\",\r\n        \"nip\" : \"1111111111\",\r\n        \"companyName\" : \"Nazwa firmy\"\r\n      }, {\r\n        \"firstName\" : \"Jan\",\r\n        \"lastName\" : \"Nowak\",\r\n        \"nip\" : \"1111111111\",\r\n        \"companyName\" : \"Nazwa firmyyyy\"\r\n      } ],\r\n      \"residenceAddress\" : \"ul/ Chmielna 85/87 00-805 Warszawa\",\r\n      \"registrationDenialDate\" : \"2019-02-21\"\r\n    },\r\n    \"requestDateTime\": \"19-11-2019 14:58:49\",\r\n    \"requestId\" : \"d2n10-84df1a1\"\r\n  }\r\n}";

                    _resultRoot = JsonConvert.DeserializeObject<ResultRoot>(json);                  
                }
                catch (WebException ex)
                {
                    ViewBag.ErrorMessage = $"Wystąpił błąd podczas pobierania danych. {ex.Response}";
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