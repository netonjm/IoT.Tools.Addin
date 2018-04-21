using System;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;

namespace NewApp
{
	public class Book
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class BookServiceController : ApiController
	{
		readonly List<Book> data = new List<Book> ();

		public BookServiceController () 
		{
			data.Add (new Book { Id = 1, Name = "Test1" });
			data.Add (new Book { Id = 2, Name = "Test2" });
		}

		[Route ("api/books")]
		public IEnumerable<Book> GetBooks () 
		{
			return data;
		}

		[Route ("api/books/{id:int}")]
		public Book GetBook (int id)
		{
			return data.FirstOrDefault (s => s.Id == id);
		}

		[Route ("api/books")]
		[HttpPost]
		public HttpResponseMessage CreateBook (Book book) 
		{
			data.Add (book);
			return new HttpResponseMessage (HttpStatusCode.OK);
		}
	}
}
