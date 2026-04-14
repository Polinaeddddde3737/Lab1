using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Lab1.Tests
{
    [TestClass]
    public class ReportManagerTests
    {
        private ReportManager reportManager;
        private const string TestFile = "reports.txt";
        // dыполняется перед каждым тестом, создает чистый экземпляр
        [TestInitialize]
        public void Setup()
        {
            if (File.Exists(TestFile))
                File.Delete(TestFile);
            reportManager = new ReportManager();
        }
        // выполняется после каждого теста, очищает временные файлы
        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(TestFile))
                File.Delete(TestFile);
        }
        // Тест1 - проверяет, что можно добавить несколько отчётов подряд
        [TestMethod]
        public void AddReport_MultipleReports_AddsAllReports()
        {
            // Arrange
            var report1 = new Report("Отчёт 1", "Содержание 1", DateTime.Now);
            var report2 = new Report("Отчёт 2", "Содержание 2", DateTime.Now);
            // Act
            reportManager.AddReport(report1);
            reportManager.AddReport(report2);
            // Assert
            Assert.AreEqual(2, reportManager.Reports.Count);
        }
        // Тест2 - проверяет, что при удалении существующего отчёта он исчезает из списка
        [TestMethod]
        public void RemoveReport_WhenReportExists_RemovesReport()
        {
            // Arrange
            var report = new Report("Удаляемый отчёт", "Содержание", DateTime.Now);
            reportManager.AddReport(report);
            // Act
            reportManager.RemoveReport(report);
            // Assert
            Assert.AreEqual(0, reportManager.Reports.Count);
        }

        // Тест3 - проверяет, что при обновлении существующего отчёта его данные меняются
        [TestMethod]
        public void UpdateReport_WhenReportExists_UpdatesTitleAndContent()
        {
            // Arrange
            var report = new Report("Старый отчёт", "Старое содержание", DateTime.Now);
            reportManager.AddReport(report);
            // Act
            reportManager.UpdateReport(report, "Новый отчёт", "Новое содержание");
            // Assert
            Assert.AreEqual("Новый отчёт", report.Title);
            Assert.AreEqual("Новое содержание", report.Content);
        }
        // Тест4 - проверяет, что при удалении несуществующего отчёта ничего не происходит
        [TestMethod]
        public void RemoveReport_WhenReportDoesNotExist_DoesNothing()
        {
            // Arrange
            var report = new Report("Несуществующий отчёт", "Содержание", DateTime.Now);
            int initialCount = reportManager.Reports.Count;
            // Act
            reportManager.RemoveReport(report);
            // Assert
            Assert.AreEqual(initialCount, reportManager.Reports.Count);
        }

        // Тест5 - проверяет, что после добавления отчёта создаётся файл reports.txt
        [TestMethod]
        public void SaveReports_AfterAddingReport_CreatesFile()
        {
            // Arrange
            var report = new Report("Сохраняемый отчёт", "Содержание", DateTime.Now);
            // Act
            reportManager.AddReport(report);
            // Assert
            Assert.IsTrue(File.Exists(TestFile));
        }
        // Тест6 - проверяет, что при создании нового менеджера отчёты загружаются из файла
        [TestMethod]
        public void LoadReports_WhenFileExists_LoadsReports()
        {
            // Arrange
            var originalReport = new Report("Загружаемый отчёт", "Содержание", DateTime.Now);
            reportManager.AddReport(originalReport);
            // Act
            var newManager = new ReportManager();
            // Assert
            Assert.AreEqual(1, newManager.Reports.Count);
            Assert.AreEqual("Загружаемый отчёт", newManager.Reports[0].Title);
        }
        // Тест7 - проверяет, что при загрузке отчёты восстанавливаются из файла
        [TestMethod]
        public void LoadReports_RestoresReportsFromFile()
        {
            // Arrange
            var originalReport = new Report("Загружаемый отчёт", "Содержание", DateTime.Now);
            reportManager.AddReport(originalReport);
            // Act
            var newManager = new ReportManager();
            // Assert
            Assert.AreEqual(1, newManager.Reports.Count);
            Assert.AreEqual("Загружаемый отчёт", newManager.Reports[0].Title);
        }
        // Тест8 - проверяет, что при удалении null выбрасывается исключение
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveReport_NullReport_ThrowsException()
        {
            // Act
            reportManager.RemoveReport(null);
        }
        // Тест9 - проверяет, что при обновлении null выбрасывается исключение
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateReport_NullReport_ThrowsException()
        {
            // Act
            reportManager.UpdateReport(null, "Название", "Содержание");
        }
    }
}
