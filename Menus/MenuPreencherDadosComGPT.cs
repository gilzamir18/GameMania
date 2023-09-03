namespace GameMania.Menus;
using GameMania.Modelos;
using Newtonsoft.Json;

internal class MenuPreencherDadosComGPT: Menu{
    public MenuPreencherDadosComGPT():base(titulo:"Preenchendo Dados Com GPT"){

    }    
    public override async Task ExecutarOpcao(Dictionary<string, Jogo> jogosRegistrados){
            //await RequisitarAPI();
            string jsonString = "";
            // string jsonString = @"{
            //     ""Genero"": ""Ação/Aventura"",
            //     ""Studio"": ""Ubisoft"",
            //     ""Edicao"": ""3"",
            //     ""Descricao"": ""Bem-vindo à loucura tropical de Far Cry 3! Jogue como Jason Brody, um turista em uma ilha paradisíaca que se transforma em um pesadelo mortal. Lute contra piratas, explore selvas exuberantes e mergulhe em uma história cheia de reviravoltas e personagens inesquecíveis. Prepare-se para caos, explosões e muita diversão!"",
            //     ""Disponibilidade"": true,
            //     ""Plataformas"": ""PlayStation, Xbox, PC""
            // }";
            jsonString = await RequisitarAPI(titulo:"FarCry3");
            Jogo? jogo = JsonConvert.DeserializeObject<Jogo>(jsonString);
            jogo = jogo==null?new Jogo():jogo;
            jogo.Titulo = "FarCry3";
            jogo.ExibirFichaTecnica();
            jogosRegistrados.Add(jogo.Titulo,jogo);

            await Task.Delay(0);
    }
    public virtual async Task<string> RequisitarAPI(string titulo){
        var client = new OpenAI_API.OpenAIAPI(Environment.GetEnvironmentVariable("OPENAI_KEY"));
        var chat = client.Chat.CreateConversation();
        string prompt = $@"Para o jogo ""{titulo}"", preencha os campos adequadamente e retorne apenas o arquivo JSON preenchido. Descricao: Resuma o jogo de forma divertida e breve. Não repita informações de outros campos:
        {{
        ""Genero"": """",
        ""Studio"": """",
        ""Edicao"": """",
        ""Descricao"": """",
        ""Disponibilidade"": true || false,
        ""Plataformas"": """"
        }}";

        chat.AppendSystemMessage(prompt);
        string resposta = await chat.GetResponseFromChatbotAsync();
        Console.WriteLine("Resposta do ChatGPT: " + resposta);
        return resposta;    
        }

}