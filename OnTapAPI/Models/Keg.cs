using System;
namespace OnTapAPI.Models
{
    public class Keg
    {
        public int kegId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float og { get; set; }
        public float fg { get; set; }
        public float kcal { get; set; }
        public float abv { get; set; }
        public float srm { get; set; }

        public Keg()
        {
        }
    }
}
