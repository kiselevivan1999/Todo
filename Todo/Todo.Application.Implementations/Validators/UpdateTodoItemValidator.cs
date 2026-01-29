using FluentValidation;
using Todo.Application.Contracts.Dtos.TodoItem;

namespace Todo.Application.Implementations.Validators;

internal class UpdateTodoItemValidator : AbstractValidator<UpdateTodoItemDto>
{
    public UpdateTodoItemValidator() 
    {
        RuleFor(todo => todo.Title).NotNull().NotEmpty().Length(1, 200);
        RuleFor(todo => todo.Title).Length(1, 1000);
    }
}
