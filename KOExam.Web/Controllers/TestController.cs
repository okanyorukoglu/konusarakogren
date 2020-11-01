using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KOExam.Core.Entities;
using KOExam.Data.Repositories;
using KOExam.Service.Services;
using KOExam.Web.DTOs;
using KOExam.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace KOExam.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly IWiredService _wired;
        private readonly IWiredRepository _repository;

        public TestController(IWiredService wired, IWiredRepository repository)
        {
            _wired = wired;
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            List<string> titles = new List<string>();
            titles.Add(await _wired.getArticleTitle("https://www.wired.com", WiredEx.GetXpath("title1")));
            titles.Add(await _wired.getArticleTitle("https://www.wired.com", WiredEx.GetXpath("title2")));
            titles.Add(await _wired.getArticleTitle("https://www.wired.com", WiredEx.GetXpath("title3")));
            titles.Add(await _wired.getArticleTitle("https://www.wired.com", WiredEx.GetXpath("title4")));
            titles.Add(await _wired.getArticleTitle("https://www.wired.com", WiredEx.GetXpath("title5")));



            ViewBag.title1 = _wired.titleFix(titles[0]);
            ViewBag.title2 = _wired.titleFix(titles[1]);
            ViewBag.title3 = _wired.titleFix(titles[2]);
            ViewBag.title4 = _wired.titleFix(titles[3]);
            ViewBag.title5 = _wired.titleFix(titles[4]);
            return View();
        }

        public async Task<ActionResult> getWiredBody(string XPath)
        {
            string articleUrl = await _wired.getArticleLink("https://www.wired.com/", "//*[@id='app-root']" + XPath, "href");
            string articleBody = await _wired.getArticleBody("https://www.wired.com/", articleUrl, "//*[@id='app-root']/div/div[3]/div/div[3]/div[1]/div[2]/main/article/div[1]");
            return Json(articleBody);
        }

        [HttpPost]
        public ActionResult CreateExam(TestDTO testDTO)
        {


            if (ModelState.IsValid)
            {
                Test test = new Test()
                {

                    WiredBody = testDTO.Question.WiredBody,
                    Questions = testDTO.Question.Questions,
                    Title = testDTO.Question.Title,
                    CreatedDate = DateTime.Now
                };

                List<Question> Questions = new List<Question>();

                foreach (var question in testDTO.Question.Questions)
                {
                    Question Question = new Question()
                    {
                        A_Option = question.A_Option,
                        B_Option = question.B_Option,
                        C_Option = question.C_Option,
                        D_Option = question.D_Option,
                        QuestionText = question.QuestionText,
                        TrueSolution = question.TrueSolution,
                        TestId = question.TestId,
                        QuestionNumber = question.QuestionNumber
                    };

                    Questions.Add(Question);
                }

                test.Questions = Questions;

                int result = _repository.CreateExam(test);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Home");
                }


            }
            else
            {
                ViewBag.ErrorMessage = "Lütfen boş alanları doldurunuz!";
                return View();
            }

            return RedirectToAction("CreateExam", "Home");



        }
        
    }
}
