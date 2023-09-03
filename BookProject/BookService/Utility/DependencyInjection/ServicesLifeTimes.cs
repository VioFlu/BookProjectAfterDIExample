namespace BookService.Utility.DependencyInjection
{
    public class ServicesLifeTimes: ILifeScoped, ILifeTransient, ILifeSingleton
    {
        public Guid ID { get; set; } = Guid.NewGuid();
    }
}
