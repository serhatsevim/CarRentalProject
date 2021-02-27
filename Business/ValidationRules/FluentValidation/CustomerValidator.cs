using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
	public class CustomerValidator : AbstractValidator<Customer>
	{
		RuleFor(c => c.UserId).NotNull();
		RuleFor(c => c.CompanyName).NotEmpty();
		RuleFor(c => c.CompanyName).MaximumLength(100);
	}
}