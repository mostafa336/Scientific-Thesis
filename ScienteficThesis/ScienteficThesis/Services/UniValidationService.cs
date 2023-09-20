using ScienteficThesis.Models;
using ScienteficThesis.Repository;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace ScienteficThesis.Services
{
    public class UniValidationService
    {
        private  University _u;
        private readonly IUni _ur;
        public UniValidationService(IUni ur) {
            _ur = ur; 

        }
        public void setModel(University u)
        {
            _u = u;

        }

        public Boolean EnglishNameValidation()
        {
            foreach (var c in _u.UniNameEn)
            {
                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
                    return false;
            }
            return true;
            
        }
        public Boolean ArabicNameValidation()
        {
                Regex regex = new Regex("[\u0600-\u06ff]|[\u0750-\u077f]|[\ufb50-\ufc3f]|[\ufe70-\ufefc]");

            if (regex.IsMatch(_u.UniNameAr))
            {
                
                return true;
            }
            else return false;
            

        }
        public Boolean ValidUni()
        {
            if(EnglishNameValidation() && ArabicNameValidation()){
                _ur.create(_u);
                return true;
            }
            return false;
        }
    }
}
