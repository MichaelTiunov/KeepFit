using System;
using System.Web.Mvc;
using KeepFit.Core.Dto;
using KeepFit.Core.Services;
using KeepFit.Web.Identity;
using KeepFit.Web.Models;
using KeepFit.Web.Models.Workout;

namespace KeepFit.Web.Controllers
{
    public class WorkoutController : BaseController
    {
        private readonly IWorkoutService workoutService;
        public WorkoutController(IAccountService accountService,
            IIdentityService identityService,
            IWorkoutService workoutService)
            : base(accountService, identityService)
        {
            this.workoutService = workoutService;
        }

        public ActionResult Index()
        {
            var model = new WorkoutModel
            {
                Workouts = workoutService.GetWorkouts(KeepFitIdentity.UserId),
                Workout = new WorkoutDto()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddWorkout(WorkoutDto workout)
        {
            workout.WorkoutDate = DateTime.Now;
            workout.UserId = KeepFitIdentity.UserId;
            workoutService.AddWorkout(workout);

            return RedirectToAction("Index");
        }
    }
}