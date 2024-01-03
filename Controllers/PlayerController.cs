using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PointCounting.Models;
using PointCounting.MyDatabase;
using PointCounting.RepositoryServices;

namespace PointCounting.Controllers
{
    public class PlayerController : Controller
    {
        private ApplicationDbContext db;
        private PlayerRepository playerService;

        public PlayerController()
        {
            db = new ApplicationDbContext();
            playerService = new PlayerRepository(db);
        }

        // GET: Player
        public ActionResult Index()
        {
            var players = playerService.GetAll();
            playerService.GetHighestScorePLayer();

            return View(players);
        }

        // GET: Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = playerService.Get(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerId,Name,Score")] Player player)
        {
            if (ModelState.IsValid)
            {
                playerService.Add(player);
                return RedirectToAction("Index");
            }

            return View(player);
        }

        // GET: Player/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = playerService.Get(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerId,Name,Score")] Player player)
        {
            if (ModelState.IsValid)
            {
                playerService.Edit(player);
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = playerService.Get(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            playerService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateScore(int? id, int score)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = playerService.Get(id);
            if (player == null)
            {
                return HttpNotFound();
            }

            playerService.UpdatePlayerScore(player, score);

            return RedirectToAction("Index");
        }

        public ActionResult GetHighestScorePLayer()
        {
            var highestScorePLayer = playerService.GetHighestScorePLayer();
            if (highestScorePLayer == null)
            {
                return HttpNotFound();
            }

            return Json(highestScorePLayer, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
