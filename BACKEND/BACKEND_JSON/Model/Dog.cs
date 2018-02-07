using System.Collections.Generic;

namespace BACKEND_JSON.Model
{
    public class Dog
    {
        public Dog()
        {
            SubBreed = new List<string>();
        }
        public string  Breed { get; set; }
        public List<string>SubBreed { get; set; }
    }

    /*public class SubBreed
    {
        public string SubBredN { get; set; }
    }*/
}
