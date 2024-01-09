using Ardalis.Result;
using ApiTemplate.Core.ProjectAggregate;

namespace ApiTemplate.Core.Interfaces;

  public interface IToDoItemSearchService
  {
      Task<Result<ToDoItem>> GetNextIncompleteItemAsync(Guid projectId);
      Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(Guid projectId, string searchString);
  }
