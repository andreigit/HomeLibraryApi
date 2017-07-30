﻿namespace BookLibraryApi.Models
{
    public sealed class WorkKind : IEntityWithNameAndDescription
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
