using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KOExam.Web.Models;
using Microsoft.AspNetCore.Authorization;
using KOExam.Core.Entities;
using KOExam.Service.Services;
using KOExam.Data.Repositories;
using KOExam.Web.DTOs;
using KOExam.Data.Context;

namespace KOExam.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IWiredRepository _wired;
        private readonly KOContext _context;

        public HomeController(IWiredRepository wired, KOContext context)
        {
           _wired = wired;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Test> userTests;
            userTests = _wired.GetAllArticles()
                    .OrderBy(x => x.ArticleId)
                    .ToList();

            return View(userTests);
        }

        public IActionResult Delete(int id)
        {
            var article = _wired.GetById(id);
            _context.Tests.Remove(article);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }


        public IActionResult GetTest(int id)
        {
            Test test = _context.Tests.Where(x => x.Id == id).FirstOrDefault();
            List<Question> Questions = _context.Questions.Where(x=>x.Test == test).ToList();
            test.Questions = Questions.ToList();

            if (test != null)
            {
                return View(test);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

            
        }

    }
    

