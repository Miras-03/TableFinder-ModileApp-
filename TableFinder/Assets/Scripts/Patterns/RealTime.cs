using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RealTime : MonoBehaviour
{
    private List<ITimeObserver> timeObservers = new List<ITimeObserver>();
    private DateTime aktobeTime;

    public DateTime AktobeTime => aktobeTime;

    private void Awake()
    {
        StartCoroutine(FetchRealTime());
    }

    private IEnumerator FetchRealTime()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://worldtimeapi.org/api/timezone/Asia/Aqtobe");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
            yield break;

        string responseText = www.downloadHandler.text;
        RealTimeData timeData = JsonUtility.FromJson<RealTimeData>(responseText);

        if (timeData != null && !string.IsNullOrEmpty(timeData.datetime))
        {
            aktobeTime = DateTime.Parse(timeData.datetime).AddHours(2);
            //Debug.Log("Current time in Aktobe: " + aktobeTime);
            NotifyTimeObservers(aktobeTime);
        }
    }

    public void SubscribeObserver(ITimeObserver observer)
    {
        if (!timeObservers.Contains(observer))
        {
            timeObservers.Add(observer);
            observer.OnTimeUpdated(aktobeTime);
        }
    }

    private void NotifyTimeObservers(DateTime newTime)
    {
        foreach (var observer in timeObservers)
            observer.OnTimeUpdated(newTime);
    }

    [Serializable]
    public class RealTimeData
    {
        public string datetime;
    }

    public interface ITimeObserver
    {
        void OnTimeUpdated(DateTime newTime);
    }
}
