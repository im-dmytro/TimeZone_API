using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TimeZoneAPI.Models;

public partial class CountryTimeApiContext : DbContext
{
    public CountryTimeApiContext()
    {
    }

    public CountryTimeApiContext(DbContextOptions<CountryTimeApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CountryCapital> CountryCapitals { get; set; }

    public virtual DbSet<CountryFlag> CountryFlags { get; set; }

    public virtual DbSet<CountryTimeZone> CountryTimeZones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CountryCapital>(entity =>
        {
            entity.HasKey(e => e.CapitalId).HasName("PK__CountryC__D3DFD193FC2D8284");

            entity.ToTable("CountryCapital");

            entity.Property(e => e.CapitalId).HasColumnName("CapitalID");
            entity.Property(e => e.Capital)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("capital");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("country");
        });

        modelBuilder.Entity<CountryFlag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CountryF__3214EC2719C3C517");

            entity.ToTable("CountryFlag");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(58)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(68)
                .IsUnicode(false)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<CountryTimeZone>(entity =>
        {
            entity.HasKey(e => e.TimeZoneId).HasName("PK__CountryT__78D387CF5E57B2FB");

            entity.Property(e => e.TimeZoneId).HasColumnName("TimeZoneID");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CountryCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Country_Code");
            entity.Property(e => e.GmtOffset)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GMT_Offset");
            entity.Property(e => e.TimeZoneName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Time_Zone_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
