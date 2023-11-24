using AIChef.Server.Data;
using AIChef.Server.Services;
using AIChef.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIChef.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IOpenAiAPI _openAiservice;

        public RecipeController(IOpenAiAPI openAiservice)
        {
            _openAiservice = openAiservice;
        }

        [HttpPost, Route("GetRecipeIdeas")]
        public async Task<ActionResult<List<Idea>>> GetRecipeIdeas(RecipeParms recipeForms)
        {
            string mealtime = recipeForms.Mealtime;
            List<string> ingredients = recipeForms.Ingredients
                                        .Where(x => !string.IsNullOrEmpty(x.Description))
                                        .Select(x => x.Description)
                                        .ToList();
            if (string.IsNullOrEmpty(mealtime))
            {
                mealtime = "Breakfast";
            }

            var ideas = await _openAiservice.CreateRecipeIdeas(mealtime, ingredients);

            return ideas;
            //return SampleData.RecipeIdeas;
        }

        [HttpPost, Route("GetRecipe")]
        public async Task<ActionResult<Recipe?>> GetRecipe(RecipeParms recipeParms)
        {
            List<string> ingredients = recipeParms.Ingredients
                                                  .Where(x => !string.IsNullOrEmpty(x.Description))
                                                  .Select(x => x.Description)
                                                  .ToList();

            string title = recipeParms.SelectedIdea;

            if (string.IsNullOrEmpty(title))
            {
                return BadRequest();
            }

            var recipe = await _openAiservice.CreateRecipe(title, ingredients);
            return recipe;

            //return SampleData.Recipe;
        }

        [HttpGet, Route("GetRecipeImage")]
        public async Task<RecipeImage> GetRecipeImage(string title)
        {
            var recipeImage = await _openAiservice.CreateRecipeImage(title);

            return recipeImage ?? SampleData.RecipeImage;

            // return SampleData.RecipeImage;
        }

    }
}
