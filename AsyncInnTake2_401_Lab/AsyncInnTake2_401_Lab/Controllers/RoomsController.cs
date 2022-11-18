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
    public class RoomsController : Controller
    {
        private readonly IRoom _room;

        public RoomsController( IRoom r )
        {
         _room = r;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
              return View(await _room.GetRooms());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _room.GetRooms() == null)
            {
                return NotFound();
            }

            var room = await _room.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nickname,RoomAmenities,Price,RoomNumber,IsPetFriendly,AssociatedHotel,Layout")] Room room)
        {
            if (ModelState.IsValid)
            {
                await _room.Create(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _room.GetRooms() == null)
            {
                return NotFound();
            }

            var room = await _room.Find(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nickname,RoomAmenities,Price,RoomNumber,IsPetFriendly,AssociatedHotel,Layout")] Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  await _room.UpdateRoom(room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Id))
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
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _room.GetRooms() == null)
            {
                return NotFound();
            }

            var room = await _room.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_room.GetRooms() == null)
            {
                return Problem("Entity set 'AsyncInnDbContext.Rooms'  is null.");
            }
            var room = await _room.Find(id);
            if (room != null)
            {
                await _room.Delete(room);
            }
            
            await _room.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
          return _room.Exists(id);
        }


        // Post: {roomId}/Amenity/{amenityId}
        //[HttpPost, ActionName("Post")]
        //[ValidateAntiForgeryToken]
        // [Route("{roomId}/Amenity/{amenityId}")]


        // Delete: {roomId}/Amenity/{amenityId}
        [HttpDelete("{roomId}/Amenity/{amenityId}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Route("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> Amenity(int roomId, int amenityId)
        {
          await _room.RemoveAmenityFromRoom(roomId, amenityId);
          return RedirectToAction(nameof(Index)); 
        }
  }
}
