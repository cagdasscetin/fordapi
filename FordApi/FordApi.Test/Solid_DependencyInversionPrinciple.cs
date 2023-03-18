using NUnit.Framework;
using System;

namespace FordApi.Test;

//Dependency Injection, Inversion of Control adını verdiğimiz uygulama akışını değiştirme yönteminin özelleşmiş bir halidir.
//Dependency Injection ile uygulamanın çalışacağı ve bağımlı olduğu akışları dışarıdan enjekte ederek uygulama akışını dinamik olarak değiştirebiliyoruz.
//Böylece uygulamamızın genişletilebilmesi ileri zamanlarda gelebilecek olan yeni geliştirmelerde uygulamamızın en az oranda
//etkilenmesini mümkün kılabilmekteyiz.

public class Solid_DependencyInjectionPrinciple_Old
{
    class DBLogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(String.Format("DBLogger : {0}", message));
        }
    }
    class FileLogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(String.Format("FileLogger : {0}", message));
        }
    }
    class MailSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(String.Format("MailSender : {0}", message));
        }
    }   
    class SMSSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(String.Format("SMSSender : {0}", message));
        }
    }
    class OldProcessor
    {
        public void Process1()
        {
            //DBLogger logger = new DBLogger();                   
            FileLogger logger = new FileLogger();
            logger.WriteLog("Log Text");
            //Ana Uygulama Akışı          
            //MailSender messageSender = new MailSender();
            SMSSender messageSender = new SMSSender();
            messageSender.SendMessage("Message Text");
        }
        public void Process2()
        {
            DBLogger logger = new DBLogger();
            logger.WriteLog("Log Text");
            //Ana Uygulama Akışı          
            MailSender messageSender = new MailSender();
            messageSender.SendMessage("Message Text");
        }
    }
    static void Main(string[] args)
    {
        OldProcessor processor = new OldProcessor();
        processor.Process1();
    }
}




public class Solid_DependencyInversionPrinciple
{
    interface IMessageSender
    {
        void SendMessage(string Message);
    }
    interface ILogger
    {
        void WriteLog(string message);
    }
    class SqlDbLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(String.Format("SqlDbLogger : {0}", message));
        }
    }
    class PdfFileLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(String.Format("PdfFileLogger : {0}", message));
        }
    }
    class SmtpMailSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(String.Format("SmtpMailSender : {0}", message));
        }
    }
    
    class TwillioSMSSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(String.Format("SMSSender : {0}", message));
        }
    }
    class Processor3
    {
        ILogger logger = null;
        IMessageSender messageSender;
        public Processor3(ILogger _logger, IMessageSender _messageSender)
        {
            logger = _logger;
            messageSender = _messageSender;
        }
        public void Process()
        {
            logger.WriteLog("Log Text");
            //Ana Uygulama Akışı                     
            messageSender.SendMessage("Message Text");
        }
    }
    public class DependencyInjectionTest
    {

        [Test]
        public void Test3()
        {
            IMessageSender msgsender1 = new TwillioSMSSender();
            ILogger logr2 = new SqlDbLogger();
            Processor3 processor = new Processor3(logr2, msgsender1);
            processor.Process();
        }
    }
}
