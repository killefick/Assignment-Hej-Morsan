using System;

namespace Logic_Lib
{
    public class Relatives
    {
        public string name{get; set;}
        public int yearBorn{get; set;}
        public string phoneNr{get; set;}
        public int contactF{get; set;}

        public Relatives(string inName, int inYear, string inPhoneNr, int inContactF)
        {
            this.name = inName;
            this.yearBorn = inYear;
            this.phoneNr = inPhoneNr;
            this.contactF = inContactF;
        }
        
        public override string ToString()
        {
            return "\nNamn: "+ name+" \nFödd: "+yearBorn+" \nTelefonnummer: "+phoneNr;
        }
        
    }
}