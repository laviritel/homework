using BACKEND_JSON.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace BACKEND_JSON.Controllers
{
    public class ValueController: ApiController
    {
        private List<Dog> Dogs=new List<Dog>();

        public ValueController()
        {
            Dogs.Add(new Dog { Breed = "affenpinscher" });
            Dogs.Add(new Dog { Breed = "african" });
            Dogs.Add(new Dog { Breed = "bulldog",SubBreed=new List<string> { "boston","french" } });
            Dogs.Add(new Dog { Breed = "bullterrier", SubBreed = new List<string> { "staffordshire"} });
            Dogs.Add(new Dog { Breed = "poodle", SubBreed = new List<string> { "miniature", "standard", "toy" } });
            Dogs.Add(new Dog { Breed = "retriever", SubBreed = new List<string> { "chesapeake", "curly", "flatcoated", "golden" } });
        }
        public JsonResult<List<Dog>>Get()
        {
            return Json(Dogs);
        }
    }
}
