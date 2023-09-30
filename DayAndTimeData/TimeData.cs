using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Time/TimeData")]
public class TimeData : ScriptableObject
{
    [Header("Tick Settings")]
    public int tickSecondIncrease = 10;
    public float timeBetweenTicks = 1;
    public float currentTimeBetweenTicks = 0;

    [Header("Date & Time Settings")]
    [Range(1, 28)]
    public int dateInMonth;

    [Range(1, 4)]
    public int season;
    [Range(1, 99)]
    public int year;
    [Range(0, 23)]
    public int hour;
    [Range(0, 6)]
    public int minutes;

    

}
