using Microsoft.AspNetCore.Authorization;
using System.Xml;

namespace TourOfHeroes1.Models
{
    public class Hero
    {

        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Message { get; set; }
    }
}
