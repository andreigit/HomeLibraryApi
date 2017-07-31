﻿using BookLibraryApi.Models.EntityLinks;
using BookLibraryApi.Repositories.EntityLinkRepositories;

namespace BookLibraryApi.Controllers.EntityLinkControllers
{
    public sealed class WorkAuthorLinksController : EntityControllerBase<WorkAuthorLinksRepository, WorkAuthorLink>
    {
        public WorkAuthorLinksController(WorkAuthorLinksRepository repository) : base(repository)
        {
        }
    }
}
