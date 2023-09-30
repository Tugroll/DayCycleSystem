using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DateTime
{
    //Fields
    #region 
    public Days Day;
    public int Date;
 
    public int Hour;
    public int Minutes;
    public Season Season;
    public int Year;
    public int TotalNumDays;
    public int TotalNumWeeks;

    #endregion

    //Constructors
    #region
    public DateTime(int date, int season, int year,  int hour, int minutes)
    {
        this.Day = (Days)(date % 7);
        if (Day == 0) Day = (Days)7;
        this.Date = date;
        this.Season = (Season)season;
        this.Year = year;
        this.Hour = hour;
        this.Minutes = minutes;
       

        TotalNumDays = date + (28 * (int)this.Season);
        TotalNumDays = TotalNumDays + (112 * (year - 1));

        TotalNumWeeks = 1 + TotalNumDays / 7;
      


    }
    #endregion

    //TimeAdvancment
    #region
    public void AdvanceMinutes(int secondsToAdnvaceBy)
    {
        if (Minutes + secondsToAdnvaceBy >= 60)
        {
            Minutes = (Minutes + secondsToAdnvaceBy) % 60;
            AdvanceHour();
        }
        else
        {
            Minutes += secondsToAdnvaceBy;
        }
    }
    private void AdvanceHour()
    {
        if ((Hour + 1) == 24)
        {
            Hour = 0;
            ClockManager.CanEndTheDay = true;

        }
        else
        {
            Hour++;
        }
    }


    public void AdvanceSeason()
    {
        if (Season == Season.Winter)
        {
            Season = Season.Spring;
            AdvanceYear();

        }
        else Season++;

    }
    private void AdvanceYear()
    {
        Date = 1;

        Year++;

    }
    #endregion

    //BoolChecks
    #region
    public bool IsNight()
    {
        return Hour > 18 || Hour < 6;
    }
    public bool IsDay()
    {
        return Hour < 24 || Hour > 6;
    }
    public bool IsParticularDay(Days day)
    {
        return Day == day;
    }


    #endregion

    //KeyDates
    #region
    public DateTime NewYearsDay(int year)
    {
        if (year == 0) year = 1;
        return new DateTime(1, 0, year, 6, 0);
    }
    public DateTime TaxesTime(int year)
    {
        if (year == 0) year = 1;
        return new DateTime(28, 2, year, 6, 0);
    }

    #endregion

    //Start Of Seasons
    #region
    public DateTime StartOfSeason(Season seasons, int year)
    {
        return new DateTime(Date, (int)seasons - 1, year, Hour, Minutes * 10); ;
    }
    public DateTime StartOfWinter(int year)
    {
        return StartOfSeason(Season.Winter, year);
    }
    public DateTime StartOfSummer(int year)
    {
        return StartOfSeason(Season.Summer, year);
    }
    public DateTime StartOfAutumn(int year)
    {
        return StartOfSeason(Season.Autumn, year);
    }
    public DateTime StartOfSpring(int year)
    {
        return StartOfSeason(Season.Spring, year);
    }
    #endregion

    //time to string
    #region

    public override string ToString()
    {
        return $"Date: {DateToString()}  Season: {Season.ToString()} Time: {TimeToString()}" +
            $"\nTotal Days: {TotalNumDays}";
    }
    public string TotalDaysToString()
    {
        return $"{TotalNumDays}";
    }
    public string TotalWeeksToString()
    {
        return $"{ TotalNumWeeks}";
    }
    public string DateToString()
    {
    //Month: { (Months)month}
    //    { Date}
    //    Total Weeks: { TotalNumWeeks.ToString()}
        return $"{Day}";
    }
  
    public string TimeToString()
    {
        int adjustedHour = 0;
        if (Hour == 0)
        {
            adjustedHour = 12;
        }
        else if (Hour >= 13)
        {
            adjustedHour = Hour - 12;
        }
        else
        {
            adjustedHour = Hour;
        }
        string AmPm = Hour == 0 || Hour < 12 ? "AM" : "PM";

        return $"{adjustedHour.ToString()} : {Minutes.ToString()} {AmPm}";
    }
    #endregion
}
