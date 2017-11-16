﻿using BluTimesheet.Repositories;
using BluTimesheet.Services.interfaces;
using System.Collections.Generic;
using BluTimesheet.Models.DbModels;

namespace BluTimesheet.Services.implementations
{
    public class ProjectTypeService : IProjectTypeService
    {
        private readonly ProjectTypeRepository projectTypeRepository;

        public ProjectTypeService(ProjectTypeRepository projectTypeRepository)
        {
            this.projectTypeRepository = projectTypeRepository;
        }

        public void Add(ProjectType projectType)
        {
            projectTypeRepository.Add(projectType);
        }

        public ProjectType Get(int id)
        {
            return projectTypeRepository.Get(id);
        }

        public IEnumerable<ProjectType> GetAll()
        {
            return projectTypeRepository.GetAll();
        }

        public void Remove(int id)
        {
            projectTypeRepository.Remove(id);
        }

        public void Update(ProjectType projectType)
        {
            projectTypeRepository.Update(projectType);
        }
    }
}