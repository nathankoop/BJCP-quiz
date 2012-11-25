using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bjcp.quiz.web.ViewModels
{
    public class SrmViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Low { get; set; }
        public int? High { get; set; }
        public bool Correct
        {
            get
            {
                return true;
            }
        }
        
        public SrmViewModel(Srm srm)
        {
            this.Id = srm.Id;
            this.Name = srm.Name;
            this.Low = srm.Low;
            this.High = srm.High;
       }
    }
}