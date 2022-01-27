namespace Utils.VisibilityEffectOnScrollDeterminator
{
    public enum VisibilityEffect
    {
        None,
        Show,
        Hide,
    }
}

/*
var visibilityEffect = VisibilityEffectOnScrollDeterminator.Determine(eventArgs, Issues, IsSearchEntryVisible, SearchText);
if (visibilityEffect == VisibilityEffect.Show)
{
    IsSearchEntryVisible = true; // or any animation/transition
}
else if (visibilityEffect == VisibilityEffect.Hide)
{
    IsSearchEntryVisible = false; // or any animation/transition
}

if (visibilityEffect != VisibilityEffect.None)
{
    // A delay is required:
    // - because a change of visibility causes a change of size what causes a rapid scroll in the opposite direction
    // (so, the OnScrolled event is fired and it must not be processed);
    // - for smooth non-blinking behaviour after "show"/"hide" effect is applied.
    await Task.Delay(1000);
}
*/
