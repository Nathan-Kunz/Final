using Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class HomeController : Controller
    {
        

        private EntertainmentAgencyExampleContext context { get; set; }
        private iEntRepository repo;

        public HomeController(iEntRepository temp)
        {
            repo = temp;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var blah = repo.Entertainers.ToList();
            return View(blah);
           
        }
        public IActionResult Details(int id)
        {
            Entertainers record = repo.Entertainers.FirstOrDefault(e => e.EntertainerId == id);
            // retrieve the record with the specified id from db
            return View(record);
        }

        public IActionResult Edit(int id)
        {
            // retrieve the record with the specified id from db
            Entertainers record = repo.Entertainers.FirstOrDefault(e => e.EntertainerId == id);

            // return a view that allows the user to edit the record
            return View(record);
        }


        [HttpPost]
        public IActionResult Edit(Entertainers e)
        {
            if (ModelState.IsValid)
            {
                if (e.EntertainerId == 0)
                {
                    repo.SaveEntertainer(e);
                    return RedirectToAction("Index");
                }
                else
                {
                    Entertainers existingRecord = repo.Entertainers.FirstOrDefault(x => x.EntertainerId == e.EntertainerId);
                    if (existingRecord != null)
                    {
                        // Update the existing record with the new values
                        existingRecord.EntStageName = e.EntStageName;
                        existingRecord.EntStreetAddress = e.EntStreetAddress;
                        existingRecord.EntCity = e.EntCity;
                        existingRecord.EntState = e.EntState;
                        existingRecord.EntZipCode = e.EntZipCode;
                        existingRecord.EntWebPage = e.EntWebPage;
                        existingRecord.EntEmailAddress = e.EntEmailAddress;
                        existingRecord.EntPhoneNumber = e.EntPhoneNumber;

                        // Save changes to the database
                        repo.SaveChanges();

                        // Redirect to the Details page for the updated record
                        return RedirectToAction("Details", new { id = existingRecord.EntertainerId });
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }

            // If the model state is not valid, redisplay the edit form with the existing values
            return View(e);
        }

        public IActionResult Delete(int id)
        {
            Entertainers record = repo.Entertainers.FirstOrDefault(e => e.EntertainerId == id);
            if (record != null)
            {
                repo.DeleteEntertainer(record);
                repo.SaveChanges();
                return RedirectToAction("Privacy");
            }
            else
            {
                return NotFound();
            }
        }
        //return the create view
        public IActionResult Create()
        {
            return View();
        }
        //save and add the new to the database
        [HttpPost]
        public IActionResult SaveNew(Entertainers e)
        {
            if (ModelState.IsValid)
            {
               

                repo.SaveEntertainer(e);
                //ModelState.Clear();
                return RedirectToAction("Details", new { id = e.EntertainerId });
            }
            else
            {
                return View("Create", e);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
