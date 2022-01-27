using System.Collections.ObjectModel;
using Coins.Common;
using Xamarin.Forms;

namespace Coins.IssueManagementForContract.Common.Utils.VisibilityEffectOnScrollDeterminator
{
    public static class VisibilityEffectOnScrollDeterminator
    {
        /// <summary>
        /// Determines a visibility effect on a scroll of a collection.
        /// </summary>
        /// <typeparam name="T">Type of an item of a collection.</typeparam>
        /// <param name="eventArgs">Event arguments of a scroll event (e.g. OnScrolled).</param>
        /// <param name="dataSource">Data source of a collection on what a scroll occured.</param>
        /// <param name="isVisible">Starting state of visibility.</param>
        /// <param name="text">Text for additional condition.</param>
        /// <returns>Returns a visibility effect that should be applied.</returns>
        public static VisibilityEffect Determine<T>(
            ItemsViewScrolledEventArgs eventArgs,
            Collection<T> dataSource,
            bool isVisible,
            string text)
        {
            eventArgs.ThrowIfArgumentNull(nameof(eventArgs));
            dataSource.ThrowIfArgumentNull(nameof(dataSource));

            var effect = VisibilityEffect.None;

            // Scrolling upwards as the value is negative.
            if (eventArgs.VerticalDelta < 0)
            {
                effect = OnScrolledUpwards(eventArgs, dataSource, isVisible, text);
            }

            // Scrolling downwards as the value is positive.
            else if (eventArgs.VerticalDelta > 0)
            {
                effect = OnScrolledDownwards(eventArgs, isVisible, text);
            }

            return effect;
        }

        private static VisibilityEffect OnScrolledUpwards<T>(
            ItemsViewScrolledEventArgs eventArgs,
            Collection<T> dataSource,
            bool isVisible,
            string text)
        {
            if (isVisible || !string.IsNullOrEmpty(text))
            {
                return VisibilityEffect.None;
            }

            // Verifying that the OnScrolled event is not fired by iOS bounce back behaviour at the bottom.
            if (dataSource.Count - 1 <= eventArgs.LastVisibleItemIndex)
            {
                return VisibilityEffect.None;
            }

            return VisibilityEffect.Show;
        }

        private static VisibilityEffect OnScrolledDownwards(
            ItemsViewScrolledEventArgs eventArgs,
            bool isVisible,
            string text)
        {
            if (!isVisible || !string.IsNullOrEmpty(text))
            {
                return VisibilityEffect.None;
            }

            // Verifying that the OnScrolled event is not fired by iOS bounce back behaviour at the top.
            if (eventArgs.FirstVisibleItemIndex == 0)
            {
                return VisibilityEffect.None;
            }

            return VisibilityEffect.Hide;
        }
    }
}