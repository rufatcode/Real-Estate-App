using System;
using FluentValidation;
using RealEstate_API.Dtos.ContactDtos;

namespace RealEstate_API.Validators.ContactValidators
{
	public class UpdateContactValidator:AbstractValidator<UpdateContactDto>
	{
		public UpdateContactValidator()
		{
			RuleFor(e => e.Name)
				.MinimumLength(3).WithMessage("Name length must be greater than 3")
				.MaximumLength(300).WithMessage("Name length must be smaller than 300");
            RuleFor(e => e.Message)
                .MinimumLength(3).WithMessage("Message length must be greater than 3");
			RuleFor(e => e.Email)
				.EmailAddress().WithMessage("invalid email")
				.MinimumLength(3).WithMessage("email length must be greater than 3")
				.MaximumLength(300).WithMessage("email length must be smaller than 300")
                 .Matches(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$").WithMessage("email address is not valid");
		}
	}
}

