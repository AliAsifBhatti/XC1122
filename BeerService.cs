using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BeerService.Controllers
{
    public class BeerController : ApiController
    {

        List<Beer> _beerList = new List<Beer>
        {
            new Beer {  Name = "Guinness", Type = "Stout", Rating = 1 },
            new Beer {  Name = "Blue Moon", Type = "Pale ale", Rating = 5 },
            new Beer {  Name = "Corona", Type = "Stout", Rating = 3 }
        };

        /// <summary>
        /// This method is used to get the list of beer
        /// </summary>
        /// <returns>list of Beer</returns>
        public IEnumerable<Beer> GetAllBeers()
        {
            return _beerList;
        }

        /// <summary>
        /// This method is used at a Beer in the stock
        /// </summary>
        /// <param name="beer"></param>
        public void Post(Beer beer)
        {
            _beerList.Add(beer); 
        }

        /// <summary>
        /// This method will return the list of Beer whose name is totaly or partialy matched against the input
        /// </summary>
        /// <param name="name">Name of the Beer</param>
        /// <returns>List oof Beer</returns>
        public IHttpActionResult GetBeer(string name)
        {
            var beerList = _beerList.Where(x => x.Name.Contains(name));
            if (beerList == null)
            {
                return NotFound();
            }
            return Ok(beerList);
        }

        /// <summary>
        /// This method is used to update the rating of a specific beer
        /// </summary>
        /// <param name="beer"></param>
        public void UpdateRating(Beer beer)
        {
            var obj = _beerList.FirstOrDefault(x => x.Name == beer.Name && x.Type == beer.Type);
            if (obj != null)
            {
                obj.Rating = (int)_beerList.Average(x => x.Rating);
            }
        }
    }


    /// <summary>
    /// Class of Beer
    /// </summary>
    public class Beer
    {
        /// <summary>
        /// Name of a Beer
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Type of Beer
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Rating of a Beer
        /// </summary>
        public int? Rating { get; set; }
    }
}
