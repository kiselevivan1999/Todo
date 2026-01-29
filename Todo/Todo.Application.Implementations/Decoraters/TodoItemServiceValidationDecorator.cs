using FluentValidation;
using Todo.Application.Abstractions.Services;
using Todo.Application.Contracts.Dtos.TodoItem;

namespace Todo.Application.Implementations.Decoraters;

internal class TodoItemServiceValidationDecorator : ITodoItemService
{
    private readonly ITodoItemService _todoService;
    private readonly IValidator<CreateTodoItemDto> _createValidator;
    private readonly IValidator<UpdateTodoItemDto> _updateValidator;

    public TodoItemServiceValidationDecorator(
        ITodoItemService todoService,
        IValidator<CreateTodoItemDto> createValidator,
        IValidator<UpdateTodoItemDto> updateValidator) 
    {
        _todoService = todoService;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task<TodoItemDto> CompleteAsync(int id, CancellationToken cancellationToken)
    {
        return await _todoService.CompleteAsync(id, cancellationToken);
    }

    public async Task<TodoItemDto> CreateAsync(CreateTodoItemDto createDto, CancellationToken cancellationToken)
    {
        await _createValidator.ValidateAndThrowAsync(createDto);
        return await _todoService.CreateAsync(createDto, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        await _todoService.DeleteAsync(id, cancellationToken);
    }

    public TodoItemDto[] GetByFilter(TodoItemFilterDto filter)
    {
        throw new NotImplementedException();
    }

    public async Task<TodoItemDto> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _todoService.GetByIdAsync(id, cancellationToken);
    }

    public async Task<TodoItemDto> UpdateAsync(int id, UpdateTodoItemDto updateDto, CancellationToken cancellationToken)
    {
        await _updateValidator.ValidateAndThrowAsync(updateDto);
        return await _todoService.UpdateAsync(id, updateDto, cancellationToken);
    }
}
