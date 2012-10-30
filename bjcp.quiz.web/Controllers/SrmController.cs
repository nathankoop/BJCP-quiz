using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bjcp.quiz.web.ViewModels;
using AutoMapper;

namespace bjcp.quiz.web.Controllers
{
    public class SrmController : Controller
    {
        //
        // GET: /Srm/

        public ActionResult Index()
        {
            var quiz = new SrmQuizViewModel();
            quiz.UserSrms = Srm.GetQuiz();
            quiz.Message = "";
            return View(quiz);
        }

        [HttpPost]
        public ActionResult Index(SrmQuizViewModel quiz)
        {
            var comparer = new SrmComparer(Srm.GetMasterSrms());
            comparer.QuizSrms = quiz.UserSrms;
            quiz.Message = comparer.IsCorrect() ? "Correct" : "Incorrect";
            return View(quiz);
        }

    }
}
