using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Abstractions.Services;
using Todo.Application.Contracts.Dtos.TodoItem;
using Todo.Application.Implementations.Decoraters;
using Todo.Application.Implementations.Services;
using Todo.Application.Implementations.Validators;

namespace Todo.Application.Implementations;

public static class ApplicationRegistrar
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
    {
        services.AddValidators();

        services.AddScoped<ITodoItemService, TodoItemService>();
        services.Decorate<ITodoItemService, TodoItemServiceValidationDecorator>();
        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services) 
    {
        services.AddScoped<IValidator<CreateTodoItemDto>, CreateTodoItemValidator>();
        services.AddScoped<IValidator<UpdateTodoItemDto>, UpdateTodoItemValidator>();
        return services;
    }
}
