using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using OpenAI_API;

namespace jcf.lab.integrationchatgpt.Controllers
{
    [Route("api/[controller]")]
    public class SampleController : Controller
    {
        private readonly OpenAIAPI _chatGpt;

        public SampleController(OpenAIAPI chatGpt)
        {
            _chatGpt = chatGpt;
        }

        [HttpGet]
        public async Task<IActionResult> GetSampleChatpGpt(string text)
        {
            var myResponse = string.Empty;
            var completion = new CompletionRequest
            {
                Prompt = text,
                Model = Model.DavinciText,
                MaxTokens = 200
            };

            var result = await _chatGpt.Completions.CreateCompletionAsync(completion);

            result.Completions.ForEach(resultText => myResponse = resultText.Text);

            return Ok(myResponse);
        }
    }
}
