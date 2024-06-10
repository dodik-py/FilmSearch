using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Filmpoisk.Controllers
{
    [ApiController]
    [Route("/test/")]
    [Serializable]
    public class FilmpoiskController : ControllerBase
    {
        private FilmsContext filmsContext;

       

       

        
        public FilmpoiskController()
        {
            filmsContext = new FilmsContext();
           
        }

        [HttpGet("getfilms")]
        public IActionResult GetFilm()
        {
            try
            {
                var films = (from film in filmsContext.Films select film).ToList();

                return Ok(films);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
           /* return enumerable.range(1, 5).select(index => new[]
             {
                idfilms = int128.(index),
                temperaturec = random.shared.next(-20, 55),
            summary = summaries[random.shared.next(summaries.length)]
              })
             .toarray();*/
        
        [HttpGet("getactors")]
        public IActionResult GetActors()
        {
            try
            {


                var actors = (from actor in filmsContext.Actors select actor).ToList();

                return Ok(actors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        
        [HttpGet("getreviews")]
        public IActionResult GetReviews()
        {
            try
            {
                var reviews = (from review in filmsContext.Reviews select review).ToList();

                return Ok(reviews);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getroles")]
        public IActionResult GetRoles()
        {
            try
            {
                var roles = (from role in filmsContext.Roles select role).ToList();

                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("addfilms")]

        public IActionResult AddFilm([FromBody] Film film)
        {
            try
            {
                filmsContext.Films.Add(film);
                filmsContext.SaveChanges();

                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("addactors")]

        public IActionResult AddActor([FromBody] Actor actor)
        {
            try
            {

                filmsContext.Actors.Add(actor);
                filmsContext.SaveChanges();

                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("addroles")]

        public IActionResult AddRole([FromBody] Role role)
        {
            try
            {

                filmsContext.Roles.Add(role);
                filmsContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("addreviews")]

        public IActionResult AddReview([FromBody] Review review)
        {
            try
            {


                filmsContext.Reviews.Add(review);
                filmsContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletefilms")]

        public IActionResult DeleteFilm([FromBody] Film film)
        {
            try
            {
                Film filmdel = filmsContext.Films.FirstOrDefault(p => p.Id == film.Id);
                filmsContext.Films.Remove(filmdel);
                filmsContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteactors")]

        public IActionResult DeleteActor([FromBody] Actor actor)
        {
            try
            {
                Actor actordel = filmsContext.Actors.FirstOrDefault(p => p.Id == actor.Id);

                filmsContext.Actors.Remove(actordel);
                filmsContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletereviews")]

        public IActionResult DeleteReview([FromBody] Review review)
        {
            try
            {


                Review reviewdel = filmsContext.Reviews.FirstOrDefault(p => p.Id == review.Id);

                filmsContext.Reviews.Remove(reviewdel);
                filmsContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteroles")]

        public IActionResult DeleteRole([FromBody] Role role)
        {
            try
            {
                Role roledel = filmsContext.Roles.FirstOrDefault(p => p.Id == role.Id);

                filmsContext.Roles.Remove(roledel);
                filmsContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("changeroles")]

        public IActionResult ChangeRole([FromBody] Role role)
        {
            try
            {
                Role rolecng = filmsContext.Roles.FirstOrDefault(p => p.Id == role.Id);
                if (rolecng != null)
                {
                    rolecng.ActorsId = role.ActorsId;

                    rolecng.FilmsId = role.FilmsId;




                    filmsContext.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost("changefilm")]

        public IActionResult ChangeFilm([FromBody] Film film)
        {
            try
            {
                Film rolecng = filmsContext.Films.FirstOrDefault(p => p.Id == film.Id);
                if (rolecng != null)
                {
                    rolecng.Title = film.Title;






                    filmsContext.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost("changereviews")]

        public IActionResult ChangeReview([FromBody] Review review)
        {
            try
            {
                Review rolecng = filmsContext.Reviews.FirstOrDefault(p => p.Id == review.Id);
                if (rolecng != null)
                {
                    rolecng.Stars = review.Stars;
                    rolecng.Description = review.Description;
                    rolecng.Review1 = review.Review1;






                    filmsContext.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost("changeactors")]

        public IActionResult ChangeActor([FromBody] Actor actor)
        {
            try
            {
                Actor rolecng = filmsContext.Actors.FirstOrDefault(p => p.Id == actor.Id);
                if (rolecng != null)
                {
                    rolecng.Name = actor.Name;
                    rolecng.Surname = actor.Surname;







                    filmsContext.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }















    }

}
