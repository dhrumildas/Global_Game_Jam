using TMPro;
using UnityEngine;

public class ScoreUIManager : MonoBehaviour
{
    [Header("TMP Text")]
    [SerializeField] private TMP_Text correctText;
    [SerializeField] private TMP_Text missText;
    [SerializeField] private TMP_Text totalClicksText;

    private int correctClicks = 0;
    private int misses = 0;
    private int totalClicks = 0;

    private void OnEnable()
    {
        NPC_Events.OnNPCClicked += HandleNpcClicked;
        NPC_Events.OnNPCReachedExit += HandleNpcReachedExit;
        NPC_Events.OnTotalClicks += HandleTotalClicks;
    }

    private void OnDisable()
    {
        NPC_Events.OnNPCClicked -= HandleNpcClicked;
        NPC_Events.OnNPCReachedExit -= HandleNpcReachedExit;
        NPC_Events.OnTotalClicks -= HandleTotalClicks;
    }

    private void Start() => RefreshUI();

    private void HandleTotalClicks()
    {
        totalClicks++;
        RefreshUI();
    }

    private void HandleNpcClicked(NPC npc)
    {
        if (npc.Type == NPC.MaskType.MaskOff)
            correctClicks++;

        RefreshUI();
    }

    private void HandleNpcReachedExit(NPC npc)
    {
        if (npc.Type == NPC.MaskType.MaskOff)
            misses++;

        RefreshUI();
    }

    private void RefreshUI()
    {
        if (correctText) correctText.text = $"Correct: {correctClicks}";
        if (missText) missText.text = $"Misses: {misses}";
        if (totalClicksText) totalClicksText.text = $"Total Clicks: {totalClicks}";
    }
}
