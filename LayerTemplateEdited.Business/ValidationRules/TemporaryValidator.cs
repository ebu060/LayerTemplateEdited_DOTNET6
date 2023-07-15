using FluentValidation;
using LayerTemplateEdited.Entities.Concrete;

namespace LayerTemplateEdited.Business.ValidationRules
{
	public class TemporaryValidator:AbstractValidator<Temporary>
	{
		public TemporaryValidator()
		{
			RuleFor(p => p.TemporaryName).NotEmpty();
			RuleFor(p => p.TemporaryName).MinimumLength(2);
			RuleFor(p => p.TemporaryCategoryId).NotEmpty();

		}
	}
}
