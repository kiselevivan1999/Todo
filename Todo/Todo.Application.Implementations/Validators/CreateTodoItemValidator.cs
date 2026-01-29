using FluentValidation;
using Todo.Application.Contracts.Dtos.TodoItem;

namespace Todo.Application.Implementations.Validators;

internal class CreateTodoItemValidator : AbstractValidator<CreateTodoItemDto>
{
    public CreateTodoItemValidator()
    {
        RuleFor(todo => todo.Title).NotNull().NotEmpty().Length(200);
        RuleFor(todo => todo.Title).Length(1000);
    }
}

