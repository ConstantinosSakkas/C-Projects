﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Food_Final
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class mssql2200984Entities : DbContext
    {
        public mssql2200984Entities()
            : base("name=mssql2200984Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<UserFavorite> UserFavorites { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<UserRatingsReview> UserRatingsReviews { get; set; }
        public virtual DbSet<UserStock> UserStocks { get; set; }
    }
}