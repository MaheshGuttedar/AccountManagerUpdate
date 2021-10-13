using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using AccountManager.Models;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Globalization;
using iTextSharp.text.html.simpleparser;

namespace AccountManager.Controllers
{
    public class InvoiceController : BaseController
    { 
        // GET: /Invoice/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET Invoice/GetGrid
        public ActionResult GetGrid()
        {
            try
            {
                int srlno = 1;
                var tak = db.Invoices.ToArray();

                var result = from c in tak
                             select new string[] {
                c.Id.ToString(),
                 Convert.ToString(srlno++),
            Convert.ToString(c.BillDate),
            Convert.ToString(c.DueDate),
            Convert.ToString(db.PaymentStatuss.Find(c.Status).Title),
            Convert.ToString(c.OtherInvoiceCode),
             c.Id.ToString(),
                             };
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
            }
            
            catch (Exception ex)
            {

            }
            return null;


        }
        // GET: /Invoice/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /Invoice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice ObjInvoice = db.Invoices.Find(id);
            if (ObjInvoice == null)
            {
                return HttpNotFound();
            }
            return View(ObjInvoice);
        }
        // GET: /Invoice/Create
        public ActionResult Create(int? id)
        {
            Invoice obInvoice = new Invoice();
            ViewBag.Status = new SelectList(db.PaymentStatuss, "Id", "Title");
            Transaction ObjTransaction = db.Transactions.Find(id);
            ViewBag.Year =db.FinancialYears.Find( ObjTransaction.YearId).StartDate;
            ViewBag.YearId = db.FinancialYears.Find(ObjTransaction.YearId).Id;
            ViewBag.AccountHolderName = db.AccountHolders.Find( ObjTransaction.AccountHolderId).Name;
            ViewBag.AccountHolderId = db.AccountHolders.Find(ObjTransaction.AccountHolderId).Id;
            obInvoice.InstallmentNo = ObjTransaction.InstallmentNo;
            ViewBag.InstallmentNo = ObjTransaction.InstallmentNo;
            ViewBag.TransactionId = ObjTransaction.Id;
            ViewBag.DueDate = db.AccountHolders.Find(ObjTransaction.AccountHolderId).LoanAdvanceDate;

            ViewBag.OfficeId = 1;
            ViewBag.CreatedBy = 1;

            return View();
        }

        // GET: /Invoice/GenerateInvoice
        public ActionResult GenerateInvoice(int Id)
        {
            //ViewBag.YearId = new SelectList(db.FinancialYears, "Id", "StartDate");
            //ViewBag.AccountHolderId = new SelectList(db.AccountHolders, "Id", "Name");
            //ViewBag.Status = new SelectList(db.PaymentStatuss, "Id", "Title");

            ViewBag.TransactionId = Id;

            return View();
        }

        // POST: /Invoice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Invoice ObjInvoice )
        {
            Transaction objTransactions = new Transaction();
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                ObjInvoice.OfficeId = 1;
                ObjInvoice.CreatedBy = 1;
                ObjInvoice.ClientId = 1;
                if (ModelState.IsValid)
                {

                    db.Invoices.Add(ObjInvoice);
                    objTransactions= db.Transactions.Find(ObjInvoice.TransactionId);
                    objTransactions.PaymentStatusId = ObjInvoice.Status;
                    db.Entry(objTransactions).State = EntityState.Modified;
                    db.SaveChanges();
                
                  

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                }
                else
                {
                    foreach (var key in this.ViewData.ModelState.Keys)
                    {
                        foreach (var err in this.ViewData.ModelState[key].Errors)
                        {
                            sb.Append(err.ErrorMessage + "<br/>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }
  
            return Content(sb.ToString());
             
        }
        // GET: /Invoice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice ObjInvoice = db.Invoices.Find(id);
            if (ObjInvoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.Status = new SelectList(db.PaymentStatuss, "Id", "Title", ObjInvoice.Status);
            ViewBag.Year = db.FinancialYears.Find(ObjInvoice.YearId).StartDate;
            ViewBag.YearId = ObjInvoice.YearId;
            ViewBag.AccountHolderName = db.AccountHolders.Find(ObjInvoice.AccountHolderId).Name;
            ViewBag.AccountHolderId = ObjInvoice.AccountHolderId;         
            ViewBag.InstallmentNo = ObjInvoice.InstallmentNo;
            ViewBag.TransactionId = ObjInvoice.Id;
            ViewBag.DueDate = ObjInvoice.DueDate;
            ViewBag.OfficeId = 1;
            ViewBag.CreatedBy = 1;
            return View(ObjInvoice);
        }

        // POST: /Invoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Invoice ObjInvoice )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjInvoice).State = EntityState.Modified;
                    db.SaveChanges();

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                }
                else
                {
                    foreach (var key in this.ViewData.ModelState.Keys)
                    {
                        foreach (var err in this.ViewData.ModelState[key].Errors)
                        {
                            sb.Append(err.ErrorMessage + "<br/>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }
 
             
            return Content(sb.ToString());

        }
       // GET: /Invoice/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Invoice ObjInvoice = db.Invoices.Find(id);

            if (ObjInvoice == null)
            {
                return HttpNotFound();
            }
            return View(ObjInvoice);
        }

        // POST: /Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                Transaction objTransactions = new Transaction();
                Invoice ObjInvoice = db.Invoices.Find(id);
                objTransactions = db.Transactions.Find(ObjInvoice.TransactionId);
                objTransactions.PaymentStatusId = 0;
                db.Entry(ObjInvoice).State = EntityState.Modified;
                db.Invoices.Remove(ObjInvoice);
              
                db.SaveChanges();
                sb.Append("Sumitted");
                return Content(sb.ToString());
                 
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }
  
            return Content(sb.ToString());
  
        }
        // GET: /Invoice/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            Invoice ObjInvoice = db.Invoices.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.Status = new SelectList(db.PaymentStatuss, "Id", "Title", ObjInvoice.Status);
    ViewBag.Status = new SelectList(db.PaymentStatuss, "Id", "Title", ObjInvoice.Status);
            ViewBag.Year = db.FinancialYears.Find(ObjInvoice.YearId).StartDate;
            ViewBag.YearId = ObjInvoice.YearId;
            ViewBag.AccountHolderName = db.AccountHolders.Find(ObjInvoice.AccountHolderId).Name;
            ViewBag.AccountHolderId = ObjInvoice.AccountHolderId;         
            ViewBag.InstallmentNo = ObjInvoice.InstallmentNo;
            ViewBag.TransactionId = ObjInvoice.Id;
            ViewBag.DueDate = ObjInvoice.DueDate;
                ViewBag.OfficeId = 1;

            }
            
            return View(ObjInvoice);
        }

        // POST: /Invoice/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Invoice ObjInvoice )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                {

                    ObjInvoice.OfficeId = 1;
                    ObjInvoice.CreatedBy = 1;
                    ObjInvoice.ClientId = 1;
                    db.Entry(ObjInvoice).State = EntityState.Modified;
                    db.SaveChanges();
                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                }
                else
                {
                    foreach (var key in this.ViewData.ModelState.Keys)
                    {
                        foreach (var err in this.ViewData.ModelState[key].Errors)
                        {
                            sb.Append(err.ErrorMessage + "<br/>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            } 
             
            return Content(sb.ToString());
 
        }
         public ActionResult InvoiceTransactionGetGrid(int id=0)
        {
            var tak = db.InvoiceTransactions.Where(i=>i.InvoiceId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.InvoiceId),
                Convert.ToString(c.Transaction_TransactionId.Title), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult InvoiceItemGetGrid(int id=0)
        {
            var tak = db.InvoiceItems.Where(i=>i.InvoiceId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Description),
                Convert.ToString(c.Title),
                Convert.ToString(c.Quantity),
                Convert.ToString(c.UnitPrice),
                Convert.ToString(c.Id),
                Convert.ToString(c.Total),
                Convert.ToString(c.InvoiceId),
                Convert.ToString(c.QuantityUnit_UnitName.Id), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        


        public FileStreamResult GenerateReport(int id)
        {


            // Set up the document and the MS to write it to and create the PDF writer instance
            var ms = new MemoryStream();
            var document = new Document(PageSize.A4, 0, 0, 0, 0);
            PdfWriter writer = PdfWriter.GetInstance(document, ms);
            //var obj = new simphiwe();
            var obj = new SIContext();

            // Open the PDF document
            document.Open();

            // Set up fonts used in the document
            Font font_heading_3 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, Font.BOLD, BaseColor.RED);
            Font font_body = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, BaseColor.BLUE);

            // Create the heading paragraph with the headig font
            Paragraph paragraph;
            paragraph = new Paragraph("SHREE OM SAI LEASING", font_heading_3);
            Paragraph paraslip;
            paraslip = new Paragraph("**********************Invoice Details***********************");
            paragraph.SpacingBefore = 20;
            // Add image to pdf    
            // Create the heading paragraph with the headig font
            var info = from x in obj.Invoices
                       where x.Id == (id)
                       select x;
            foreach (var q in info)
            {
                decimal? InstallmentAmt = db.Transactions.Where(r=>r.Id==q.TransactionId).Select(r=>r.CreditAmount).FirstOrDefault() ?? 0.0m;
                string paymentStatus = db.PaymentStatuss.Find(q.Status).Title;
                //paragraph;
                // Add a horizontal line below the headig text and add it to the paragraph
                iTextSharp.text.pdf.draw.VerticalPositionMark seperator = new iTextSharp.text.pdf.draw.LineSeparator();
                seperator.Offset = -6f;

                var table1 = new PdfPTable(1);
                var table = new PdfPTable(1);
                var table3 = new PdfPTable(1);
                var table7 = new PdfPTable(1);
                var table8 = new PdfPTable(1);
                table.WidthPercentage = 80;
                table3.SetWidths(new float[] { 100 });
                table3.WidthPercentage = 80;
                table7.SetWidths(new float[] { 100 });
                table7.WidthPercentage = 80;
                var cell = new PdfPCell(new Phrase(""));
                cell.Colspan = 3;
                table1.AddCell(cell);
                table7.AddCell("**********************************SHREE OM SAI LEASING**********************************\n\n"
                 + "         Jewargi Complex, Kamalapur, Dist - Kalaburagi Cell - 8660469698");
                
                table.AddCell("Receipt No           : " + q.Id);
                table.AddCell("Register Account No  : " + db.AccountHolders.Find(q.AccountHolderId).AccountNoFromRegister);
                table.AddCell("Name                 : " + db.AccountHolders.Find(q.AccountHolderId).Name);
                table.AddCell("Payment Type         : " + paymentStatus);
                table.AddCell("Installment          : " + q.InstallmentNo);
                table.AddCell("Payment Date         : " + DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));                
                table.AddCell("Installment Amount   : " + InstallmentAmt);
                table.AddCell("Transaction Code     : " + q.OtherInvoiceCode);
                table8.AddCell("Party Signature     : ");



                //table1.SpacingBefore = 10f;
             
                //table3.SpacingBefore = 10f;
                table8.SpacingBefore = 12.5f;
                table8.SpacingAfter = 12.5f;

                table.AddCell(cell);
                document.Add(table3);
                document.Add(table7);
              
                document.Add(table1);
                document.Add(table);
                document.Add(table8);
               
                document.Close();
               


            }
            byte[] file = ms.ToArray();
            var output = new MemoryStream();
            output.Write(file, 0, file.Length);
            output.Position = 0;
            var f = new FileStreamResult(output, "application/pdf");          
            return f;
        }
        private SIContext db = new SIContext();
		
		
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
		 
    }
}

