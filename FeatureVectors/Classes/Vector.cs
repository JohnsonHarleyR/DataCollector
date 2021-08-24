using System.Collections.Generic;

namespace FeatureVectors.Classes
{
    public class Vector
    {
        public int VectorId { get; set; }
        public string Name { get; set; }
        public int DatabaseId { get; set; }
        public List<Feature> Features { get; set; }

        public long Dimensionality { get => Features.Count; }


        public Vector()
        {
            Features = new List<Feature>();
        }

    }
}
