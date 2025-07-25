using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuccaFaces
{
    public class GameResponse
    {
        public string id { get; set; }
        public int ownerId { get; set; }
        public int nbQuestions { get; set; }
        public bool isTraining { get; set; }
    }

    public class Suggestion
    {
        public int id { get; set; }
        public string value { get; set; }
    }

    public class QuestionResponse
    {
        public int id { get; set; }
        public string gameId { get; set; }
        public string imageUrl { get; set; }
        public List<Suggestion> suggestions { get; set; }
    }

    public class GuessResult
    {
        public int QuestionId { get; set; }
        public int? SuggestionId { get; set; }
        public int TimeTaken { get; set; }
        public int score { get; set; }
        public bool IsCorrect { get; set; }
        public int CorrectSuggestionId { get; set; }
        public int CorrectUserId { get; set; }
    }

    public class GuessRequest
    {
        public int QuestionId { get; set; }

        public int SuggestionId { get; set; }
    }
}
