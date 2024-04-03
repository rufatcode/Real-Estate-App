using System;
using FluentValidation;
using RealEstate_API.Dtos.CategoryDtos;

namespace RealEstate_API.Validators.CategoryValidators
{
	public class CreateCategoryValidator:AbstractValidator<CreateCategoryDto>
	{
		public CreateCategoryValidator()
		{
			RuleFor(e => e.Name)
				.MinimumLength(5).WithMessage("Name length must be greated than 5")
				.MaximumLength(300).WithMessage("Name length must be smaller than 300");
		}
	}
}

