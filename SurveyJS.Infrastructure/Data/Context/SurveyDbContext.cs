using Microsoft.EntityFrameworkCore;
using SurveyJS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyJS.Infrastructure.Data.Context
{
    public class SurveyDbContext : DbContext
    {
        public DbSet<Survey> Surveys => Set<Survey>();
        public DbSet<Element> Elements => Set<Element>();
        public DbSet<Choice> Choices => Set<Choice>();
        public DbSet<Page> Pages => Set<Page>();
        public DbSet<Submission> Submissions => Set<Submission>();

        public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Survey>()
                .HasKey(i => i.Id);

            builder.Entity<Survey>()
               .HasMany(i => i.Pages)
               .WithOne(i => i.Survey)
               .HasForeignKey(i => i.SurevyId);



            builder.Entity<Page>()
                .HasKey(i => i.Id);

            builder.Entity<Page>()
               .HasMany(i => i.Elements)
               .WithOne(i => i.Page)
               .HasForeignKey(i => i.PageId);



            builder.Entity<Element>()
               .HasKey(i => i.Id);

            builder.Entity<Element>()
               .HasMany(i => i.Choices)
               .WithOne(i => i.Element)
               .HasForeignKey(i => i.ElementId);

            //builder.Entity<Element>()
            //   .HasMany(i => i.Submissions)
            //   .WithOne(i => i.Element)
            //   .HasForeignKey(i => i.ElementId);



            //builder.Entity<Choice>()
            //   .HasKey(i => i.Id);

            //builder.Entity<Choice>()
            //    .HasMany(i => i.Submissions)
            //    .WithOne(i => i.Choice)
            //    .HasForeignKey(i => i.ChoiceId);



            builder.Entity<Submission>()
                .HasKey(i => i.Id);




        }
    }
}
