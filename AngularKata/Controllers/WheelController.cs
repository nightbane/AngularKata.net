using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AngularKata.Controllers
{
    public class WheelController : ApiController
    {
        public static List<PriorityModel> data = new List<PriorityModel>
            {
                    new PriorityModel {PriorityId = 1, Name = "Short Term Security", Category = Segment.Financial, Objective = "Have a account with six month income, a rainy day account."},
                    new PriorityModel {PriorityId = 2, Name = "Get a Raise",Category = Segment.Career, Objective = "Get a raise of 5k either at my current employer or get a new job."},
            };

        // GET api/front
        public IEnumerable<PriorityModel> Get()
        {
            return data;
        }

        // GET api/front/5
        public PriorityModel Get(int id)
        {
            return data.FirstOrDefault(g => g.PriorityId == id) ?? new PriorityModel();
        }

        // POST api/front
        public void Post([FromBody]PriorityModel value)
        {
            value.PriorityId = data.Max(g => g.PriorityId) + 1;
            data.Add(value);
        }

        // PUT api/front/5
        public void Put(int id, [FromBody]PriorityModel value)
        {
            data = data.Where(g => g.PriorityId != id).ToList();
            value.PriorityId = id;
            data.Add(value);
        }

        // DELETE api/front/5
        public void Delete(int id)
        {
            data = data.Where(g => g.PriorityId != id).ToList();
        }
    }

    public class PriorityModel
    {
        public int PriorityId { get; set; }
        public string Name { get; set; }
        public Segment Category { get; set; }
        public string Objective { get; set; }
    }

    public enum Segment
    {
        Financial,
        Spiritual,
        Physical,
        Intellectual,
        Family,
        Social,
        Career,
    }
}
