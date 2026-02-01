using System;
using TMPro;
using UnityEngine;

public class SecondStageScore : MonoBehaviour
{
    [Header("TMP Text")]
    [SerializeField] private TMP_Text correctText;
    [SerializeField] private TMP_Text missText;
    [SerializeField] private TMP_Text strikesText;
    [SerializeField] private GameTimer gameTimer;

    private int correctClicks = 0;
    private int misses = 0;
    private int strikes = 0;
    private const int MaxStrikes = 3;

    private void OnEnable()
    {
        NPC_Events.OnNPCClicked += HandleNpcClicked;
        NPC_Events.OnNPCReachedExit += HandleNpcReachedExit;
    }

    private void OnDisable()
    {
        NPC_Events.OnNPCClicked -= HandleNpcClicked;
        NPC_Events.OnNPCReachedExit -= HandleNpcReachedExit;
        if (gameTimer != null)
            gameTimer.DayEnded -= CheckEndDayConditions;
    }

    private void Start()
    {
        strikes = 0;
        if (strikesText) strikesText.text = "";
        gameTimer = FindFirstObjectByType<GameTimer>();
        if (gameTimer != null)
        {
            gameTimer.DayEnded += CheckEndDayConditions;
        }
        RefreshUI();
    }

    private void CheckEndDayConditions()
    {
        float ratio = (misses == 0) ? 100f : (float)correctClicks / misses;
        float threshold = 4f / 5f;

        Debug.Log($"End of Day Check: Correct={correctClicks}, Misses={misses}, Ratio={ratio}, Threshold={threshold}");
        if(ratio <threshold)
        {
            NPC_Events.RaiseLevelFailed();
        }
        else
        {
            NPC_Events.RaiseLevelComplete();
        }
    }

    private void HandleNpcClicked(NPC npc)
    {
        if (npc.Type == NPC.MaskType.MaskOff || npc.Color == NPC.NpcColor.Red)
            correctClicks++;
        else
            AddStrike();
        RefreshUI();
    }

    private void AddStrike()
    {
        strikes++;
        if (strikesText!= null)
        {
            switch(strikes)
            {
                case 1:
                    strikesText.text = "X";
                    break;
                case 2:
                    strikesText.text = "XX";
                    break;
                case 3:
                    strikesText.text = "XXX";
                    break;
            }
        }
        if (strikes >= MaxStrikes)
        {
            NPC_Events.RaiseLevelFailed();
        }
    }

    private void HandleNpcReachedExit(NPC npc)
    {
        if (npc.Type == NPC.MaskType.MaskOff || npc.Color == NPC.NpcColor.Red)
            misses++;

        RefreshUI();
    }

    private void RefreshUI()
    {
        if (correctText) correctText.text = $"Correct: {correctClicks}";
        if (missText) missText.text = $"Misses: {misses}";
    }
}
