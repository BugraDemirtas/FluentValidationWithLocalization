﻿using FluentValidation;
using FluentValidationWithLocalization.Languages;
using FluentValidationWithLocalization.Model;
using Microsoft.Extensions.Localization;

namespace FluentValidationWithLocalization.Validator
{
    public class UserValidator : AbstractValidator<User>
	{
		public UserValidator(IStringLocalizer<Lang> localize)
		{
			RuleFor(b => b.Name).NotNull().Length(5).WithMessage(x => localize[Messages.ValidationMessages.NameLength]);

			RuleFor(b => b.Age).NotNull().InclusiveBetween(5,60).WithMessage(x => localize[Messages.ValidationMessages.AgeRange]);
		}
	}
}
