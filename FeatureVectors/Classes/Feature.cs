namespace FeatureVectors.Classes
{
    public class Feature
    {
        public int PositionId { get; set; }
        public string Name { get; set; }
        public int DatabaseId { get; set; }
        public bool Value { get; set; }

        public int GetIntValue()
        {
            if (Value == true)
            {
                return 1;
            }
            return -1;
        }
    }
}
