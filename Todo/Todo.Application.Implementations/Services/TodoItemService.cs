using Mapster;
using Todo.Application.Abstractions.Services;
using Todo.Application.Contracts.Dtos.TodoItem;
using Todo.Application.Contracts.Exceptions;
using Todo.Application.Implementations.Specifications;
using Todo.Application.Repositories.Abstractions;
using Todo.Domain.Entities;
using Todo.Domain.Enums;

namespace Todo.Application.Implementations.Services;

internal class TodoItemService : ITodoItemService
{
    private readonly IUnitOfWork _unitOfWork;

    public TodoItemService(IUnitOfWork unitOfWork) 
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TodoItemDto> CreateAsync(CreateTodoItemDto createDto, 
        CancellationToken cancellationToken)
    {
        var todoItem = createDto.Adapt<TodoItem>();
        var result = await _unitOfWork.TodoItemRepository.AddAsync(todoItem, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result.Adapt<TodoItemDto>();
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var todoItem = await GetTodoItemAsync(id, cancellationToken);
        _unitOfWork.TodoItemRepository.Delete(todoItem);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<TodoItemDto[]> GetByFilterAsync(TodoItemFilterDto filter, 
        CancellationToken cancellationToken)
    {
        var specification = new TodoItemByFilterSpecification(filter.IsCompleted, filter.Priority);

        var todoItems = await _unitOfWork.TodoItemRepository
            .FindAsync(specification, cancellationToken);
        return todoItems.Adapt<TodoItemDto[]>();
    }

    public async Task<TodoItemDto> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var todoItem = await GetTodoItemAsync(id, cancellationToken);
        return todoItem.Adapt<TodoItemDto>();
    }

    public async Task<TodoItemDto> CompleteAsync(int id, CancellationToken cancellationToken)
    {
        var todoItem = await GetTodoItemAsync(id, cancellationToken);

        todoItem.Complete();
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return todoItem.Adapt<TodoItemDto>();
    }

    public async Task<TodoItemDto> UpdateAsync(int id, UpdateTodoItemDto updateDto, 
        CancellationToken cancellationToken)
    {
        var todoItem = await GetTodoItemAsync(id, cancellationToken);

        //TODO: настроить в маппинге
        todoItem.Title = updateDto.Title;
        todoItem.Description = updateDto.Description;
        todoItem.Priority = (PriorityEnum)updateDto.Priority;

        _unitOfWork.TodoItemRepository.Update(todoItem);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return todoItem.Adapt<TodoItemDto>();
    }

    /// <summary>
    /// Вытаскиваем запись по id с проверкой на её наличие
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="TodoItemNotFoundException"></exception>
    private async Task<TodoItem> GetTodoItemAsync(int id, CancellationToken cancellationToken) 
    {
        var todoItem = await _unitOfWork.TodoItemRepository.GetAsync(id, cancellationToken);
        if (todoItem is null)
            throw new TodoItemNotFoundException(id);

        return todoItem;
    }
}
