using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bjcp.quiz.web.ViewModels
{
    public class SrmQuizViewModel
    {
        public SrmQuizViewModel() { UserSrms = new List<SrmViewModel>(); }
        public List<SrmViewModel> UserSrms { get; set; }
        public string Message { get; set; }
    }
}