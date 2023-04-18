namespace EventSystem.Helpers;

using EventSystem.Models;
using Microsoft.EntityFrameworkCore;
//using EventManager.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }

    public DbSet<Ticket> Tickets { get; set; }
}