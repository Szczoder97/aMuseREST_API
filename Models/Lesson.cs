using System.Collections.Generic;

namespace Models
{
    public class Lesson
    {
        public int id {get; set;}
        public string title {get; set;}
        public string text {get; set;}
        public string ytLink {get; set;}
        public User author {get; set;}
    }
}