namespace Wear.OS.Sync.Server.Endpoints;

public static class FileEndpoints
{
    public static void Map(WebApplication app)
    {
        RouteGroupBuilder fileGroup = app.MapGroup("/files");
        fileGroup.MapGet("/all", ReturnAllFiles).Produces<IEnumerable<string>>();
    }

    public static IResult ReturnAllFiles()
    {
        return TypedResults.Ok(Directory.GetFiles(Environment.CurrentDirectory).Select(fn => Path.GetFileName(fn)));
    }
}