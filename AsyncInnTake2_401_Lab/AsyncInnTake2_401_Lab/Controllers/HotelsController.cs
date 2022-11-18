using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInnTake2_401_Lab.Data;
using AsyncInnTake2_401_Lab.Models;
using AsyncInnTake2_401_Lab.Models.Interfaces;

namespace AsyncInnTake2_401_Lab.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotel _hotel;

        public HotelsController(IHotel h)
        {
         _hotel = h;
        }

        // GET: Hotels
        public async Task<IActionResult> Index()
        {
          return View(await _hotel.GetHotels());
        }

        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _hotel.GetHotels() == null)
            {
                return NotFound();
            }

            var hotel = await _hotel.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,City,State,Address,PhoneNumber,NumberOfRooms")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                await _hotel.Create(hotel);
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _hotel.GetHotels() == null)
            {
                return NotFound();
            }

            var hotel =  await _hotel.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(View(hotel));
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,City,State,Address,PhoneNumber,NumberOfRooms")] Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _hotel.UpdateHotel(hotel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.Id))
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
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _hotel.GetHotels() == null)
            {
                return NotFound();
            }

            var hotel = await _hotel.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_hotel.GetHotels() == null)
            {
                return Problem("Entity set 'AsyncInnDbContext.Hotels'  is null.");
            }
            var hotel = await _hotel.Find(id);
            if (hotel != null)
            {
                await _hotel.Delete(hotel);
            }
            
            await _hotel.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
          return _hotel.Exists(id);
        }
    }
}
