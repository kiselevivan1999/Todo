using Mapster;
using Todo.Application.Abstractions.Services;
using Todo.Application.Contracts.Dtos.TodoItem;
using Todo.Application.Repositories.Abstractions;
using Todo.Domain.Entities;
using Todo.Domain.Enums;

namespace Todo.Application.Implementations.Services;

//TODO: Кастомные исключения + Middleware
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
        var todoItem = await _unitOfWork.TodoItemRepository.GetAsync(id, cancellationToken);
        if (todoItem is null)
            throw new ArgumentNullException("Задача не найдена.");
        
        _unitOfWork.TodoItemRepository.Delete(todoItem);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    //TODO: Реализовать
    public TodoItemDto[] GetByFilter(TodoItemFilterDto filter)
    {
        throw new NotImplementedException();
    }

    public async Task<TodoItemDto> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var todoItem = await _unitOfWork.TodoItemRepository.GetAsync(id, cancellationToken);
        if (todoItem is null)
            throw new ArgumentNullException("Задача не найдена.");

        return todoItem.Adapt<TodoItemDto>();
    }

    public async Task<TodoItemDto> CompleteAsync(int id, CancellationToken cancellationToken)
    {
        var todoItem = await _unitOfWork.TodoItemRepository.GetAsync(id, cancellationToken);

        if (todoItem is null)
            throw new ArgumentNullException("Задача не найдена.");

        todoItem.Complete();
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return todoItem.Adapt<TodoItemDto>();
    }

    public async Task<TodoItemDto> UpdateAsync(int id, UpdateTodoItemDto updateDto, 
        CancellationToken cancellationToken)
    {
        var todoItem = await _unitOfWork.TodoItemRepository.GetAsync(id, cancellationToken);
        if (todoItem is null)
            throw new ArgumentNullException("Задача не найдена.");

        //TODO: настроить в маппинге
        todoItem.Title = updateDto.Title;
        todoItem.Description = updateDto.Description;
        todoItem.Priority = (PriorityEnum)updateDto.Priority;

        _unitOfWork.TodoItemRepository.Update(todoItem);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return todoItem.Adapt<TodoItemDto>();
    }
}
