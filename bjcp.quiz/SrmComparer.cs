using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bjcp.quiz
{
    public class SrmComparer
    {
        public IList<Srm> SrmItems;
        public IList<Srm> SrmItemsOrganized { get; private set; }

        public SrmComparer(IList<Srm> organizedSrms)
        {
            SrmItemsOrganized = organizedSrms;
            SrmItems = new List<Srm>();
        }

        public bool IsCorrect()
        {
            int i=0;
            foreach (var orgSrm in SrmItemsOrganized)
            {
                if (i >= SrmItems.Count)
                    return false;
                var srm =  SrmItems.ElementAt(i);
                if (!orgSrm.Equals(srm))
                    return false;
                i++;
            }
            return true;
        }
    }
}
