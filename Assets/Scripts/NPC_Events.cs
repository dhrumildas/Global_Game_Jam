using System;

public class NPC_Events
{
    public static event Action<NPC> OnNPCClicked;
    public static event Action<NPC> OnNPCReachedExit;
    public static event Action OnTotalClicks;
    public static event Action OnLevelFailed;
    public static event Action OnLevelComplete;
    public static event Action<bool> OnGamePaused;

    public static void RaiseNpcClicked(NPC npc) => OnNPCClicked?.Invoke(npc);
    public static void RaiseNpcReachedExit(NPC npc) => OnNPCReachedExit?.Invoke(npc);
    public static void RaiseTotalClicks() => OnTotalClicks?.Invoke();
    public static void RaiseLevelFailed() => OnLevelFailed?.Invoke();
    public static void RaiseLevelComplete() => OnLevelComplete?.Invoke();
    public static void RaiseGamePaused(bool isPaused) => OnGamePaused?.Invoke(isPaused);
}
