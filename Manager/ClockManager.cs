using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;


public class ClockManager : MonoBehaviour
{
    public TextMeshProUGUI Date, Time, season, months, totalDays, TotalWeeks;

    public static bool CanEndTheDay = false;
    public Light2D light;
    private void OnEnable()
    {
        TimeManager.OnDateTimeChanged += UpdateDateTime;
       
    }
    private void OnDisable()
    {
        TimeManager.OnDateTimeChanged -= UpdateDateTime;
    }

    private void UpdateDateTime(DateTime dateTime)
    {
        if (CanEndTheDay == false)
        {
            if (dateTime.Hour < 12)
                light.intensity += Mathf.InverseLerp(dateTime.Minutes, 0, 1) / 100;
            else
                light.intensity -= Mathf.InverseLerp(dateTime.Minutes, 0, 1) / 100;
        }

        //Date.text = dateTime.DateToString();
        Time.text = dateTime.TimeToString();

        DayAndSeasonLocalization.SeasonLocalization(dateTime, this);
        DayAndSeasonLocalization.DayLocalization(dateTime, this);
        totalDays.text = dateTime.TotalDaysToString();
        TotalWeeks.text = dateTime.TotalWeeksToString();
        






    }
}
