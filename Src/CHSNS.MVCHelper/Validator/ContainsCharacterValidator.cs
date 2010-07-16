using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CHSNS
{
    public class ContainsCharacterValidator :
        DataAnnotationsModelValidator<ContainsCharacterAttribute>
    {
        string _message;
        //string _id;
        bool _hasLetter;
        bool _hasNumeric;
        bool _hasChineseCharacter;
        bool _hasSpecialCharacter;
        public ContainsCharacterValidator(ModelMetadata metadata,
            ControllerContext context
          , ContainsCharacterAttribute attribute)
            : base(metadata, context, attribute)
        {
           // _id = attribute.;
            _hasLetter = attribute.HasLetter;
            _hasNumeric = attribute.HasNumeric;
            _hasChineseCharacter = attribute.HasChineseCharacter;
            _hasSpecialCharacter = attribute.HasSpecialCharacter;
            _message = attribute.ErrorMessage;
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _message,
                ValidationType = "containsChar"
            };
           // rule.ValidationParameters.Add("id", _id);
            rule.ValidationParameters.Add("hl", _hasLetter);
            rule.ValidationParameters.Add("hn", _hasNumeric);
            rule.ValidationParameters.Add("hc", _hasChineseCharacter);
            rule.ValidationParameters.Add("hs", _hasSpecialCharacter);
            return new[] { rule };
        }
    }
}
