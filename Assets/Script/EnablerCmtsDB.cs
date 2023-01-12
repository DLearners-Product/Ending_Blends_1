using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class EnablerCmtsDB
{
    public string welcome;
    public string brain_gym_earth_buttons;
    public string introduction;
    public string phoneme_segmenting;
    public string choose_vowel_and_sort_blends;
    public string magic_show;
    public string brain_gym_hook_ups;
    public string stamp_the_ending;
    public string read_and_answer;
    public string audio_activity;
    public string goodbye_song;

    public EnablerCmtsDB()
    {
        welcome = Main_Blended.OBJ_main_blended.enablerComments[0];
        brain_gym_earth_buttons = Main_Blended.OBJ_main_blended.enablerComments[1];
        introduction = Main_Blended.OBJ_main_blended.enablerComments[2];
        phoneme_segmenting = Main_Blended.OBJ_main_blended.enablerComments[3];
        choose_vowel_and_sort_blends = Main_Blended.OBJ_main_blended.enablerComments[4];
        magic_show = Main_Blended.OBJ_main_blended.enablerComments[5];
        brain_gym_hook_ups = Main_Blended.OBJ_main_blended.enablerComments[6];
        stamp_the_ending = Main_Blended.OBJ_main_blended.enablerComments[7];
        read_and_answer = Main_Blended.OBJ_main_blended.enablerComments[8];
        audio_activity = Main_Blended.OBJ_main_blended.enablerComments[9];
        goodbye_song = Main_Blended.OBJ_main_blended.enablerComments[10];
    }
}