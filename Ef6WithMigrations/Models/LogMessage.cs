using System;

namespace Ef6WithMigrations.Models
{
    public class LogMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
    }
}