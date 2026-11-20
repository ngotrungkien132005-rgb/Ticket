using Microsoft.EntityFrameworkCore;
using Ticket.Models;

public class TicketContext(DbContextOptions<TicketContext> options) : DbContext(options)
{
    public DbSet<Ticket.Models.Genre> Genre { get; set; } = default!;
    public DbSet<Ticket.Models.Move> Move { get; set; } = default!;
}
