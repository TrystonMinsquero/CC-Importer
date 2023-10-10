namespace API.Models
{
    public enum EntityType
    {
        Undefined = -1,
        Character = 0,
        Object = 1,
        Pack = 2,
    }

    public static class EntityTypeExtensions
    {
        public static string BucketName(this EntityType type) => type.ToString().ToLower();
    }

}