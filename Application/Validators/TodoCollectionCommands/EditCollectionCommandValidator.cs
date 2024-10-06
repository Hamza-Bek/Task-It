using Application.Features.TodoCollections.Commands;
using Application.Validators.Dtos;
using FluentValidation;

namespace Application.Validators.TodoCollectionCommands;

public class EditCollectionCommandValidator : AbstractValidator<EditCollectionCommand>
{
    public EditCollectionCommandValidator()
    {
        RuleFor(x => x.CollectionId)
            .NotEmpty().WithMessage("Todo collection id cannot be empty.")
            .NotNull().WithMessage("Todo collection id cannot be null.");
        
        RuleFor(x => x.Model)
            .SetValidator(new SubmitCollectionRequestValidator());
    }
}