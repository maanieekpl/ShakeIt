﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShakeIt.Models;

namespace ShakeIt.Controllers
{
    public class DrinksController : Controller
    {
        private readonly MyDbContext _context;

        public DrinksController(MyDbContext context)
        {
            _context = context;
        }
        //################################################################################################
        //GET: Drinks
        //################################################################################################
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drink.ToListAsync());
        }

        //################################################################################################
        //GET: Drinks/5
        //################################################################################################
        public async Task<IActionResult> Drink (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink.SingleOrDefaultAsync(m => m.DrinkId == id);
            var drinkIngridients = await _context.DrinkIngridients.Where(m => m.DrinkId == id).ToListAsync();

            var temp = await (from di in _context.DrinkIngridients
                        join i in _context.Ingridient on di.IngridientId equals i.IngridId
                        where di.DrinkId == id
                        select new
                        {
                            DrinkId = di.DrinkId,
                            IngridId = di.IngridientId,
                            IngridName = i.IngridName,
                            Capacity = di.Capacity
                        }).ToListAsync();
          
            
            DrinkHelper drinkHelper = new DrinkHelper();
            drinkHelper.DHId = drink.DrinkId;
            drinkHelper.DHDrink = drink;
            for(int i = 0; i < temp.Count; i++)
            {
                DrinkIngridientsHelper dih = new DrinkIngridientsHelper
                {
                    DrinkId = temp[i].DrinkId,
                    //IngridientId = temp[i].IngridId,
                    IngridName = temp[i].IngridName,
                    Capacity = temp[i].Capacity
                };
                drinkHelper.DHDIHelper.Add(dih);
            }


            //drinkHelper.DHDrinkIngrid = drinkIngridients;
            //var drinkIngridients = await _context.DrinkIngridientsTable.Select(m => new DrinkIngridientsTable
            //{
            //    DrinkId = m.DrinkId,
            //    IngridientId = m.IngridientId,
            //    Capacity = m.Capacity
            //}).ToListAsync();
            //var drink = new Drink(drinkTable.DrinkId, drinkTable, drinkIngridients);


            if (drink == null)
            {
                return NotFound();
            }
            return View(drinkHelper);
        }

        //################################################################################################
        //GET: Drinks/Create
        //################################################################################################
        public IActionResult Create()
        {
            return View();
        }

        //################################################################################################
        //POST: Test/Create
        //################################################################################################
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrinkId, DrinkName, DrinkType")] Drink drink)
        {
            drink.DrinkId = await _context.Drink.MaxAsync(m => m.DrinkId) + 1;
            drink.IngridientsCount = 0;

            if (ModelState.IsValid)
            {
                _context.Add(drink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit));
            }
            return View(drink.DrinkId);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("DHId, DHDrink, DHDIHelper")] DrinkHelper drinkHelper)
        //{
        //    drinkHelper.DHDrink.DrinkId = await _context.Drink.MaxAsync(m => m.DrinkId) + 1;

        //    Drink drink = new Drink();
        //    drink = drinkHelper.DHDrink;

        //    List<DrinkIngridientsHelper> dih = new List<DrinkIngridientsHelper>();
        //    dih = drinkHelper.DHDIHelper;
        //    List<DrinkIngridients> drinkIngridients = new List<DrinkIngridients>();
        //    for(int i = 0; i < dih.Count; i++)
        //    {
        //        DrinkIngridients di = new DrinkIngridients
        //        {
        //            DrinkId = drinkHelper.DHDrink.DrinkId,
        //            //IngridientId = dih[i].IngridientId,
        //            IngridientId = _context.Ingridient.SingleOrDefault(m => m.IngridName == dih[i].IngridName).IngridId,
        //            Capacity = dih[i].Capacity
        //        };
        //        drinkIngridients.Add(di);
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(drink);
        //        await _context.SaveChangesAsync();
        //        _context.AddRange(drinkIngridients);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(drinkHelper);
        //}

        //################################################################################################
        //GET: Drinks/Edit/5
        //################################################################################################
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink.SingleOrDefaultAsync(m => m.DrinkId == id);
            var drinkIngridients = await _context.DrinkIngridients.Where(m => m.DrinkId == id).ToListAsync();

            var temp = await (from di in _context.DrinkIngridients
                              join i in _context.Ingridient on di.IngridientId equals i.IngridId
                              where di.DrinkId == id
                              select new
                              {
                                  DrinkId = di.DrinkId,
                                  IngridId = di.IngridientId,
                                  IngridName = i.IngridName,
                                  Capacity = di.Capacity
                              }).ToListAsync();


            DrinkHelper drinkHelper = new DrinkHelper();
            drinkHelper.DHId = drink.DrinkId;
            drinkHelper.DHDrink = drink;
            for (int i = 0; i < temp.Count; i++)
            {
                DrinkIngridientsHelper dih = new DrinkIngridientsHelper
                {
                    DrinkId = temp[i].DrinkId,
                    //IngridientId = temp[i].IngridId,
                    IngridName = temp[i].IngridName,
                    Capacity = temp[i].Capacity
                };
                drinkHelper.DHDIHelper.Add(dih);
            }

            if (drink == null)
            {
                return NotFound();
            }
            return View(drinkHelper);

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var drink = await _context.Drink.SingleOrDefaultAsync((System.Linq.Expressions.Expression<Func<Drink, bool>>)(m => m.DrinkId == id));
            //if (drink == null)
            //{
            //    return NotFound();
            //}
            //return View(drink);
        }

        //################################################################################################
        //POST: Drinks/Edit/5
        //################################################################################################
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DrinkId,DrinkName,DrinkType")]Drink drink)
        {
            if (id != drink.DrinkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrinkExists(drink.DrinkId))
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
            return View(drink);
        }

        //################################################################################################
        //GET: Drinks/Delete/5
        //################################################################################################
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink.SingleOrDefaultAsync((System.Linq.Expressions.Expression<Func<Drink, bool>>)(m => m.DrinkId == id));
            if (drink == null)
            {
                return NotFound();
            }
            return View(drink);
        }

        //################################################################################################
        //POST: Drink/Delete/5
        //################################################################################################
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myUser = await _context.Drink.SingleOrDefaultAsync((System.Linq.Expressions.Expression<Func<Drink, bool>>)(m => m.DrinkId == id));
            _context.Drink.Remove((Drink)myUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrinkExists(int drinkId)
        {
            return _context.Drink.Any((System.Linq.Expressions.Expression<Func<Drink, bool>>)(e => e.DrinkId == drinkId));
        }

        //################################################################################################
        //GET: Drinks/AddIngridient
        //################################################################################################
        public IActionResult Ingridients(int? id)
        {
            return View();
        }

        //################################################################################################
        //POST: Drnik/AddIngridient
        //################################################################################################
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ingridients([Bind("DrinkId, IngridName, Capacity")] DrinkIngridientsHelper dih)
        {
            
            Drink drink = await _context.Drink.SingleOrDefaultAsync(m => m.DrinkId == dih.DrinkId);
            DrinkIngridients di = new DrinkIngridients();

            int test1 = dih.DrinkId;
            String test2 = dih.IngridName;
            String test3 = dih.Capacity;
            int test = 0;

                  
                di.IngridientId = _context.Ingridient.SingleOrDefault(m => m.IngridName == dih.IngridName).IngridId;
                di.DrinkId = dih.DrinkId;
                di.Capacity = dih.Capacity;

            drink.IngridientsCount++;

            //drink.DrinkId = await _context.Drink.MaxAsync(m => m.DrinkId) + 1;

            if (ModelState.IsValid)
            {
                _context.Add(di);
                _context.Update(drink);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Edit));
            }
            return View(dih);
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}