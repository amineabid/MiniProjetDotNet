﻿namespace Shared
{
    public class InterventionCreated
    {
        public string action { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public bool garnatie { get; set; }
        public int? ReclamationId { get; set; }
    }
}