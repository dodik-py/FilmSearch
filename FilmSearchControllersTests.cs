using Microsoft.AspNetCore.Mvc;
using Filmpoisk;
using Xunit;
using Filmpoisk.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.HttpResults;



namespace FilmPoisk.Tests
{
    public class FilmSearchControllersTests
    {
        [Fact]
        public void FilmPooskcontext()
        {
            FilmpoiskController controller = new FilmpoiskController();

            ObjectResult resultgetfilm = controller.GetFilm() as ObjectResult;

            Assert.Equal(200,resultgetfilm.StatusCode);
            string gtfilm = resultgetfilm.GetType().ToString();


            ObjectResult resultgetactor = controller.GetActors() as ObjectResult;

            Assert.Equal(200, resultgetactor.StatusCode);
            string gtactor = resultgetactor.GetType().ToString();

            

            ObjectResult resultgetrole = controller.GetRoles() as ObjectResult;

            Assert.Equal(200, resultgetrole.StatusCode);
            string gtrole = resultgetrole.GetType().ToString();

            ObjectResult resultgetreview = controller.GetReviews() as ObjectResult;

            Assert.Equal(200, resultgetreview.StatusCode);
            string gtreview = resultgetreview.GetType().ToString();

            // IActionResult result=  ;
            // Console.ReadLine();
        }
    }
}
