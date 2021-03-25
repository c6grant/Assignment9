using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class MovieListContext : DbContext
    {



        //This provides context for the DB
        public MovieListContext (DbContextOptions<MovieListContext> options) : base (options)
        {

        }
        public DbSet<MovieItem> Movies { get; set; }

    }
}
