using LuccaFaces;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

var handler = new SocketsHttpHandler
{
    MaxConnectionsPerServer = 10, // ou plus selon votre CPU
    PooledConnectionLifetime = TimeSpan.FromMinutes(5),
    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
};

var client = new HttpClient(handler)
{
    DefaultRequestVersion = new Version(1, 1),
    DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact
};

string authToken = "7edb8a0d-c95a-4002-b6e2-102221c8aa0f";

client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "fr-FR,fr;q=0.9,en-US;q=0.8,en;q=0.7");
client.DefaultRequestHeaders.TryAddWithoutValidation("Origin", "https://tdi-group.ilucca.net");
client.DefaultRequestHeaders.TryAddWithoutValidation("Referer", "https://tdi-group.ilucca.net/faces/game");
client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", $"authToken={authToken}; _dd_s=rum=0&expire=1753356759047");

var startGameContent = new StringContent("{}", Encoding.UTF8, "application/json");
var nextQuestionPayload = JsonSerializer.Serialize(new { establishments = Array.Empty<string>(), departments = Array.Empty<string>() });

int suggestId = 0;

while (true)
{
    int total = 0;

    // 1. Création de partie
    var startGameResponse = await client.PostAsync("https://tdi-group.ilucca.net/faces/api/games", startGameContent);
    var game = JsonSerializer.Deserialize<GameResponse>(await startGameResponse.Content.ReadAsStringAsync());

    Stopwatch sw1 = new Stopwatch();
    //Stopwatch sw2 = new Stopwatch();
    //Stopwatch sw3 = new Stopwatch();

    for (int i = 0; i < 10; i++)
    {
        //sw1.Start();

        // 2. Récupération question
        var nextResponse = await client.PostAsync(
            $"https://tdi-group.ilucca.net/faces/api/games/{game.id}/questions/next",
            new StringContent(nextQuestionPayload, Encoding.UTF8, "application/json"));

        var stream = await nextResponse.Content.ReadAsStreamAsync();
        var questionTask = JsonSerializer.DeserializeAsync<QuestionResponse>(stream);
        var question = await questionTask;

        //sw1.Stop();

        //sw2.Start();

        var suggested = question.suggestions.First();

        if (i > 0)
        {
            // 3. Téléchargement image + hash (optimisé en tâche parallèle)
            var hashTask = Service.GetImageHashAsync(client, question.imageUrl);

            string hash = await hashTask;

            if (Service.ImgHashToNames.TryGetValue(hash, out string guessedName) && !string.IsNullOrWhiteSpace(guessedName))
            {
                suggested = question.suggestions.FirstOrDefault(s =>
                    s.value.Equals(guessedName.Trim(), StringComparison.OrdinalIgnoreCase)) ?? suggested;
            }
        }

        //sw2.Stop();

        //sw3.Start();

        var guessPayload = new StringContent(
           JsonSerializer.Serialize(new GuessRequest
           {
               QuestionId = question.id,
               SuggestionId = suggested.id
           }),
           Encoding.UTF8, "application/json");

        var guessResponse = await client.PostAsync(
            $"https://tdi-group.ilucca.net/faces/api/games/{game.id}/questions/{question.id}/guess",
            guessPayload);

        var result = JsonSerializer.Deserialize<GuessResult>(
            await guessResponse.Content.ReadAsStringAsync());

        //await Task.Yield(); // ou implicitement via console log

        if (i < 1)
        {
            if (result.score < 145)
                break;
        }
        //sw1.Stop();

        total += result.score;
    }
    if (total > 0)
        Console.WriteLine(total);
}