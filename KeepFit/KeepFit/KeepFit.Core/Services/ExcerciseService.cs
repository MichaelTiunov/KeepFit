using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using KeepFit.Core.Dto;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public class ExcerciseService : IExcerciseService
    {
        private readonly IKeepFitContext keepFitContext;
        public ExcerciseService(IKeepFitContext keepFitContext)
        {
            this.keepFitContext = keepFitContext;
        }
        public IEnumerable<ExcerciseCategory> GetCategories()
        {
            return keepFitContext.ExcerciseCategories;
        }

        public void AddOrUpdateExcerciseCategory(ExcerciseCategoryDto categoryDto)
        {
            var excerciseCategory = new ExcerciseCategory
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            keepFitContext.ExcerciseCategories.AddOrUpdate(excerciseCategory);
            keepFitContext.SaveChanges();
        }

        public void AddOrUpdateExcercise(ExcerciseDto excerciseDto)
        {
            var excercise = new Excercise
            {
                ExcerciseId = excerciseDto.ExcerciseId,
                Name = excerciseDto.Name,
                Description = excerciseDto.Description,
                ExcerciseCategoryId = excerciseDto.ExcerciseCategoryId
            };
            if (excerciseDto.ExcercisePhoto != null && excerciseDto.ExcercisePhoto.ContentLength > 0)
            {
                using (var binaryReader = new BinaryReader(excerciseDto.ExcercisePhoto.InputStream))
                {
                    byte[] array = binaryReader.ReadBytes(excerciseDto.ExcercisePhoto.ContentLength);
                    var base64File = Convert.ToBase64String(array);
                    excercise.ExcercisePhoto = base64File;
                }
            }
            keepFitContext.Excercises.AddOrUpdate(excercise);
            keepFitContext.SaveChanges();
        }


        public IEnumerable<Excercise> GetExcercises(int categoryId)
        {
            return keepFitContext.Excercises.Where(x => x.ExcerciseCategoryId == categoryId);
        }

        public IEnumerable<Excercise> GetExcercises()
        {
            return keepFitContext.Excercises;
        }

        public ExcerciseDto GetExcercise(int excerciseId)
        {
            return keepFitContext.Excercises.Where(x => x.ExcerciseId == excerciseId).Select(x => new ExcerciseDto
            {
                ExcerciseId = x.ExcerciseId,
                ExcerciseCategoryId = x.ExcerciseCategoryId,
                Name = x.Name,
                Description = x.Description
            }).FirstOrDefault();
        }

        public void SaveExcercise(Excercise excercise)
        {
            keepFitContext.Excercises.Add(excercise);
            keepFitContext.SaveChanges();
        }
    }
}
