using PointCounting.MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointCounting.RepositoryServices
{
    public class PlayerRepository
    {
        private ApplicationDbContext db;

        public PlayerRepository(ApplicationDbContext Mycontext)
        {
            db= Mycontext;
        }



    }
}