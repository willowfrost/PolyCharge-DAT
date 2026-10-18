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
using static System.Net.Mime.MediaTypeNames;

namespace PolyCharge_DAT.Controllers
{
    [Authorize(Roles = "admin")]
    public class PRDCTestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public PRDCTestController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: PRDCTest
        public async Task<IActionResult> Index()
        {
              return _context.PRDCTests != null ? 
                          View(await _context.PRDCTests.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PRDCTests'  is null.");
        }

        // GET: PRDCTest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PRDCTests == null)
            {
                return NotFound();
            }

            var pRDCTest = await _context.PRDCTests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pRDCTest == null)
            {
                return NotFound();
            }

            return View(pRDCTest);
        }

        // GET: PRDCTest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PRDCTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Run_Number,Card,Lane,Note_A,Note_B,Date_Time,Series,Part_Size,Cap_120Hz_uF,Cap_1kHz_uF,DF_1kHz,ESR1_10kHZ_mOhm,ESR2_20kHZ_mOhm,ESR3_100kHz_mOhm")] PRDCTest pRDCTest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pRDCTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pRDCTest);
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
            for (int i = 1; i < csvLines.Length - 3; i++)
            {
                // Console.WriteLine(csvLines[i]);
                string[] rowData = csvLines[i].Split(',');
                var test = new PRDCTest();
                test.Id = 0;
                test.Run_Number = Convert.ToString(rowData[3]).Trim();
                test.Card = Convert.ToInt32(rowData[4]);
                test.Lane = Convert.ToInt32(rowData[5]);
                test.Note_A = Convert.ToString(rowData[6]).Trim();
                test.Note_B = Convert.ToString(rowData[7]).Trim();
                test.Date_Time = Convert.ToString(rowData[0]).Trim();
                test.Series = Convert.ToInt32(rowData[1]);
                test.Part_Size = Convert.ToInt32(rowData[2]);
                test.Cap_120Hz_uF = (float)Convert.ToDouble(rowData[8]);
                test.Cap_1kHz_uF = (float)Convert.ToDouble(rowData[9]);
                test.DF_1kHz = (float)Convert.ToDouble(rowData[10]);
                test.ESR1_10kHZ_mOhm = (float)Convert.ToDouble(rowData[11]);
                test.ESR2_20kHZ_mOhm = (float)Convert.ToDouble(rowData[12]);
                test.ESR3_100kHz_mOhm = (float)Convert.ToDouble(rowData[13]);
                _context.Add(test);
                await _context.SaveChangesAsync();
            }

            ViewBag.Title = "File Upload Complete";
            return View();
        }

        // GET: PRDCTest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PRDCTests == null)
            {
                return NotFound();
            }

            var pRDCTest = await _context.PRDCTests.FindAsync(id);
            if (pRDCTest == null)
            {
                return NotFound();
            }
            return View(pRDCTest);
        }

        // POST: PRDCTest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Run_Number,Card,Lane,Note_A,Note_B,Date_Time,Series,Part_Size,Cap_120Hz_uF,Cap_1kHz_uF,DF_1kHz,ESR1_10kHZ_mOhm,ESR2_20kHZ_mOhm,ESR3_100kHz_mOhm")] PRDCTest pRDCTest)
        {
            if (id != pRDCTest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pRDCTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PRDCTestExists(pRDCTest.Id))
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
            return View(pRDCTest);
        }

        // GET: PRDCTest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PRDCTests == null)
            {
                return NotFound();
            }

            var pRDCTest = await _context.PRDCTests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pRDCTest == null)
            {
                return NotFound();
            }

            return View(pRDCTest);
        }

        // POST: PRDCTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PRDCTests == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PRDCTests'  is null.");
            }
            var pRDCTest = await _context.PRDCTests.FindAsync(id);
            if (pRDCTest != null)
            {
                _context.PRDCTests.Remove(pRDCTest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PRDCTestExists(int id)
        {
          return (_context.PRDCTests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
