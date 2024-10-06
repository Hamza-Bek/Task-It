using Application.Features.TodoCollections.Commands;
using Application.Validators.Dtos;
using FluentValidation;

namespace Application.Validators.TodoCollectionCommands;

public class CreateCollectionCommandValidator : AbstractValidator<CreateCollectionCommand>
{
    public CreateCollectionCommandValidator()
    {
        RuleFor(x => x.Model)
            .SetValidator(new SubmitCollectionRequestValidator());
    }
}