using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class TrainingController : ControllerBase
    {
        training_management_systemContext tms = new training_management_systemContext();
        [HttpPost]
        public int post(string Title, string CourseDescription)
        {
            Training training = new Training();
            training.Title = Title;
            training.CourseDescription = CourseDescription; 
            tms.Training.Add(training);
            int isTrainingAdded = tms.SaveChanges();
            return isTrainingAdded;
        }

    }
}