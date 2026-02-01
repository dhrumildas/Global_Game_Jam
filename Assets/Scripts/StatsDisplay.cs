using UnityEngine;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
    [Header("UI Text Elements")]
    [SerializeField] private TMP_Text totalCorrectText;
    [SerializeField] private TMP_Text totalMissedText;

    private int redCorrect = 0, blueCorrect = 0;
    private int redMissed = 0, blueMissed = 0;

    private void OnEnable()
    {
        // Subscribe to NPC events to track hits and misses
        NPC_Events.OnNPCClicked += HandleNpcClicked;
        NPC_Events.OnNPCReachedExit += HandleNpcReachedExit;
    }

    private void OnDisable()
    {
        // Unsubscribe to prevent memory leaks
        NPC_Events.OnNPCClicked -= HandleNpcClicked;
        NPC_Events.OnNPCReachedExit -= HandleNpcReachedExit;
    }

    private void HandleNpcClicked(NPC npc)
    {
        // Check mask type to determine if the click was "correct"
        // Based on existing logic: MaskOff is usually the target
        if (npc.Type == NPC.MaskType.MaskOff)
        {
            if (npc.Color == NPC.NpcColor.Red) redCorrect++;
            else blueCorrect++;

            UpdateStatsUI();
        }
    }

    private void HandleNpcReachedExit(NPC npc)
    {
        // If a MaskOff NPC reaches the exit, it counts as a miss
        if (npc.Type == NPC.MaskType.MaskOff)
        {
            if (npc.Color == NPC.NpcColor.Red) redMissed++;
            else blueMissed++;

            UpdateStatsUI();
        }
    }

    private void UpdateStatsUI()
    {
        if (totalCorrectText != null)
        {
            totalCorrectText.text = $"Correct: {redCorrect + blueCorrect} (R:{redCorrect} B:{blueCorrect})";
        }

        if (totalMissedText != null)
        {
            totalMissedText.text = $"Missed: {redMissed + blueMissed} (R:{redMissed} B:{blueMissed})";
        }
    }
}