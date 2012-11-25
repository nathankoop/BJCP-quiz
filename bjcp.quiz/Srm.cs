using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bjcp.quiz
{
    public class Srm:ICloneable
    {
        public Srm() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Low { get; set; }
        public int? High { get; set; }

        public Srm(int id, string name, int low) : this(id, name, low, null) { }

        public Srm(int id, string name, int low, int? high)
        {
            this.Id = id;
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
            if (srm == null)
                return false;
            if (srm.Name == null)
                return false;

            return
                this.Id == srm.Id &&
                this.Name.ToLowerInvariant().IgnorePunctuation() == srm.Name.ToLowerInvariant().IgnorePunctuation() &&
                this.High == srm.High &&
                this.Low == srm.Low;
        }

        public object Clone()
        {
            return new Srm(this.Id, this.Name, this.Low, this.High);
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

        public static List<Srm> GetMasterSrms()
        {
            var srms = new List<Srm>();
            srms.Add(new Srm(1, "Straw", 2, 3));
            srms.Add(new Srm(2, "Yellow", 3, 4));
            srms.Add(new Srm(3, "Gold", 5, 6));
            srms.Add(new Srm(4, "Amber", 6, 9));
            srms.Add(new Srm(5, "Deep Amber/Light Copper", 10, 14));
            srms.Add(new Srm(6, ", Copper", 14, 17));
            srms.Add(new Srm(7, "Deep Copper/Light Brown", 17, 18));
            srms.Add(new Srm(8, "Brown", 19, 22));
            srms.Add(new Srm(9, "Dark Brown", 22, 30));
            srms.Add(new Srm(10, "Very Dark Brown", 30, 35));
            srms.Add(new Srm(11, "Black", 30));
            srms.Add(new Srm(12, "Black, Opaque", 40));

            return srms;
        }
        
        public static List<Srm> GetQuiz()
        {
            var quiz = GetMasterSrms();
            quiz.ForEach(srm => srm.Name = "");
            return quiz;
        }


    }


}
