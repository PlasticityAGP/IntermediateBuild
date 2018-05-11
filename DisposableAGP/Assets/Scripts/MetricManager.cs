using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

// This class encapsulates all of the metrics that need to be tracked in your game. These may range
// from number of deaths, number of times the player uses a particular mechanic, or the total time
// spent in a level. These are unique to your game and need to be tailored specifically to the data
// you would like to collect. The examples below are just meant to illustrate one way to interact
// with this script and save data.
public class MetricManager : MonoBehaviour
{
	private Dictionary<ZoneTrigger, float> timesHitZone;
	private Dictionary<ZoneTrigger, int> timesHitControl;
	private Dictionary<ZoneTrigger, int> timesHitAlt;

	private ZoneTrigger lastHitZone = null;

	private void Start()
	{
		timesHitZone = new Dictionary<ZoneTrigger, float> ();
		timesHitControl = new Dictionary<ZoneTrigger, int> ();
		timesHitAlt = new Dictionary<ZoneTrigger, int> ();
	}

	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			RegisterHitControlInZone ();
		} else if (Input.GetKeyDown (KeyCode.LeftAlt)) {
			RegisterHitAltInZone ();
		}
	}

	public void RegisterHitZone(ZoneTrigger zone, float time)
	{
		lastHitZone = zone;
		float dummyTime;
		bool haveZoneSet = timesHitZone.TryGetValue (zone, out dummyTime);
		if (haveZoneSet) {
			timesHitZone [zone] = time;
		} else {
			timesHitZone.Add (zone, time);
		}
	}

	public void RegisterHitControlInZone()
	{
		if (lastHitZone == null) {
			return;
		}
		int num;
		bool haveZoneSet = timesHitControl.TryGetValue (lastHitZone, out num);
		if (haveZoneSet) {
			timesHitControl [lastHitZone]++;
		} else {
			timesHitControl.Add (lastHitZone, 1);
		}
	}

	public void RegisterHitAltInZone()
	{
		if (lastHitZone == null) {
			return;
		}
		int num;
		bool haveZoneSet = timesHitAlt.TryGetValue (lastHitZone, out num);
		if (haveZoneSet) {
			timesHitAlt [lastHitZone]++;
		} else {
			timesHitAlt.Add (lastHitZone, 1);
		}
	}

	// Converts all metrics tracked in this script to their string representation
	// so they look correct when printing to a file.
	private string ConvertMetricsToStringRepresentation ()
	{
		string metrics = "Here are my metrics:\n Times Hit Zone\n";
		foreach (var kvp in timesHitZone) {
			metrics += "Name: " + kvp.Key.gameObject.name + ", Time: " + kvp.Value.ToString() + "\n";
		}
		metrics += "Times Hit Control\n";
		foreach (var kvp in timesHitControl) {
			metrics += "Name: " + kvp.Key.gameObject.name + ", Number of Hits: " + kvp.Value.ToString() + "\n";
		}
		metrics += "Times Hit Alt\n";
		foreach (var kvp in timesHitAlt) {
			metrics += "Name: " + kvp.Key.gameObject.name + ", Number of Hits: " + kvp.Value.ToString() + "\n";
		}
		return metrics;
	}

	// Uses the current date/time on this computer to create a uniquely named file,
	// preventing files from colliding and overwriting data.
	private string CreateUniqueFileName ()
	{
		string dateTime = System.DateTime.Now.ToString ();
		dateTime = dateTime.Replace ("/", "_");
		dateTime = dateTime.Replace (":", "_");
		dateTime = dateTime.Replace (" ", "___");
		return "YourGameName_metrics_" + dateTime + ".txt"; 
	}

	// Generate the report that will be saved out to a file.
	private void WriteMetricsToFile ()
	{
		string totalReport = "Report generated on " + System.DateTime.Now + "\n\n";
		totalReport += "Total Report:\n";
		totalReport += ConvertMetricsToStringRepresentation ();
		totalReport = totalReport.Replace ("\n", System.Environment.NewLine);
		string reportFile = CreateUniqueFileName ();

		#if !UNITY_WEBPLAYER 
		File.WriteAllText (reportFile, totalReport);
		#endif
	}

	// The OnApplicationQuit function is a Unity-Specific function that gets
	// called right before your application actually exits. You can use this
	// to save information for the next time the game starts, or in our case
	// write the metrics out to a file.
	private void OnApplicationQuit ()
	{
		WriteMetricsToFile ();
	}
}
