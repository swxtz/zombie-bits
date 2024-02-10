using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;
using System;
using UnityEngine.SocialPlatforms;

public class DiscordManager : MonoBehaviour
{

    private long clientID = 1205719722658889838;
    public Discord.Discord discord;

    private void Start()
    {
        discord = new Discord.Discord(clientID, (UInt64)CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Activity
        {
            State = "No Menu",
            Timestamps =
            {
                Start = ((long)Time.time)
            },
            Assets =
            {
                LargeImage = "https://imgs.search.brave.com/foi_u-hd6oDEMu0gEqwMPj3bv9CT3kBM9LZaMugesvo/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9icmFu/ZHNsb2dvcy5jb20v/d3AtY29udGVudC91/cGxvYWRzL2ltYWdl/cy91bml0eS1sb2dv/LnBuZw",
                SmallImage = "Rogue - Level 100",

            },


        };

        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
            {
            }
            else
            {
                Debug.LogError(res);
            }
        });
    }


    private void Update()
    {

        discord.RunCallbacks();
        
    }


}
