using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lab1.Tests
{
    [TestClass]
    public class ReportTests
    {
        // Тест1 - проверяет, что конструктор правильно сохраняет название отчёта
        [TestMethod]
        public void Constructor_WhenTitleIsNotEmpty_SetsTitle()
        {
            // Arrange
            string title = "Отчёт о продажах";
            string content = "Содержание";
            DateTime date = DateTime.Now;
            // Act
            var report = new Report(title, content, date);
            // Assert
            Assert.AreEqual(title, report.Title);
        }
        // Тест2 - проверяет, что дата создания отчёта правильно сохраняется в свойстве CreationDate
        [TestMethod]
        public void Constructor_WhenDateIsValid_SetsDate()
        {
            // Arrange
            DateTime expectedDate = new DateTime(2026, 04, 13);
            // Act
            var report = new Report("Название", "Содержание", expectedDate);
            // Assert
            Assert.AreEqual(expectedDate, report.CreationDate);
        }
        // Тест3 - проверяет, что конструктор правильно сохраняет содержание отчёта
        [TestMethod]
        public void Constructor_WhenContentIsNotEmpty_SetsContent()
        {
            // Arrange
            string title = "Название";
            string content = "Текст отчёта";
            DateTime date = DateTime.Now;
            // Act
            var report = new Report(title, content, date);
            // Assert
            Assert.AreEqual(content, report.Content);
        }
        // Тест4 - проверяет, что можно создать отчёт с пустым названием
        [TestMethod]
        public void Constructor_WhenTitleIsEmpty_SetsEmptyTitle()
        {
            // Arrange
            var emptyTitle = "";
            var content = "Содержание";
            var date = DateTime.Now;
            // Act
            var report = new Report(emptyTitle, content, date);
            // Assert
            Assert.AreEqual("", report.Title);
        }

        // Тест5 - проверяет, что можно создать отчёт с пустым содержанием
        [TestMethod]
        public void Constructor_WhenContentIsEmpty_SetsEmptyContent()
        {
            // Arrange
            var title = "Название";
            var emptyContent = "";
            var date = DateTime.Now;
            // Act
            var report = new Report(title, emptyContent, date);
            // Assert
            Assert.AreEqual("", report.Content);
        }
        // Тест6 - проверяет, что свойство Title можно изменить после создания отчёта
        [TestMethod]
        public void Title_SetNewValue_UpdatesTitle()
        {
            // Arrange
            var report = new Report("Старое название", "Содержание", DateTime.Now);
            string newTitle = "Новое название";
            // Act
            report.Title = newTitle;
            // Assert
            Assert.AreEqual(newTitle, report.Title);
        }
        // Тест7 - проверяет, что свойство Content можно изменить после создания отчёта
        [TestMethod]
        public void Content_SetNewValue_UpdatesContent()
        {
            // Arrange
            var report = new Report("Название", "Старое содержание", DateTime.Now);
            string newContent = "Новое содержание";
            // Act
            report.Content = newContent;
            // Assert
            Assert.AreEqual(newContent, report.Content);
        }
        // Тест8 - проверяет, что два отчёта с одинаковыми данными - это разные объекты в памяти
        [TestMethod]
        public void TwoReportsWithSameData_AreDifferentObjects()
        {
            // Arrange
            string title = "Одинаковый отчёт";
            string content = "Одинаковое содержание";
            DateTime date = DateTime.Now;
            // Act
            var report1 = new Report(title, content, date);
            var report2 = new Report(title, content, date);
            // Assert
            Assert.AreNotSame(report1, report2);
            Assert.AreEqual(report1.Title, report2.Title);
        }
        // Тест9 - проверяет, что можно изменить дату создания отчёта
        [TestMethod]
        public void CreationDate_CanBeChanged()
        {
            // Arrange
            var report = new Report("Название", "Содержание", DateTime.Now);
            DateTime newDate = new DateTime(2025, 01, 01);
            // Act
            report.CreationDate = newDate;
            // Assert
            Assert.AreEqual(newDate, report.CreationDate);
        }
    }
}