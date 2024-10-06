using Application.Dtos.TodoCollections;
using FluentValidation;

namespace Application.Validators.Dtos;

public class SubmitCollectionRequestValidator : AbstractValidator<Application.Dtos.TodoCollections.SubmitCollectionRequest>
{
    public SubmitCollectionRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Collection name cannot be empty.")
            .NotNull().WithMessage("Collection name cannot be null.")
            .Length(3, 50).WithMessage("Collection name must be between 3 and 50 characters.");
        
        RuleFor(x => x.Description)
            .Length(5, 200).WithMessage("Collection description must be between 5 and 200 characters.");
    }
}