﻿using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Presentation;
using Microsoft.EntityFrameworkCore;


namespace CleanArchitecture.Persistance.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries();

        foreach (var entry in entries)
        {
            if (entry.State==EntityState.Added)
               entry.Property("CreatedDate").CurrentValue = DateTime.Now;
            if (entry.State == EntityState.Modified)
                entry.Property("UpdatedDate").CurrentValue = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

}
