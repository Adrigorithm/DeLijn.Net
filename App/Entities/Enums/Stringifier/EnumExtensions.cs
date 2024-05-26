namespace DeLijn.Net.App.Entities.Enums.Strinfigier;

public static class EnumExtensions
{
    public static string ToTranslatedString(this Direction direction) =>
        direction switch
        {
            Direction.To => "TERUG",
            Direction.Back => "HEEN",
            _ => throw new NotImplementedException()
        };
}