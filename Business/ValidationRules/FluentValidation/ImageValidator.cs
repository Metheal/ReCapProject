using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ImageValidator : AbstractValidator<IFormFile>
    {
        public ImageValidator()
        {
            RuleFor(i => i.ContentType).NotNull();
            RuleFor(i => i.ContentType).Must(isImage);
        }

        private bool isImage(string arg)
        {
            return arg.StartsWith("image");
        }
    }
}
