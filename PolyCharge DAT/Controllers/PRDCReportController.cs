using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PolyCharge_DAT.Data;
using PolyCharge_DAT.Models;
using ChartDirector;
using Microsoft.AspNetCore.Authorization;

namespace PolyCharge_DAT.Controllers
{
    [Authorize]
    public class PRDCReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PRDCReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Report
        public async Task<IActionResult> Index()
        {
            return _context.Runs != null ?
                        View(await _context.Runs.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Runs'  is null.");
        }

        // GET: Report/Details/5
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

        // GET: Report/Create1/5
        public async Task<IActionResult> Create1(int? id)
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

            var testResults = _context.PRDCTests.Where(b => b.Run_Number.Contains(run.Run_Number)).ToList();
            double[] samples = new double[testResults.Count];

            for (int i = 0; i < testResults.Count; i++)
            {
                samples[i] = Convert.ToDouble(testResults[i].Cap_120Hz_uF);
            }

            if (samples.Length == 0)
            {
                ViewBag.Title = "No Data Found";
                return View("~/Views/PRDCReport/Failed.cshtml", run);
            }

            ViewBag.Title = "Pre-DC Histogram of Capacitance @120Hz";
            CreateChart(ViewBag.Viewer = new RazorChartViewer(HttpContext, "chart1"), samples);
            return View("~/Views/PRDCReport/Create.cshtml", run);
        }

        // GET: Report/Create2/5
        public async Task<IActionResult> Create2(int? id)
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

            var testResults = _context.PRDCTests.Where(b => b.Run_Number.Contains(run.Run_Number)).ToList();
            double[] samples = new double[testResults.Count];

            for (int i = 0; i < testResults.Count; i++)
            {
                samples[i] = Convert.ToDouble(testResults[i].Cap_1kHz_uF);
            }

            if (samples.Length == 0)
            {
                ViewBag.Title = "No Data Found";
                return View("~/Views/PRDCReport/Failed.cshtml", run);
            }

            ViewBag.Title = "Pre-DC Histogram of Capacitance @1kHz";
            CreateChart(ViewBag.Viewer = new RazorChartViewer(HttpContext, "chart1"), samples);
            return View("~/Views/PRDCReport/Create.cshtml", run);
        }

        // GET: Report/Create3/5
        public async Task<IActionResult> Create3(int? id)
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

            var testResults = _context.PRDCTests.Where(b => b.Run_Number.Contains(run.Run_Number)).ToList();
            double[] samples = new double[testResults.Count];

            for (int i = 0; i < testResults.Count; i++)
            {
                samples[i] = Convert.ToDouble(testResults[i].DF_1kHz);
            }

            if (samples.Length == 0)
            {
                ViewBag.Title = "No Data Found";
                return View("~/Views/PRDCReport/Failed.cshtml", run);
            }

            ViewBag.Title = "Pre-DC Histogram of DF @1kHz";
            CreateChart(ViewBag.Viewer = new RazorChartViewer(HttpContext, "chart1"), samples);
            return View("~/Views/PRDCReport/Create.cshtml", run);
        }

        // GET: Report/Create4/5
        public async Task<IActionResult> Create4(int? id)
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

            var testResults = _context.PRDCTests.Where(b => b.Run_Number.Contains(run.Run_Number)).ToList();
            double[] samples = new double[testResults.Count];

            for (int i = 0; i < testResults.Count; i++)
            {
                samples[i] = Convert.ToDouble(testResults[i].ESR1_10kHZ_mOhm);
            }

            if (samples.Length == 0)
            {
                ViewBag.Title = "No Data Found";
                return View("~/Views/PRDCReport/Failed.cshtml", run);
            }

            ViewBag.Title = "Pre-DC Histogram of ESR @10kHz";
            CreateChart(ViewBag.Viewer = new RazorChartViewer(HttpContext, "chart1"), samples);
            return View("~/Views/PRDCReport/Create.cshtml", run);
        }

        // GET: Report/Create5/5
        public async Task<IActionResult> Create5(int? id)
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

            var testResults = _context.PRDCTests.Where(b => b.Run_Number.Contains(run.Run_Number)).ToList();
            double[] samples = new double[testResults.Count];

            for (int i = 0; i < testResults.Count; i++)
            {
                samples[i] = Convert.ToDouble(testResults[i].ESR2_20kHZ_mOhm);
            }

            if (samples.Length == 0)
            {
                ViewBag.Title = "No Data Found";
                return View("~/Views/PRDCReport/Failed.cshtml", run);
            }

            ViewBag.Title = "Pre-DC Histogram of ESR @20kHz";
            CreateChart(ViewBag.Viewer = new RazorChartViewer(HttpContext, "chart1"), samples);
            return View("~/Views/PRDCReport/Create.cshtml", run);
        }

        // GET: Report/Create6/5
        public async Task<IActionResult> Create6(int? id)
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

            var testResults = _context.PRDCTests.Where(b => b.Run_Number.Contains(run.Run_Number)).ToList();
            double[] samples = new double[testResults.Count];

            for (int i = 0; i < testResults.Count; i++)
            {
                samples[i] = Convert.ToDouble(testResults[i].ESR3_100kHz_mOhm);
            }

            if (samples.Length == 0)
            {
                ViewBag.Title = "No Data Found";
                return View("~/Views/PRDCReport/Failed.cshtml", run);
            }

            ViewBag.Title = "Pre-DC Histogram of ESR @100kHz";
            CreateChart(ViewBag.Viewer = new RazorChartViewer(HttpContext, "chart1"), samples);
            return View("~/Views/PRDCReport/Create.cshtml", run);
        }

        //
        // Create chart
        //
        private void CreateChart(RazorChartViewer viewer, double[] samples)
        {
            //
            // This example demonstrates creating a histogram with a bell curve from raw data. About half
            // of the code is to sort the raw data into slots and to generate the points on the bell
            // curve. The remaining half of the code is the actual charting code.
            //

            // Generate a random guassian distributed data series as the input data for this example.
            //RanSeries r = new RanSeries(66);
            //double[] samples = r.getGaussianSeries(200, 100, 10);


            // The mean and standard deviation of the data
            ArrayMath m = new ArrayMath(samples);
            double mean = m.avg();
            double stdDev = m.stdDev();

            //
            // Classify the numbers into slots.
            //
            double slotSize = stdDev / 3;

            // Compute the min and max values, and extend them to the slot boundary.
            double minX = (int)(m.min() / slotSize) * slotSize;
            double maxX = (int)(m.max() / slotSize) * slotSize + slotSize;

            // We can now determine the number of slots
            int slotCount = (int)((maxX - minX) / slotSize + 0.5);
            double[] frequency = new double[slotCount];

            // Count the data points contained in each slot
            for (int i = 0; i < samples.Length; ++i)
            {
                int slotIndex = (int)((samples[i] - minX) / slotSize);
                frequency[slotIndex] = frequency[slotIndex] + 1;
            }

            //
            // Compute Normal Distribution Curve
            //

            // The normal distribution curve (bell curve) is a standard statistics curve. We need to
            // vertically scale it to make it proportion to the frequency count.
            double scaleFactor = slotSize * samples.Length / stdDev / Math.Sqrt(2 * 3.1416);

            // In this example, we plot the bell curve up to 3 standard deviations.
            double stdDevWidth = 3.0;

            // We generate 4 points per standard deviation to be joined with a spline curve.
            int bellCurveResolution = (int)(stdDevWidth * 4 + 1);
            double[] bellCurve = new double[bellCurveResolution];
            for (int i = 0; i < bellCurveResolution; ++i)
            {
                double z = 2 * i * stdDevWidth / (bellCurveResolution - 1) - stdDevWidth;
                bellCurve[i] = Math.Exp(-z * z / 2) * scaleFactor;
            }

            //
            // At this stage, we have obtained all data and can plot the chart.
            //

            // Create a XYChart object of size 600 x 360 pixels
            XYChart c = new XYChart(600, 360);

            // Set the plotarea at (50, 30) and of size 500 x 300 pixels, with transparent background and
            // border and light grey (0xcccccc) horizontal grid lines
            c.setPlotArea(50, 30, 500, 300, Chart.Transparent, -1, Chart.Transparent, 0xcccccc);

            // Display the mean and standard deviation on the chart

            c.addTitle("Mean = " + c.formatValue(mean, "{value|1}") + ", Standard Deviation = " +
                c.formatValue(stdDev, "{value|2}"), "Arial");


            // Set the x and y axis label font to 12pt Arial
            c.xAxis().setLabelStyle("Arial", 12);
            c.yAxis().setLabelStyle("Arial", 12);

            // Set the x and y axis stems to transparent, and the x-axis tick color to grey (0x888888)
            c.xAxis().setColors(Chart.Transparent, Chart.TextColor, Chart.TextColor, 0x888888);
            c.yAxis().setColors(Chart.Transparent);

            // Draw the bell curve as a spline layer in red (0xdd0000) with 2-pixel line width
            SplineLayer bellLayer = c.addSplineLayer(bellCurve, 0xdd0000);
            bellLayer.setXData2(mean - stdDevWidth * stdDev, mean + stdDevWidth * stdDev);
            bellLayer.setLineWidth(2);
            // No tooltip is needed for the spline layer
            bellLayer.setHTMLImageMap("{disable}");

            // Draw the histogram as bars in blue (0x6699bb) with dark blue (0x336688) border
            BarLayer histogramLayer = c.addBarLayer(frequency, 0x6699bb);
            histogramLayer.setBorderColor(0x336688);
            // The center of the bars span from minX + half_bar_width to maxX - half_bar_width
            histogramLayer.setXData2(minX + slotSize / 2.0, maxX - slotSize / 2.0);
            // Configure the bars to touch each other with no gap in between
            histogramLayer.setBarGap(Chart.TouchBar);
            // Use rounded corners for decoration
            histogramLayer.setRoundedCorners();
            // Tool tip for the histogram
            histogramLayer.setHTMLImageMap("", "", "title='{value}'");

            // ChartDirector by default will extend the x-axis scale by 0.5 unit to cater for the bar
            // width. It is because a bar plotted at x actually occupies (x +/- half_bar_width), and the
            // bar width is normally 1 for label based x-axis. However, this chart is using a linear
            // x-axis instead of label based. So we disable the automatic extension and add a dummy layer
            // to extend the x-axis scale to cover minX to maxX.
            c.xAxis().setIndent(false);
            c.addLineLayer2().setXData(minX, maxX);

            // For the automatic y-axis labels, set the minimum spacing to 40 pixels.
            c.yAxis().setTickDensity(40);

            // Output the chart
            viewer.Image = c.makeWebImage(Chart.SVG);

            // Include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("");
        }
    }
}
