using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bjcp.quiz
{
    public class Srm:ICloneable
    {
        public string Name { get; set; }
        public int Low { get; set; }
        public int? High { get; set; }

        public Srm(string name, int low) : this(name, low, null) { }

        public Srm(string name, int low, int? high)
        {
            this.Name = name;
            this.Low = low;
            this.High = high;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Srm))
                return false;
            
            return Equals(obj as Srm);
        }

        public bool Equals(Srm srm)
        {
            return 
                this.Name.ToLowerInvariant() == srm.Name.ToLowerInvariant() &&
                this.High == srm.High &&
                this.Low == srm.Low;
        }

        public object Clone()
        {
            return new Srm(this.Name, this.Low, this.High);
        }

        public override string ToString()
        {
            //HACK: This is poor
            if (High == null)
            {
                return String.Format("{0} - {1}+", Name, Low);
            }
            else
            {
                return String.Format("{0} - {1}, {2}", Name, Low, High);
            }
        }
    }
}
