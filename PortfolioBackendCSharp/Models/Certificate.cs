using System;

namespace PortfolioBackendCSharp.Models
{
    public class Certificate
    {
        public int ID { get; set; }

        public string Institution { get; set; }

        public string CourseName { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }
}
