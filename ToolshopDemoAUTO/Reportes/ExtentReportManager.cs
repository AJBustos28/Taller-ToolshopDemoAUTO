using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.IO;

namespace ToolshopDemoAUTO.Reportes
{
    public static class ExtentReportManager
    {
        private static ExtentReports extent;
        private static ExtentTest test;

        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {

                string reportRoot = Path.Combine(
                    Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName,
                    "Reportes"
                );

                Directory.CreateDirectory(reportRoot);

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string reportPath = Path.Combine(reportRoot, $"Reporte_{timestamp}.html");


                var spark = new ExtentSparkReporter(reportPath);
                spark.Config.DocumentTitle = "Automation Report";
                spark.Config.ReportName = "Resultados de pruebas";

                extent = new ExtentReports();
                extent.AttachReporter(spark);
            }

            return extent;
        }

        public static ExtentTest CreateTest(string testName)
        {
            test = GetInstance().CreateTest(testName);
            return test;
        }

        public static void LogInfo(string mensaje) => test.Info(mensaje);

        public static void LogPass(string mensaje) => test.Pass(mensaje);

        public static void LogFail(string mensaje) => test.Fail(mensaje);

        public static void LogScreenshot(IWebDriver driver, string mensaje = "Screenshot")
        {
            string carpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "screenshots");
            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            string nombreArchivo = $"SS_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            string rutaCompleta = Path.Combine(carpeta, nombreArchivo);

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(rutaCompleta);

            test.Info(mensaje, MediaEntityBuilder.CreateScreenCaptureFromPath(rutaCompleta).Build());
        }

        public static void Flush()
        {
            extent.Flush();
        }
    }
}