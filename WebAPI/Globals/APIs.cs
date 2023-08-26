public static partial class Global
{
    public static WebApplication UseMinimalAPIs(this WebApplication self)
    {
        self.MapGet("/ping", () => "pong");

        self.MapGet("/request-context", (IDiagnosticContext diagnosticContext) =>
        {
            diagnosticContext.Set("UserId", "someone");
        });

        self.MapGet("/create-customer/{id}", (int id, Serilog.ILogger logger) =>
        {
            logger.Information("Creating customer id: {id}", id);

            using (Operation.Time("Do some Data Base Query..."))
            {
                Thread.Sleep(500);
            }

            return "Something.";
        });

        return self;
    }
}
