using System.Collections.Generic;

namespace FeatureVectors.Classes
{
    public class FeatureVector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<VectorPosition> Positions { get; set; }

        public FeatureVector()
        {
            Positions = new List<VectorPosition>();
        }

    }
}
