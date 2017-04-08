using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace CHSNS
{
    public class EqualsClientValidator :
        DataAnnotationsModelValidator<EqualsClientAttribute>
    {
        string _message;
        string _id;
        string _idConfirm;
        public EqualsClientValidator(ModelMetadata metadata, 
            ControllerContext context
          , EqualsClientAttribute attribute)
            : base(metadata, context, attribute)
        {
            _id = attribute.OriginalProperty;
            _idConfirm = attribute.ConfirmProperty;
            _message = attribute.ErrorMessage;
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _message,
                ValidationType = "equalsClient"
            };
            rule.ValidationParameters.Add("id1", _id);
            rule.ValidationParameters.Add("id2", _idConfirm);
            return new[] { rule };
        }
    }
}
