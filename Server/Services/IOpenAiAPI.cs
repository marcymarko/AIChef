using AIChef.Shared;

namespace AIChef.Server.Services
{
    public interface IOpenAiAPI
    {
        Task<List<Idea>> CreateRecipeIdeas(string mealtime, List<string> ingredients);
    }
}
