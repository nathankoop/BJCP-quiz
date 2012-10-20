using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bjcp.quiz
{
    public class SrmComparer
    {
        public IList<Srm> QuizSrms;
        public IList<Srm> SrmItemsOrganized { get; private set; }

        public SrmComparer(IList<Srm> masterSrms)
        {
            SrmItemsOrganized = masterSrms;
            QuizSrms = new List<Srm>();
        }

        public bool IsCorrect()
        {
            int i=0;
            foreach (var orgSrm in SrmItemsOrganized)
            {
                if (i >= QuizSrms.Count)
                    return false;
                var srm =  QuizSrms.ElementAt(i);
                if (!orgSrm.Equals(srm))
                    return false;
                i++;
            }
            return true;
        }
    }
}
