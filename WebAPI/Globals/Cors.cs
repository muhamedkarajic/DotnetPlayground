public static partial class Global
{
    public const string Angular = "Angular";

    public static IServiceCollection AddCorsAngular(this IServiceCollection self)
    {
        self.AddCors(options =>
        {
            options.AddPolicy(name: Angular,
                builder =>
                {
                    builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
        });

        return self;
    }

    public static WebApplication UseCorsAngular(this WebApplication self)
    {
        self.UseCors(Angular);
        return self;
    }
}
