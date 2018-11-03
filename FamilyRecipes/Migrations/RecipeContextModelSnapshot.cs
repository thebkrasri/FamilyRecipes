﻿// <auto-generated />
using System;
using FamilyRecipes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FamilyRecipes.Migrations
{
    [DbContext(typeof(RecipeContext))]
    partial class RecipeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("FamilyRecipes.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("Quantity");

                    b.Property<int>("RecipeID");

                    b.Property<string>("Unit")
                        .IsRequired();

                    b.HasKey("IngredientID");

                    b.HasIndex("RecipeID");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("FamilyRecipes.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("RecipeID");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("FamilyRecipes.Models.Step", b =>
                {
                    b.Property<int>("StepID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Instructions")
                        .IsRequired();

                    b.Property<int>("RecipeID");

                    b.Property<int>("StepNum");

                    b.HasKey("StepID");

                    b.HasIndex("RecipeID");

                    b.ToTable("Step");
                });

            modelBuilder.Entity("FamilyRecipes.Models.Ingredient", b =>
                {
                    b.HasOne("FamilyRecipes.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FamilyRecipes.Models.Step", b =>
                {
                    b.HasOne("FamilyRecipes.Models.Recipe", "Recipe")
                        .WithMany("Steps")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
