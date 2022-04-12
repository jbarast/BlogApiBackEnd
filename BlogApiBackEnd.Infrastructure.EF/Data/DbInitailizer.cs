namespace BlogApiBackEnd.Infrastructure.EF.Data
{
    public class DbInitailizer
    {
        public static void Initialize(BlogContext context)
        {
            context.Database.EnsureCreated();
            {
                
            }
        }
    }
}