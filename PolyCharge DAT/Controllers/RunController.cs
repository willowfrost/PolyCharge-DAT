using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PolyCharge_DAT.Data;
using PolyCharge_DAT.Models;

namespace PolyCharge_DAT.Controllers
{
    [Authorize(Roles = "admin")]
    public class RunController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public RunController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Run
        public async Task<IActionResult> Index()
        {
              return _context.Runs != null ? 
                          View(await _context.Runs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Runs'  is null.");
        }

        // GET: Run/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Runs == null)
            {
                return NotFound();
            }

            var run = await _context.Runs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (run == null)
            {
                return NotFound();
            }

            return View(run);
        }

        // GET: Run/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Run/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Run_Number,Customer_Product,Project_Number,Date_Run,Pre_Run_Notes,Oiler_Offset,Evap_Tank_Temp,Evap_Nozzel_Temp,Slit_Gap,Target_Thickness,Mono_Flow_Rate,Mono_Pump,Wire_Inner_Speed,Wire_Outer_Boat,Wire_2nd_Outer_Boat,Target_OD,E_Gun_KV,E_Gun_mA,E_Gun_Ar_Flow,Magnetron_Supply,Magnetron_Power,Magnetron_Ar_Gas_Flow,Magnetron_O2_Gas_Flow,Shadow_Mask,Shadow_Mask_Start_Position,Shadow_Mask_Movement,Oiler_Faceplates,Oiler_Temperature,Oiler_Gas_Flow,Oiler_Start_Position,Oiler_Shift,Oiler_Step_back,Drum_Temp,Web_Speed,Film,Release,Bottom_Mono_Only_Layers,Bottom_Inactive_Layers,Active_Layers,Top_Inactive_Layers,Top_Mono_Only_Layers,Total_layers")] Run run)
        {
            if (ModelState.IsValid)
            {
                _context.Add(run);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(run);
        }

        // GET: Test/Upload
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            string fileName = Path.GetFileName(file.FileName);
            string folderPath = this._environment.WebRootPath + "\\uploads\\";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            string uploadPath = folderPath + fileName;

            if (System.IO.File.Exists(uploadPath))
            {
                ViewBag.Title = "File Already Uploaded";
                return View();
            }

            if (file.Length > 0)
            {
                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            if (!System.IO.File.Exists(uploadPath))
            {
                ViewBag.Title = "Cannot Find File On Server";
                return View();
            }

            string[] csvLines = System.IO.File.ReadAllLines(uploadPath);
            for (int i = 1; i < csvLines.Length; i++)
            {
                // Console.WriteLine(csvLines[i]);
                string[] rowData = csvLines[i].Split(',');
                var run = new Run();
                run.Id = 0;
                run.Run_Number = Convert.ToString(rowData[0]).Trim();
                run.Customer_Product = Convert.ToString(rowData[1]).Trim();
                run.Project_Number = Convert.ToString(rowData[2]).Trim();
                run.Date_Run = Convert.ToString(rowData[3]).Trim();
                run.Pre_Run_Notes = Convert.ToString(rowData[4]).Trim();
                run.Oiler_Offset = (float)Convert.ToDouble(rowData[5]);
                run.Evap_Tank_Temp = Convert.ToInt32(rowData[6]);
                run.Evap_Nozzel_Temp = Convert.ToInt32(rowData[7]);
                run.Slit_Gap = Convert.ToString(rowData[8]).Trim();
                run.Target_Thickness = Convert.ToInt32(rowData[9]);
                run.Mono_Flow_Rate = Convert.ToInt32(rowData[10]);
                run.Mono_Pump = Convert.ToString(rowData[11]).Trim();
                run.Wire_Inner_Speed = Convert.ToInt32(rowData[12]);
                run.Wire_Outer_Boat = Convert.ToString(rowData[13]).Trim();
                run.Wire_2nd_Outer_Boat = Convert.ToString(rowData[14]).Trim();
                run.Target_OD = (float)Convert.ToDouble(rowData[15]);
                run.E_Gun_KV = Convert.ToInt32(rowData[16]);
                run.E_Gun_mA = Convert.ToInt32(rowData[17]);
                run.E_Gun_Ar_Flow = Convert.ToInt32(rowData[18]);
                run.Magnetron_Supply = Convert.ToString(rowData[19]).Trim();
                run.Magnetron_Power = Convert.ToString(rowData[20]).Trim();
                run.Magnetron_Ar_Gas_Flow = Convert.ToInt32(rowData[21]);
                run.Magnetron_O2_Gas_Flow = Convert.ToInt32(rowData[22]);
                run.Shadow_Mask = Convert.ToString(rowData[23]).Trim();
                run.Shadow_Mask_Start_Position = (float)Convert.ToDouble(rowData[24]);
                run.Shadow_Mask_Movement = Convert.ToInt32(rowData[25]);
                run.Oiler_Faceplates = Convert.ToString(rowData[26]).Trim();
                run.Oiler_Temperature = Convert.ToInt32(rowData[27]);
                run.Oiler_Gas_Flow = Convert.ToInt32(rowData[28]);
                run.Oiler_Start_Position = Convert.ToInt32(rowData[29]);
                run.Oiler_Shift = (float)Convert.ToDouble(rowData[30]);
                run.Oiler_Step_back = Convert.ToInt32(rowData[31]);
                run.Drum_Temp = Convert.ToInt32(rowData[32]);
                run.Web_Speed = Convert.ToInt32(rowData[33]);
                run.Film = Convert.ToString(rowData[34]).Trim();
                run.Release = Convert.ToString(rowData[35]).Trim();
                run.Bottom_Mono_Only_Layers = Convert.ToInt32(rowData[36]);
                run.Bottom_Inactive_Layers = Convert.ToInt32(rowData[37]);
                run.Active_Layers = Convert.ToInt32(rowData[38]);
                run.Top_Inactive_Layers = Convert.ToInt32(rowData[39]);
                run.Top_Mono_Only_Layers = Convert.ToInt32(rowData[40]);
                run.Total_layers = Convert.ToInt32(rowData[41]);
                _context.Add(run);
                await _context.SaveChangesAsync();
            }

            ViewBag.Title = "File Upload Complete";
            return View();
        }

        // GET: Run/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Runs == null)
            {
                return NotFound();
            }

            var run = await _context.Runs.FindAsync(id);
            if (run == null)
            {
                return NotFound();
            }
            return View(run);
        }

        // POST: Run/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Run_Number,Customer_Product,Project_Number,Date_Run,Pre_Run_Notes,Oiler_Offset,Evap_Tank_Temp,Evap_Nozzel_Temp,Slit_Gap,Target_Thickness,Mono_Flow_Rate,Mono_Pump,Wire_Inner_Speed,Wire_Outer_Boat,Wire_2nd_Outer_Boat,Target_OD,E_Gun_KV,E_Gun_mA,E_Gun_Ar_Flow,Magnetron_Supply,Magnetron_Power,Magnetron_Ar_Gas_Flow,Magnetron_O2_Gas_Flow,Shadow_Mask,Shadow_Mask_Start_Position,Shadow_Mask_Movement,Oiler_Faceplates,Oiler_Temperature,Oiler_Gas_Flow,Oiler_Start_Position,Oiler_Shift,Oiler_Step_back,Drum_Temp,Web_Speed,Film,Release,Bottom_Mono_Only_Layers,Bottom_Inactive_Layers,Active_Layers,Top_Inactive_Layers,Top_Mono_Only_Layers,Total_layers")] Run run)
        {
            if (id != run.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(run);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RunExists(run.Id))
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
            return View(run);
        }

        // GET: Run/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Runs == null)
            {
                return NotFound();
            }

            var run = await _context.Runs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (run == null)
            {
                return NotFound();
            }

            return View(run);
        }

        // POST: Run/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Runs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Runs'  is null.");
            }
            var run = await _context.Runs.FindAsync(id);
            if (run != null)
            {
                _context.Runs.Remove(run);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RunExists(int id)
        {
          return (_context.Runs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
