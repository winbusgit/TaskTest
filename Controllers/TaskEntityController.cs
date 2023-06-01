using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApplication3CURDWithDapperCore6MVC_Demo.Models;
using WebApplication3CURDWithDapperCore6MVC_Demo.Repositories;

namespace WebApplication3CURDWithDapperCore6MVC_Demo.Controllers
{
	public class TaskEntityController : Controller
	{
        private readonly ITaskRepository _taskRepository;
        public TaskEntityController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        // GET: TaskEntityController
        public async Task<ActionResult> Index()
		{
			var list = await _taskRepository.GetTaskEntity();
			return View(list);
		}

		// GET: TaskEntityController/Details/5
		public async Task<ActionResult> Details(int id)
		{
            var item = await _taskRepository.GetTask(id);
            return View(item);
		}

		// GET: TaskEntityController/Create
		public ActionResult Create()
		{
			var model = new TaskEntity();
			return View(model);
		}

		// POST: TaskEntityController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(TaskEntity model)
		{
			try
			{
                await _taskRepository.CreateTask(model);
                return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: TaskEntityController/Edit/5
		public async Task<ActionResult> Edit(int id)
		{
            var item = await _taskRepository.GetTask(id);
            return View(item);
        }

		// POST: TaskEntityController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(int id, TaskEntity model)
        {
            try
			{
                await _taskRepository.UpdateTask(id,model);
                return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: TaskEntityController/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
            var item = await _taskRepository.GetTask(id);
            return View(item);
        }

		// POST: TaskEntityController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(int id, TaskEntity model)
		{
			try
			{
                await _taskRepository.DeleteTask(id);
                return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
