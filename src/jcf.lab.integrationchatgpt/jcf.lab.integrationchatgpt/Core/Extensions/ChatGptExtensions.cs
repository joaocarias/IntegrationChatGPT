using OpenAI_API;

namespace jcf.lab.integrationchatgpt.Core.Extensions
{
    public static class ChatGptExtensions
    {
        public static WebApplicationBuilder AddChatGpt(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddSingleton(new OpenAIAPI(configuration["ChatGpt:Key"]));
            return builder;
        }
    }
}
