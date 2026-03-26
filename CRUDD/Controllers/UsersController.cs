using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CRUDD.Data;
using CRUDD.Models;



namespace CRUDD.Controllers
{
	public class UserController : Controller
	{
		private readonly ApplicationDbContext _context;

		public UserController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: User
		public IActionResult Index()
		{
			var users = _context.Users.ToList();
			return View(users);
		}

		// GET: User/Details/5
		public IActionResult Details(int id)
		{
			var user = _context.Users.FirstOrDefault(u => u.user_Id == id);
			if (user == null) return NotFound();

			return View(user);
		}

		// GET: User/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: User/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Users user)
		{
			if (ModelState.IsValid)
			{
				_context.Users.Add(user);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(user);
		}

		// GET: User/Edit/5
		public IActionResult Edit(int id)
		{
			var user = _context.Users.FirstOrDefault(u => u.user_Id == id);
			if (user == null) return NotFound();

			return View(user);
		}

		// POST: User/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Users user)
		{
			if (ModelState.IsValid)
			{
				_context.Users.Update(user);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(user);
		}

		// GET: User/Delete/5
		public IActionResult Delete(int id)
		{
			var user = _context.Users.FirstOrDefault(u => u.user_Id == id);
			if (user == null) return NotFound();

			return View(user);
		}

		// POST: User/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var user = _context.Users.FirstOrDefault(u => u.user_Id == id);
			if (user == null) return NotFound();

			_context.Users.Remove(user);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
	}
}
