using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            // RuleFor(x => x.CreditCardNumber).CreditCard();
            RuleFor(x => x.CreditCardCVV).GreaterThanOrEqualTo(100);
            RuleFor(x => x.CreditCardCVV).LessThanOrEqualTo(999);
            RuleFor(x => x.ExpirationMonth).GreaterThan(0);
            RuleFor(x => x.ExpirationMonth).LessThanOrEqualTo(12);
            RuleFor(x => x.ExpirationYear).GreaterThanOrEqualTo(DateTime.Today.Year);
            RuleFor(x => x.ExpirationYear).LessThanOrEqualTo(DateTime.Today.Year + 15);
            RuleFor(x => x.CardHolderName).NotEmpty();
            RuleFor(x => x.CardHolderName).MaximumLength(100);
        }
    }
}
