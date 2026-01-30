namespace Todo.Application.Contracts.Exceptions;

public class TodoItemNotFoundException : NotFoundException
{
    public TodoItemNotFoundException(int id) 
        : base("Задача не найдена", id.ToString())
    {}
}
