using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CHSNS.Validator
{
    public class ValidatorRegister
    {
        public static void RegisterAdapter()
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(EqualsClientAttribute),typeof(EqualsClientValidator));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ContainsCharacterAttribute), typeof(ContainsCharacterValidator));
        }
    }
}
