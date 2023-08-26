public static partial class Global
{
    public static WebApplication UseSwaggerIfDevelopment(this WebApplication self)
    {
        if (self.Environment.IsDevelopment())
        {
            self.UseSwagger();
            self.UseSwaggerUI();
        }

        return self;
    }
}
