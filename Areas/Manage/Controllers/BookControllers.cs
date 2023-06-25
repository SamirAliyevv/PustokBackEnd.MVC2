using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Areas.Manage.ViewModels;
using Pustok.DAL;
using Pustok.Entities;
using Pustok.Helpers;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BookController : Controller
    {
        private readonly RelationsBooksShop _context;
        private readonly IWebHostEnvironment _env;
        public BookController (RelationsBooksShop context,IWebHostEnvironment env )
        {
            _context = context;
            _env = env;

           
        }
        public IActionResult Index(int page=1)
        {
            var query = _context.Books.Include(x=>x.Authors).Include(x=>x.Genres).Include(x=>x.BooksImages.Where(bi=>bi.PosterImage==true));  

            return View( PaginatedList<Books>.Create(query,page,4));

        }
        public IActionResult Create() 
        {
            ViewBag.Tags = _context.Tags.ToList();
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Books book)
        {
            if (book.PosterFile == null)
            {
                ModelState.AddModelError("PosterFile", "PosterFile is required");
            }
            if (book.HoverPosterFile == null)
            {
                ModelState.AddModelError("HoverPosterFile", "HoverPosterFile is required");
            }
        


            if (!ModelState.IsValid)
            {
                ViewBag.Authors = _context.Authors.ToList();
                ViewBag.Genres = _context.Genres.ToList();
                ViewBag.Tags = _context.Tags.ToList();
                return View();
            }
              


            if (!_context.Authors.Any(x=>x.Id==book.AuthorsId))
            {
                return View("error");
            }
            if (!_context.Genres.Any(x => x.Id == book.GenresId))
            {
                return View("error");
            }



            BooksImage poster = new BooksImage
            {
                PosterImage = true,
                ImageUrl = FileManager.Save(book.PosterFile, _env.WebRootPath, "manage/uploads/books"),
              
            };
            book.BooksImages.Add(poster);
            _context.BooksImages.Add(poster);
            BooksImage hoverPoster = new BooksImage
            {
                PosterImage = false,
                ImageUrl = FileManager.Save(book.HoverPosterFile, _env.WebRootPath, "manage/uploads/books"),

            };
            book.BooksImages.Add(hoverPoster);
            foreach (var file in book.ImageFIles)
            {
                BooksImage bookImage = new BooksImage
                {
                    PosterImage = null,
                    ImageUrl = FileManager.Save(file, _env.WebRootPath, "manage/uploads/books"),

                };
                book.BooksImages.Add(bookImage);
            }




            foreach (var tagId in book.TagIds)
            {
                if (!_context.Tags.Any(x => x.Id == tagId))
                {
                    return View("error");
                }


                BooksTags tag = new BooksTags
                {
                    TagsId = tagId
                };


                book.BooksTags.Add(tag);
            }






            _context.Books.Add(book);   


            _context.SaveChanges();


            return RedirectToAction("Index");
        }
        public IActionResult Edit (int id)
        {

         
            Books books = _context.Books.Include(x=>x.BooksImages).Include(x=>x.BooksTags).FirstOrDefault(x => x.Id == id);



            if (books ==null)
            {
                return View("error");   
            }

        books.TagIds = books.BooksTags.Select(x=>x.TagsId).ToList();    


            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View(books);
        }

        [HttpPost]
        public IActionResult Edit (Books book) {

            Books existsbook = _context.Books.Include(x=>x.BooksImages).Include(x=>x.BooksTags).FirstOrDefault(x=>x.Id==book.Id);

            if (existsbook==null)
            {
                return View("Error");
            }



            if (!_context.Authors.Any(x=>x.Id== book.AuthorsId))
            {
                return View("Error");
            }



            if (!_context.Genres.Any(x => x.Id == book.GenresId))
            {
                return View("Error");
            }

            existsbook.BooksTags = new List<BooksTags>();

            foreach (var tagId in book.TagIds)
            {
                if (!_context.Tags.Any(x=>x.Id == tagId))
                {
                    return View("Error");
                }

               existsbook.BooksTags.Add(new BooksTags () { TagsId = tagId});

            }
           




            existsbook.Name = book.Name;
            existsbook.Description = book.Description;
            existsbook.CostPrice = book.CostPrice;
            existsbook.Price = book.Price;
            existsbook.Percent = book.Percent;
            existsbook.IsFeatured = book.IsFeatured;
            existsbook.IsNew = book.IsNew;  
            existsbook.StockStatus = book.StockStatus; 
            existsbook.AuthorsId = book.AuthorsId;  
            existsbook.GenresId = book.GenresId;

            List<string> removeableFile = new List<string>();
            if (book.PosterFile != null)
            {

                BooksImage poster = existsbook.BooksImages.First(x => x.PosterImage == true);

                removeableFile.Add(poster.ImageUrl);

                poster.ImageUrl = FileManager.Save(book.PosterFile, _env.WebRootPath, "manage/uploads/books");

            }
            if (book.HoverPosterFile != null)
            {



                BooksImage hoverPoster = existsbook.BooksImages.First(x => x.PosterImage == false   );

                removeableFile.Add(hoverPoster.ImageUrl);

                hoverPoster.ImageUrl = FileManager.Save(book.HoverPosterFile, _env.WebRootPath, "manage/uploads/books");

            }

            foreach (var file in book.ImageFIles)
            {
                BooksImage image = new BooksImage()
                {

                    PosterImage = null,
                    ImageUrl = FileManager.Save(file, _env.WebRootPath, "manage/uploads/books")

               };
                existsbook.BooksImages.Add(image);

            }


         

            _context.SaveChanges();


            FileManager.DeleteAll(_env.WebRootPath, "manage/uploads/books", removeableFile);

            return   RedirectToAction("Index");
        }


    }


}

