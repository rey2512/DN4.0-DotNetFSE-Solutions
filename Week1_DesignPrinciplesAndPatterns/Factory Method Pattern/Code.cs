using System;

namespace DocumentManagementSystem
{
    
    public interface IDocument
    {
        void Open();
        void Save();
    }

  
    public class WordDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening Word document (.docx)");
        public void Save() => Console.WriteLine("Saving Word document (.docx)");
    }

    public class PdfDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening PDF document (.pdf)");
        public void Save() => Console.WriteLine("Saving PDF document (.pdf)");
    }

    public class ExcelDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening Excel spreadsheet (.xlsx)");
        public void Save() => Console.WriteLine("Saving Excel spreadsheet (.xlsx)");
    }

    
    public abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();
        
       
        public void ProcessDocument()
        {
            var doc = CreateDocument();
            doc.Open();
            doc.Save();
        }
    }

   
    public class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new WordDocument();
    }

    public class PdfDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new PdfDocument();
    }

    public class ExcelDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new ExcelDocument();
    }

    // Step 5: Testing
    class Program
    {
        static void Main()
        {
            Console.WriteLine("📄 Document Management System");
            Console.WriteLine("---------------------------");
            
            DocumentFactory factory;
            
            
            factory = new WordDocumentFactory();
            Console.WriteLine("\nCreating Word Document:");
            factory.ProcessDocument();
            
           
            factory = new PdfDocumentFactory();
            Console.WriteLine("\nCreating PDF Document:");
            factory.ProcessDocument();
            
            
            factory = new ExcelDocumentFactory();
            Console.WriteLine("\nCreating Excel Document:");
            factory.ProcessDocument();
        }
    }
}