using PointCounting.Models;
using PointCounting.MyDatabase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PointCounting.RepositoryServices
{
    public class PlayerRepository
    {
        private ApplicationDbContext db;

        public PlayerRepository(ApplicationDbContext Mycontext)
        {
            db = Mycontext;
        }

        public IEnumerable<Player> GetAll()
        {
            return db.Players.ToList();
        }

        public Player Get(int? id)
        {
            return db.Players.Find(id);
        }

        public void Add(Player player) 
        {
            db.Entry(player).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(Player player)
        {
            db.Entry(player).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Player player = Get(id);
            db.Entry(player).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void UpdatePlayerScore(int? id, int score)
        {
            Player player = Get(id);

            player.Score += score;
            db.Entry(player).State = EntityState.Modified;
            db.SaveChanges();
        }


    }
}