using System;

public class NPC_Events
{
    public static event Action<NPC> OnNPCClicked;
    public static event Action<NPC> OnNPCReachedExit;
    public static event Action OnTotalClicks;

    public static void RaiseNpcClicked(NPC npc) => OnNPCClicked?.Invoke(npc);
    public static void RaiseNpcReachedExit(NPC npc) => OnNPCReachedExit?.Invoke(npc);
    public static void RaiseTotalClicks() => OnTotalClicks?.Invoke();
}
