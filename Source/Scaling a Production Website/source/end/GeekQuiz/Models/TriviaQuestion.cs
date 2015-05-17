using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeekQuiz.Models
{
    public class TriviaQuestion
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual List<TriviaOption> Options { get; set; }
    }
}