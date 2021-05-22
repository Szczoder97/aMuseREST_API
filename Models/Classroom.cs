using System.Collections.Generic;

namespace Models
{
    public class Classroom
    {
        public int id {get; set;}
        public string title {get; set;}
        public string description {get; set;}
        public User user {get; set;}
        public List<Lesson> lessons {get; set;}

    }
}