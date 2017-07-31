﻿using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Models.Entities;

namespace BookLibraryApi.Repositories.EntityRepositories
{
    public sealed class VolumeExemplarsRepository : RepositoryBase<VolumeExemplar>
    {
        public VolumeExemplarsRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
