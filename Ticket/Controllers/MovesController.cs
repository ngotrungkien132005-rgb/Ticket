
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticket.Models;

public class MovesController : Controller
{
    private readonly TicketContext _context;

    public MovesController(TicketContext context)
    {
        _context = context;
    }

    // GET: MOVES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Move.ToListAsync());
    }

    // GET: MOVES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var move = await _context.Move
            .FirstOrDefaultAsync(m => m.Id == id);
        if (move == null)
        {
            return NotFound();
        }

        return View(move);
    }

    // GET: MOVES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MOVES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,RealeaseDate,Duration,GenreId")] Move move)
    {
        if (ModelState.IsValid)
        {
            _context.Add(move);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(move);
    }

    // GET: MOVES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var move = await _context.Move.FindAsync(id);
        if (move == null)
        {
            return NotFound();
        }
        return View(move);
    }

    // POST: MOVES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,RealeaseDate,Duration,GenreId")] Move move)
    {
        if (id != move.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(move);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoveExists(move.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(move);
    }

    // GET: MOVES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var move = await _context.Move
            .FirstOrDefaultAsync(m => m.Id == id);
        if (move == null)
        {
            return NotFound();
        }

        return View(move);
    }

    // POST: MOVES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var move = await _context.Move.FindAsync(id);
        if (move != null)
        {
            _context.Move.Remove(move);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MoveExists(int? id)
    {
        return _context.Move.Any(e => e.Id == id);
    }
}
