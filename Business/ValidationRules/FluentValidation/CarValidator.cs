using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
	public class CarValidator : AbstractValidator<Car>
	{
		public CarValidator()
		{
			RuleFor(c => c.BrandId).NotNull();
			RuleFor(c => c.ColorId).NotNull();
			RuleFor(c => c.DailyPrice).NotEmpty();
			RuleFor(c => c.DailyPrice).GreaterThan(0); 
			RuleFor(c => c.ModelYear).GreaterThan(2010);
			RuleFor(c => c.Descripton).Length(2,300);
		}
	}
}