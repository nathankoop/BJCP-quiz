using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bjcp.quiz.web.ViewModels;

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
            return View(quiz);
        }

    }
}
