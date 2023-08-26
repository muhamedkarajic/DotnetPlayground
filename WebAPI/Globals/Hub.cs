public static partial class Global
{
    public static WebApplication UseSignalRHub(this WebApplication self)
    {
        self.MapHub<MyHub>("/ws");
        return self;
    }
}
