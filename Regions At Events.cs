/**
* Program: RegionsAtEvents.cs
* Author: John Rofrano
* Purpose: This script will place a region at each event on the selected track(s)
* Copyright: (c) 2010, Sundance Media Group / VASST
* Updated: February 27, 2010
**/
using System;
using System.Windows.Forms;
using ScriptPortal.Vegas;

class EntryPoint
{
public void FromVegas(Vegas vegas)
{
foreach (Track track in vegas.Project.Tracks)
{
// only process selected tracks
if (!track.Selected) continue;

foreach (TrackEvent trackEvent in track.Events)
{
Region region = new Region(trackEvent.Start, trackEvent.Length, trackEvent.ActiveTake.Name);
try
{
vegas.Project.Regions.Add(region);
}
catch (Exception e)
{
MessageBox.Show(String.Format("Could not place a region at {0}\nError message is: {1}", trackEvent.Start.ToString(), e.Message), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}
}
}
}
}