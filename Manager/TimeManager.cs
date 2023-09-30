using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TimeData timeData;
    private DateTime dateTime;
    public GameObject EndDayPanel;
    public static UnityAction<DateTime> OnDateTimeChanged;


    private void Awake()
    {
        dateTime = new DateTime(timeData.dateInMonth, timeData.season - 1, timeData.year, timeData.hour, timeData.minutes * 10);

        OnDateTimeChanged?.Invoke(dateTime);
    }

    private void Update()
    {
        timeData.currentTimeBetweenTicks += Time.deltaTime * 5;
        if (timeData.currentTimeBetweenTicks > timeData.timeBetweenTicks && ClockManager.CanEndTheDay == false)
        {
            timeData.currentTimeBetweenTicks = 0;

            AdvanceTime();
        }
    }

   
    void AdvanceTime()
    {

        dateTime.AdvanceMinutes(timeData.tickSecondIncrease);

        OnDateTimeChanged?.Invoke(dateTime);
    }

    public void EndTheDay()
    {
        EndDayPanel.SetActive(true);
    }
    public void AdvancedDay()
    {

        if (ClockManager.CanEndTheDay == true)
        {
            if (dateTime.Day + 1 > (Days)7)
            {
                dateTime.Day = (Days)1;
                dateTime.TotalNumWeeks++;


            }
            
            else
            {
                dateTime.Day++;
            }
           
            dateTime.Date++;

            if (dateTime.Date % 29 == 0)
            {
                dateTime.AdvanceSeason();
                dateTime.Date = 1;
            }
            dateTime.TotalNumDays++;
            ClockManager.CanEndTheDay = false;
            EndDayPanel.SetActive(false);
           
        }

    }


}





