using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator:AbstractValidator<CarImages>
    {
        public CarImageValidator()
        {
            //RuleFor(r => r.CarId).NotEmpty();
            //RuleFor(r => r.ImagePath).NotEmpty();
            //RuleFor(r => r.Date).NotEmpty();

            RuleFor(c => c.CarId).NotNull();
            RuleFor(c => c.Id).NotNull();
        }
    }
}
