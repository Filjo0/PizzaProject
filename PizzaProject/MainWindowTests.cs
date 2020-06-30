using NUnit.Framework;
using PizzaProject;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PizzaProject
{
    [TestFixture]
    public class MainWindowTests
    {
        [Test]
        public void FillMenu_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainWindow = new MainWindow();

            // Act
            mainWindow.FillMenu();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void AddItem_Click_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainWindow = new MainWindow();
            object sender = null;
            RoutedEventArgs e = null;

            // Act
            mainWindow.AddItem_Click(
                sender,
                e);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void foodItem_SelectionChanged_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainWindow = new MainWindow();
            object sender = null;
            SelectionChangedEventArgs e = null;

            // Act
            mainWindow.foodItem_SelectionChanged(
                sender,
                e);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void DeleteItem_Click_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainWindow = new MainWindow();
            object sender = null;
            RoutedEventArgs e = null;

            // Act
            mainWindow.DeleteItem_Click(
                sender,
                e);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void PlaceOrder_Click_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainWindow = new MainWindow();
            object sender = null;
            RoutedEventArgs e = null;

            // Act
            mainWindow.PlaceOrder_Click(
                sender,
                e);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void nextItemsCombo_SelectionChanged_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainWindow = new MainWindow();
            object sender = null;
            SelectionChangedEventArgs e = null;

            // Act
            mainWindow.nextItemsCombo_SelectionChanged(
                sender,
                e);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void QuantityBox_TextChanged_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainWindow = new MainWindow();
            object sender = null;
            TextChangedEventArgs e = null;

            // Act
            mainWindow.QuantityBox_TextChanged(
                sender,
                e);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void TextBox_TextChanged_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainWindow = new MainWindow();
            object sender = null;
            TextChangedEventArgs e = null;

            // Act
            mainWindow.TextBox_TextChanged(
                sender,
                e);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void PizzaSizeCombo_SelectionChanged_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainWindow = new MainWindow();
            object sender = null;
            SelectionChangedEventArgs e = null;

            // Act
            mainWindow.PizzaSizeCombo_SelectionChanged(
                sender,
                e);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void PizzaCrustCombo_SelectionChanged_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainWindow = new MainWindow();
            object sender = null;
            SelectionChangedEventArgs e = null;

            // Act
            mainWindow.PizzaCrustCombo_SelectionChanged(
                sender,
                e);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void AddButtonIsEnabled_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainWindow = new MainWindow();

            // Act
            mainWindow.AddButtonIsEnabled();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void TakeAwayButton_Checked_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainWindow = new MainWindow();
            object sender = null;
            RoutedEventArgs e = null;

            // Act
            mainWindow.TakeAwayButton_Checked(
                sender,
                e);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void DeliverButton_Checked_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainWindow = new MainWindow();
            object sender = null;
            RoutedEventArgs e = null;

            // Act
            mainWindow.DeliverButton_Checked(
                sender,
                e);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void ConfrimOrder_Click_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainWindow = new MainWindow();
            object sender = null;
            RoutedEventArgs e = null;

            // Act
            mainWindow.ConfrimOrder_Click(
                sender,
                e);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void Button_Click_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainWindow = new MainWindow();
            object sender = null;
            RoutedEventArgs e = null;

            // Act
            mainWindow.Button_Click(
                sender,
                e);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void GenerateButton_Click_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainWindow = new MainWindow();
            object sender = null;
            RoutedEventArgs e = null;

            // Act
            mainWindow.GenerateButton_Click(
                sender,
                e);

            // Assert
            Assert.Fail();
        }
    }
}
