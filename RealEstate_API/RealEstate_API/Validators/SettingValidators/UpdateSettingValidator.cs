using System;
using FluentValidation;
using RealEstate_API.Dtos.SettingDtos;

namespace RealEstate_API.Validators.SettingValidators
{
	public class UpdateSettingValidator:AbstractValidator<UpdateSettingDto>
	{
		public UpdateSettingValidator()
		{
            RuleFor(e => e.Key)
                .MinimumLength(3).WithMessage("key length must be greater than 3")
                .MaximumLength(100).WithMessage("key length must be smaller than 10");
            RuleFor(e => e.Value)
                .MinimumLength(3).WithMessage("value length must be greater than 3");
        }
	}
}

