using System;
using System.Collections.ObjectModel;
using Utils.VisibilityEffectOnScrollDeterminator;
using Moq;
using NUnit.Framework;
using Xamarin.Forms;
using Determinator = Utils.VisibilityEffectOnScrollDeterminator.VisibilityEffectOnScrollDeterminator;

namespace UnitTest.Utils.VisibilityEffectOnScrollDeterminator
{
    [TestFixture]
    public class VisibilityEffectOnScrollDeterminatorTests
    {
        [Test]
        public void Determine_PassNullAsItemsViewScrolledEventArgs_ThrowsArgumentNullException()
        {
            // Arrange
            ItemsViewScrolledEventArgs eventArgs = null;
            var dataSource = new Collection<object>() { new object(), new object(), };

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => Determinator.Determine(eventArgs, dataSource, It.IsAny<bool>(), It.IsAny<string>()));
        }

        [Test]
        public void Determine_PassNullAsDataSourceCollection_ThrowsArgumentNullException()
        {
            // Arrange
            var eventArgs = new ItemsViewScrolledEventArgs();
            Collection<object> dataSource = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => Determinator.Determine(eventArgs, dataSource, It.IsAny<bool>(), It.IsAny<string>()));
        }

        [Test]
        public void Determine_VerticalDeltaIsLessThanZeroAndIsVisibleIsTrue_ReturnsVisibilityEffectNone()
        {
            // Arrange
            var eventArgs = new ItemsViewScrolledEventArgs
            {
                VerticalDelta = -1,
                LastVisibleItemIndex = 1,
            };
            var dataSource = new Collection<object>() { new object(), new object(), new object(), };
            var isVisible = true;
            var text = string.Empty;

            var expected = VisibilityEffect.None;

            // Act
            var actual = Determinator.Determine(eventArgs, dataSource, isVisible, text);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Determine_VerticalDeltaIsLessThanZeroAndTextIsFilled_ReturnsVisibilityEffectNone()
        {
            // Arrange
            var eventArgs = new ItemsViewScrolledEventArgs
            {
                VerticalDelta = -1,
                LastVisibleItemIndex = 1,
            };
            var dataSource = new Collection<object>() { new object(), new object(), new object(), };
            var isVisible = false;
            var text = "not null and not empty";

            var expected = VisibilityEffect.None;

            // Act
            var actual = Determinator.Determine(eventArgs, dataSource, isVisible, text);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Determine_VerticalDeltaIsLessThanZeroAndLastVisibleItemIndexIsBiggerThanLastIndexInDataSource_ReturnsVisibilityEffectNone()
        {
            // Arrange
            var eventArgs = new ItemsViewScrolledEventArgs
            {
                VerticalDelta = -1,
                LastVisibleItemIndex = 3,
            };
            var dataSource = new Collection<object>() { new object(), new object(), new object(), };
            var isVisible = false;
            var text = string.Empty;

            var expected = VisibilityEffect.None;

            // Act
            var actual = Determinator.Determine(eventArgs, dataSource, isVisible, text);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Determine_VerticalDeltaIsLessThanZeroAndLastVisibleItemIndexIsEqualToLastIndexInDataSource_ReturnsVisibilityEffectNone()
        {
            // Arrange
            var eventArgs = new ItemsViewScrolledEventArgs
            {
                VerticalDelta = -1,
                LastVisibleItemIndex = 2,
            };
            var dataSource = new Collection<object>() { new object(), new object(), new object(), };
            var isVisible = false;
            var text = string.Empty;

            var expected = VisibilityEffect.None;

            // Act
            var actual = Determinator.Determine(eventArgs, dataSource, isVisible, text);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Determine_VerticalDeltaIsLessThanZeroAllOtherConditionsFit_ReturnsVisibilityEffectShow()
        {
            // Arrange
            var eventArgs = new ItemsViewScrolledEventArgs
            {
                VerticalDelta = -1,
                LastVisibleItemIndex = 1,
            };
            var dataSource = new Collection<object>() { new object(), new object(), new object(), };
            var isVisible = false;
            var text = string.Empty;

            var expected = VisibilityEffect.Show;

            // Act
            var actual = Determinator.Determine(eventArgs, dataSource, isVisible, text);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Determine_VerticalDeltaIsBiggerThanZeroAndIsVisibleIsFalse_ReturnsVisibilityEffectNone()
        {
            // Arrange
            var eventArgs = new ItemsViewScrolledEventArgs
            {
                VerticalDelta = 1,
                FirstVisibleItemIndex = 1,
            };
            var dataSource = new Collection<object>() { new object(), new object(), new object(), };
            var isVisible = false;
            var text = string.Empty;

            var expected = VisibilityEffect.None;

            // Act
            var actual = Determinator.Determine(eventArgs, dataSource, isVisible, text);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Determine_VerticalDeltaIsBiggerThanZeroAndTextIsFilled_ReturnsVisibilityEffectNone()
        {
            // Arrange
            var eventArgs = new ItemsViewScrolledEventArgs
            {
                VerticalDelta = 1,
                FirstVisibleItemIndex = 1,
            };
            var dataSource = new Collection<object>() { new object(), new object(), new object(), };
            var isVisible = true;
            var text = "not null and not empty";

            var expected = VisibilityEffect.None;

            // Act
            var actual = Determinator.Determine(eventArgs, dataSource, isVisible, text);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Determine_VerticalDeltaIsBiggerThanZeroAndFirstVisibleItemIndexIsZero_ReturnsVisibilityEffectNone()
        {
            // Arrange
            var eventArgs = new ItemsViewScrolledEventArgs
            {
                VerticalDelta = 1,
                FirstVisibleItemIndex = 0,
            };
            var dataSource = new Collection<object>() { new object(), new object(), new object(), };
            var isVisible = true;
            var text = string.Empty;

            var expected = VisibilityEffect.None;

            // Act
            var actual = Determinator.Determine(eventArgs, dataSource, isVisible, text);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Determine_VerticalDeltaIsBiggerThanZeroAllOtherConditionsFit_ReturnsVisibilityEffectHide()
        {
            // Arrange
            var eventArgs = new ItemsViewScrolledEventArgs
            {
                VerticalDelta = 1,
                FirstVisibleItemIndex = 1,
            };
            var dataSource = new Collection<object>() { new object(), new object(), new object(), };
            var isVisible = true;
            var text = string.Empty;

            var expected = VisibilityEffect.Hide;

            // Act
            var actual = Determinator.Determine(eventArgs, dataSource, isVisible, text);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Determine_VerticalDeltaIsZero_ReturnsVisibilityEffectNone()
        {
            // Arrange
            var eventArgs = new ItemsViewScrolledEventArgs
            {
                VerticalDelta = 0,
            };
            var dataSource = new Collection<object>();

            var expected = VisibilityEffect.None;

            // Act
            var actual = Determinator.Determine(eventArgs, dataSource, It.IsAny<bool>(), It.IsAny<string>());

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
