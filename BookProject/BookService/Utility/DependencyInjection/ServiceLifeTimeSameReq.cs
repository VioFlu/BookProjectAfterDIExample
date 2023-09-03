using BookService.Controllers;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookService.Utility.DependencyInjection
{
    public class ServiceLifeTimeSameReq : IServicesLifeTimesReq
    {
        ILogger<ServiceLifeTimeSameReq> _logger;
        ILifeTransient _lifeTransient;
        ILifeScoped _lifeScoped;
        ILifeSingleton _lifeSingleton;
        public ServiceLifeTimeSameReq(ILogger<ServiceLifeTimeSameReq> logger, 
            ILifeScoped lifeScoped, 
            ILifeTransient lifeTransient,
            ILifeSingleton lifeSingleton)
        {
            _lifeScoped = lifeScoped;
            _lifeTransient = lifeTransient;
            _logger = logger;
            _lifeSingleton = lifeSingleton;

        }

        public void LogLifetimeSvc()
        {
            _logger.LogInformation($"Transient {_lifeTransient.ID} \n " +
                      $"     Scoped    {_lifeScoped.ID} \n" +
                      $"      Singleton {_lifeSingleton.ID}");
        }
    }
}
