using AutoMapper;
using BookService.DbContexts;
using BookService.Services;
using BookService.Utility;
using BookService.Utility.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;

        private readonly IBookSvc _bookSvc;
        private readonly IBookTransformer _bookTransformer;
        
        ILifeTransient _lifeTransient;
        ILifeScoped _lifeScoped;
        ILifeSingleton _lifeSingleton;
        IServicesLifeTimesReq _servicesLifeTimeSameRequest;
        public BooksController(ILogger<BooksController> logger, IBookSvc bookSvc, 
            IBookTransformer bookTransformer,
            ILifeTransient lifeTransient,
            ILifeScoped lifeScoped, 
            ILifeSingleton  lifeSingleton,
            IServicesLifeTimesReq servicesLifeTimes)
        {
            _logger = logger;
            _bookSvc = bookSvc;
            _bookTransformer = bookTransformer;
            _lifeScoped = lifeScoped;
            _lifeTransient=lifeTransient;
            _servicesLifeTimeSameRequest = servicesLifeTimes;
            _lifeSingleton=lifeSingleton;
        }
        [HttpGet]
        public List<Models.BookModel> Get()
        {
            _logger.LogInformation("Start API: Books.Get() ");
            return _bookSvc.GetBooks().ToList();
        }
        [HttpGet]
        [Route("GetBooksTitleSentenceCase")]
        public List<Models.BookModel> GetBooksApplySentenceCase()
        {
            _logger.LogInformation("Start API: Books.GetBooksApplySentenceCase() ");
            var books = _bookSvc.GetBooks().ToList();
            books = _bookTransformer.GetBookNameSentenceCase(books);
            return books;
        }
        [HttpGet]
        [Route("TestServicesLifeTime")]
        public void TestServicesLifeTime()
        {
            _logger.LogInformation($"Transient {_lifeTransient.ID} \n " +
                                    $"     Scoped    {_lifeScoped.ID} \n" +
                                    $"      Singleton {_lifeSingleton.ID}");

            _servicesLifeTimeSameRequest.LogLifetimeSvc();
        }

    }
}
