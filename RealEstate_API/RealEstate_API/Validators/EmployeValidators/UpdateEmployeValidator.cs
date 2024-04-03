using System;
using FluentValidation;
using RealEstate_API.Dtos.EmployeDtos;

namespace RealEstate_API.Validators.EmployeValidators
{
	public class UpdateEmployeValidator:AbstractValidator<UpdateEmployeDto>
	{
		public UpdateEmployeValidator()
		{
            RuleFor(e => e.Name)
                .MinimumLength(3).WithMessage("Name length must be greater than 3")
                .MaximumLength(300).WithMessage("Name length must be smaller than 300");
            RuleFor(e => e.Position)
                .MinimumLength(3).WithMessage("Position length must be greater than 3")
                .MaximumLength(300).WithMessage("Position length must be smaller than 300");
            RuleFor(e => e.PhoneNumber)
                .MinimumLength(3).WithMessage("PhoneNumber length must be greater than 3")
                .MaximumLength(300).WithMessage("PhoneNumber length must be smaller than 300");
        }
	}
}

