using System;

namespace Domain
{
    public class Activity
    {
       public int Id { get; set; } 
       public string Title { get; set; }
       public string Description { get; set; }
       public string Category { get; set; }

       public DateTime  Date { get; set; }
       public string  City { get; set; }

       public string Value { get; set; }

    }
}