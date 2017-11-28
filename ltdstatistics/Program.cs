using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.IO.StreamWriter;

/*
todo:
game per hour
elo
most loses


*/

namespace ltdstatistics
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int meineZeile=0, zeile = 0, customgames = 0, match_level = 0, match_lvl_aktuell=0, total_games = 0, wins_west = 0, wins_east = 0, wins_ele=0, wins_mech=0, wins_grove=0, wins_forsaken=0, wins_mm=0, pick_ele = 0, pick_mech = 0, pick_forsaken = 0, pick_grove = 0, pick_mm = 0;
            int mmueber = 0;
            double matchtime=0.00, avg_matchtime = 0.00, total_matchtime=0.00;
            string mvp="", mvp2="", mvp3="", match_ergebnis = "", match_date = "", match_day = "", match_time="", tmp_str="";

            string topvalue = "0 ()", topinc= "0 ()", topelogain = "0 ()", topeloloss= "0 ()", topworkers="0 ()";

            string[] winner_names = new string[50000];
            int[] winner_wins = new int[50000];

            int[] player_elo_gain = new int[5000];
            int elo1 = 0, elo2 = 0;

            int[] level = new int[22];
            int[] grove_w = new int[22];
            int[] grove_wTotal = new int[22];
            int[] grove_wOnLvl = new int[22];
            int[] grove_v = new int[22];
            int[] grove_vTotal = new int[22];
            int[] grove_vOnLvl = new int[22];
            int[] grove_inc = new int[22];
            int[] grove_incTotal = new int[22];
            int[] grove_incOnLvl = new int[22];
            int[] grove_leak = new int[22];
            int[] grove_leakTotal = new int[22];
            int[] grove_leakOnLvl = new int[22];
            int[] grove_hold = new int[22];
            int[] grove_holdTotal = new int[22];
            int[] grove_holdOnLvl = new int[22];
            int[] mech_w = new int[22];
            int[] mech_wTotal = new int[22];
            int[] mech_wOnLvl = new int[22];
            int[] mech_v = new int[22];
            int[] mech_vTotal = new int[22];
            int[] mech_vOnLvl = new int[22];
            int[] mech_inc = new int[22];
            int[] mech_incTotal = new int[22];
            int[] mech_incOnLvl = new int[22];
            int[] mech_leak = new int[22];
            int[] mech_leakTotal = new int[22];
            int[] mech_leakOnLvl = new int[22];
            int[] mech_hold = new int[22];
            int[] mech_holdTotal = new int[22];
            int[] mech_holdOnLvl = new int[22];
            int[] ele_w = new int[22];
            int[] ele_wTotal = new int[22];
            int[] ele_wOnLvl = new int[22];
            int[] ele_v = new int[22];
            int[] ele_vTotal = new int[22];
            int[] ele_vOnLvl = new int[22];
            int[] ele_inc = new int[22];
            int[] ele_incTotal = new int[22];
            int[] ele_incOnLvl = new int[22];
            int[] ele_leak = new int[22];
            int[] ele_leakTotal = new int[22];
            int[] ele_leakOnLvl = new int[22];
            int[] ele_hold = new int[22];
            int[] ele_holdTotal = new int[22];
            int[] ele_holdOnLvl = new int[22];
            int[] forsaken_w = new int[22];
            int[] forsaken_wTotal = new int[22];
            int[] forsaken_wOnLvl = new int[22];
            int[] forsaken_v = new int[22];
            int[] forsaken_vTotal = new int[22];
            int[] forsaken_vOnLvl = new int[22];
            int[] forsaken_inc = new int[22];
            int[] forsaken_incTotal = new int[22];
            int[] forsaken_incOnLvl = new int[22];
            int[] forsaken_leak = new int[22];
            int[] forsaken_leakTotal = new int[22];
            int[] forsaken_leakOnLvl = new int[22];
            int[] forsaken_hold = new int[22];
            int[] forsaken_holdTotal = new int[22];
            int[] forsaken_holdOnLvl = new int[22];
            int[] mm_w = new int[22];
            int[] mm_wTotal = new int[22];
            int[] mm_wOnLvl = new int[22];
            int[] mm_v = new int[22];
            int[] mm_vTotal = new int[22];
            int[] mm_vOnLvl = new int[22];
            int[] mm_inc = new int[22];
            int[] mm_incTotal = new int[22];
            int[] mm_incOnLvl = new int[22];
            int[] mm_leak = new int[22];
            int[] mm_leakTotal = new int[22];
            int[] mm_leakOnLvl = new int[22];
            int[] mm_hold = new int[22];
            int[] mm_holdTotal = new int[22];
            int[] mm_holdOnLvl = new int[22];

            Boolean time = false, custom = false;
            Boolean inZeit = false;
            
            System.IO.StreamReader fileZ = new System.IO.StreamReader(@"log.txt");
            System.IO.StreamReader file = new System.IO.StreamReader(@"log.txt");
            string line, line_davor="";
            string[] allLines = new string[500000];
            int meinCounter = 0;
            string target_day = Console.ReadLine();

            while ((line = fileZ.ReadLine()) != null)
            {
                allLines[meinCounter] = line;
                meinCounter++;
            }
            
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(target_day)) inZeit = true;
                if (line.Contains("(Practice/Custom)"))
                {
                    custom = true;
                    customgames++;

                }
                else if (line.Contains("elo"))
                {
                    custom = false;
                }
                /*
                if(line.Contains("LegionTD2 - Alpha |") && custom == false && inZeit == true)
                {
                    match_date = line.Substring(24);
                    match_day = line.Substring(20, 2);
                }
                */
                
                if (line.Contains("WON") && custom == false && inZeit == true && !line_davor.Contains("`"))
                {
                    total_games++;
                    match_ergebnis = "WON";
                    wins_west += 1;
                }

                if (line.Contains("LOST") && custom == false && inZeit == true && !line_davor.Contains("`"))
                {
                    total_games++;
                    match_ergebnis = "LOST";
                    wins_east += 1;
                }
                /*
                // elo west
                if (line.Contains("elo") && custom == false && inZeit == true && line_davor.Contains("Game Finished"))
                {
                    elo1 = Convert.ToInt32(line.Substring(line.IndexOf("+"), line.IndexOf("elo")));
                }
                if (line.Contains("elo") && custom == false && inZeit == true && line_davor.Contains(" "))
                {
                    elo2 = Convert.ToInt32(line.Substring(line.IndexOf("+") + 1, line.IndexOf("elo") - 1));
                }
                */
                if (line.Contains("Wave:") && custom == false && inZeit == true)
                {
                    match_level += Convert.ToInt32(line.Substring(6));
                    match_lvl_aktuell = Convert.ToInt32(line.Substring(6));
                    level[Convert.ToInt32(line.Substring(6))]++;
                }
               
                //ele

                if (line.Contains("Element") && custom == false && inZeit == true && line.Contains("(") && !line.Contains("Most") && !line.Contains("Fewest"))
                {
                    //gehe zur aktuellen Zeile
                    for (int i = 0; i < allLines.Length; i++)
                    {
                        if (line == allLines[i]) zeile = i;
                        meineZeile = zeile;
                    }
                    // gehe zu wave
                    while (!allLines[zeile].Contains("Wave:"))
                    {
                        zeile++;
                    }
                    match_lvl_aktuell = Convert.ToInt32(allLines[zeile].Substring(6));
                    
                    while ((!allLines[meineZeile].Contains("LOST")) && (!allLines[meineZeile].Contains("WON")) && (allLines[meineZeile] != "Time Elapsed"))
                    {
                        meineZeile++;
                    }
                    if (allLines[meineZeile].Contains("LOST")) wins_ele++;
                    if (allLines[meineZeile].Contains("Time Elapsed") && match_ergebnis == "LOST") wins_ele++; 
                    pick_ele++;
                    tmp_str = line;
                    // name
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    string name = tmp_str.Substring(0, tmp_str.IndexOf("("));
                    Boolean gefunden = false;
                    if (allLines[meineZeile].Contains("Time Elapsed") && match_ergebnis == "LOST" || allLines[meineZeile].Contains("LOST"))
                    {
                        for (int i = 0; i < winner_names.Length; i++)
                        {
                            if (winner_names[i] == name)
                            {
                                winner_wins[i]++;
                                gefunden = true;
                            }
                        }
                        if (!gefunden)
                        {
                            for (int i = 0; i < winner_names.Length; i++)
                            {
                                if (winner_names[i] == null)
                                {
                                    winner_names[i] = name;
                                    winner_wins[i] = 1;
                                    i = winner_names.Length;
                                }

                            }
                        }
                    }
                    
                    // workers
                    for (int i = 0; i < 2; i++)
                    {
                        tmp_str = tmp_str.Substring(tmp_str.IndexOf("│")+1);
                        
                    }
                    while (tmp_str.Substring(0,1)==" ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    ele_w[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0,1));
                    if(tmp_str.Substring(1, 1)!=" ")
                    {
                        ele_w[match_lvl_aktuell] = ele_w[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                    }
                    if (ele_w[match_lvl_aktuell] > Convert.ToInt32(topworkers.Substring(0, topworkers.IndexOf("(")-1))) topworkers = (Convert.ToString(ele_w[match_lvl_aktuell])) + " ("+name+")";
                    ele_wTotal[match_lvl_aktuell] += ele_w[match_lvl_aktuell];
                    ele_wOnLvl[match_lvl_aktuell]++;
                    // income
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    ele_inc[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {
                        
                        ele_inc[match_lvl_aktuell] = ele_inc[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    if (ele_inc[match_lvl_aktuell] > Convert.ToInt32(topinc.Substring(0, topinc.IndexOf("(") - 1))) topinc = (Convert.ToString(ele_inc[match_lvl_aktuell])) + " (" + name + ")";
                    ele_incTotal[match_lvl_aktuell] += ele_inc[match_lvl_aktuell];
                    ele_incOnLvl[match_lvl_aktuell]++;
                    
                    // value
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    ele_v[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {
                        ele_v[match_lvl_aktuell] = ele_v[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    if (ele_v[match_lvl_aktuell] > Convert.ToInt32(topvalue.Substring(0, topvalue.IndexOf("(") - 1))) topvalue = (Convert.ToString(ele_v[match_lvl_aktuell])) + " (" + name + ")";
                    ele_vTotal[match_lvl_aktuell] += ele_v[match_lvl_aktuell];
                    ele_vOnLvl[match_lvl_aktuell]++;
                    // kills
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    ele_hold[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {
                        ele_hold[match_lvl_aktuell] = ele_hold[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    ele_holdTotal[match_lvl_aktuell] += ele_hold[match_lvl_aktuell];
                    ele_holdOnLvl[match_lvl_aktuell]++;
                    // leaks
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    ele_leak[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {
                        ele_leak[match_lvl_aktuell] = ele_leak[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    ele_leakTotal[match_lvl_aktuell] += ele_leak[match_lvl_aktuell];
                    ele_leakOnLvl[match_lvl_aktuell]++;
                }
                //grove
                if (line.Contains("Grove") && custom == false && inZeit == true && line.Contains("(") && !line.Contains("Most") && !line.Contains("Fewest"))
                {
                    //gehe zur aktuellen Zeile
                    for (int i = 0; i < allLines.Length; i++)
                    {
                        if (line == allLines[i]) zeile = i;
                        meineZeile = zeile;
                    }
                    

                    while ((!allLines[meineZeile].Contains("LOST")) && (!allLines[meineZeile].Contains("WON")) && !(allLines[meineZeile].Contains("Time Elapsed")))
                    {
                        meineZeile++;
                    }
                    if (allLines[meineZeile].Contains("LOST")) wins_grove++;
                    if (allLines[meineZeile].Contains("Time Elapsed") && match_ergebnis == "LOST") wins_grove++;
                    // gehe zu wave
                    while (!allLines[zeile].Contains("Wave:"))
                    {
                        zeile++;
                    }
                    if (allLines[meineZeile].Contains("Wave:")) match_lvl_aktuell = Convert.ToInt32(allLines[zeile].Substring(6));
                    pick_grove++;
                    tmp_str = line;
                    // name
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    string name = tmp_str.Substring(0, tmp_str.IndexOf("("));
                    Boolean gefunden = false;
                    if (allLines[meineZeile].Contains("Time Elapsed") && match_ergebnis == "LOST" || allLines[meineZeile].Contains("LOST"))
                    {
                        for (int i = 0; i < winner_names.Length; i++)
                        {
                            if (winner_names[i] == name)
                            {
                                winner_wins[i]++;
                                gefunden = true;
                            }
                        }
                        if (!gefunden)
                        {
                            for (int i = 0; i < winner_names.Length; i++)
                            {
                                if (winner_names[i] == null)
                                {
                                    winner_names[i] = name;
                                    winner_wins[i] = 1;
                                    i = winner_names.Length;
                                }

                            }
                        }
                    }
                    // workers
                    for (int i = 0; i < 2; i++)
                    {
                        tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);

                    }
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    if (tmp_str.Substring(1, 1)==" ") grove_w[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    else grove_w[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 2));

                    if (tmp_str.Substring(1, 1) != " ")
                    {
                        grove_w[match_lvl_aktuell] = grove_w[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(0, 1));
                    }
                    if (grove_w[match_lvl_aktuell] > Convert.ToInt32(topworkers.Substring(0, topworkers.IndexOf("(") - 1))) topworkers = (Convert.ToString(grove_w[match_lvl_aktuell])) + " (" + name + ")";
                    grove_wTotal[match_lvl_aktuell] += grove_w[match_lvl_aktuell];
                    grove_wOnLvl[match_lvl_aktuell]++;




                    // income
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    grove_inc[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {

                        grove_inc[match_lvl_aktuell] = grove_inc[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    if (grove_inc[match_lvl_aktuell] > Convert.ToInt32(topinc.Substring(0, topinc.IndexOf("(") - 1))) topinc = (Convert.ToString(grove_inc[match_lvl_aktuell])) + " (" + name + ")";
                    grove_incTotal[match_lvl_aktuell] += grove_inc[match_lvl_aktuell];
                    grove_incOnLvl[match_lvl_aktuell]++;

                    // value
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    grove_v[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {
                        grove_v[match_lvl_aktuell] = grove_v[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    if (grove_v[match_lvl_aktuell] > Convert.ToInt32(topvalue.Substring(0, topvalue.IndexOf("(") - 1))) topvalue = (Convert.ToString(grove_v[match_lvl_aktuell])) + " (" + name + ")";
                    grove_vTotal[match_lvl_aktuell] += grove_v[match_lvl_aktuell];
                    grove_vOnLvl[match_lvl_aktuell]++;
                    // kills
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    grove_hold[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {
                        grove_hold[match_lvl_aktuell] = grove_hold[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    grove_holdTotal[match_lvl_aktuell] += grove_hold[match_lvl_aktuell];
                    grove_holdOnLvl[match_lvl_aktuell]++;
                    // leaks
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    grove_leak[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {
                        grove_leak[match_lvl_aktuell] = grove_leak[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    grove_leakTotal[match_lvl_aktuell] += grove_leak[match_lvl_aktuell];
                    grove_leakOnLvl[match_lvl_aktuell]++;
                }
                // mech
                if (line.Contains("Mech") && custom == false && inZeit == true && line.Contains("(") && !line.Contains("Most") && !line.Contains("Fewest"))
                {
                    //gehe zur aktuellen Zeile
                    for (int i = 0; i < allLines.Length; i++)
                    {
                        if (line == allLines[i]) zeile = i;
                        meineZeile = zeile;
                    }
                    // gehe zu wave
                    while (!allLines[zeile].Contains("Wave"))
                    {
                        zeile++;
                    }
                    match_lvl_aktuell = Convert.ToInt32(allLines[zeile].Substring(6));

                    while ((!allLines[meineZeile].Contains("LOST")) && (!allLines[meineZeile].Contains("WON")) && (allLines[meineZeile] != "Time Elapsed"))
                    {
                        meineZeile++;
                    }
                    if (allLines[meineZeile].Contains("LOST")) wins_mech++;
                    if (allLines[meineZeile].Contains("Time Elapsed") && match_ergebnis == "LOST") wins_mech++;
                    
                    pick_mech++;
                    tmp_str = line;
                    // name
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    string name = tmp_str.Substring(0, tmp_str.IndexOf("("));
                    Boolean gefunden = false;
                    if (allLines[meineZeile].Contains("Time Elapsed") && match_ergebnis == "LOST" || allLines[meineZeile].Contains("LOST"))
                    {
                        for (int i = 0; i < winner_names.Length; i++)
                        {
                            if (winner_names[i] == name)
                            {
                                winner_wins[i]++;
                                gefunden = true;
                            }
                        }
                        if (!gefunden)
                        {
                            for (int i = 0; i < winner_names.Length; i++)
                            {
                                if (winner_names[i] == null)
                                {
                                    winner_names[i] = name;
                                    winner_wins[i] = 1;
                                    i = winner_names.Length;
                                }

                            }
                        }
                    }
                    // workers
                    for (int i = 0; i < 2; i++)
                    {
                        tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);

                    }
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    mech_w[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    if (tmp_str.Substring(1, 1) != " ")
                    {
                        mech_w[match_lvl_aktuell] = mech_w[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                    }
                    if (mech_w[match_lvl_aktuell] > Convert.ToInt32(topworkers.Substring(0, topworkers.IndexOf("(") - 1))) topworkers = (Convert.ToString(mech_w[match_lvl_aktuell])) + " (" + name + ")";
                    mech_wTotal[match_lvl_aktuell] += mech_w[match_lvl_aktuell];
                    mech_wOnLvl[match_lvl_aktuell]++;
                    // income
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    mech_inc[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {

                        mech_inc[match_lvl_aktuell] = mech_inc[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    if (mech_inc[match_lvl_aktuell] > Convert.ToInt32(topinc.Substring(0, topinc.IndexOf("(") - 1))) topinc = (Convert.ToString(mech_inc[match_lvl_aktuell])) + " (" + name + ")";
                    mech_incTotal[match_lvl_aktuell] += mech_inc[match_lvl_aktuell];
                    mech_incOnLvl[match_lvl_aktuell]++;

                    // value
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    mech_v[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {
                        mech_v[match_lvl_aktuell] = mech_v[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    if (mech_v[match_lvl_aktuell] > Convert.ToInt32(topvalue.Substring(0, topvalue.IndexOf("(") - 1))) topvalue = (Convert.ToString(mech_v[match_lvl_aktuell])) + " (" + name + ")";
                    mech_vTotal[match_lvl_aktuell] += mech_v[match_lvl_aktuell];
                    mech_vOnLvl[match_lvl_aktuell]++;
                    // kills
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    mech_hold[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {
                        mech_hold[match_lvl_aktuell] = mech_hold[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    mech_holdTotal[match_lvl_aktuell] += mech_hold[match_lvl_aktuell];
                    mech_holdOnLvl[match_lvl_aktuell]++;
                    // leaks
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    mech_leak[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {
                        mech_leak[match_lvl_aktuell] = mech_leak[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    mech_leakTotal[match_lvl_aktuell] += mech_leak[match_lvl_aktuell];
                    mech_leakOnLvl[match_lvl_aktuell]++;
                }
                //forsaken
                if (line.Contains("Forsaken") && custom == false && inZeit == true && line.Contains("(") && !line.Contains("Most") && !line.Contains("Fewest"))
                {
                    //gehe zur aktuellen Zeile
                    for (int i = 0; i < allLines.Length; i++)
                    {
                        if (line == allLines[i]) zeile = i;
                        meineZeile = zeile;
                    }
                    // gehe zu wave
                    while (!allLines[zeile].Contains("Wave:"))
                    {
                        zeile++;
                    }
                    match_lvl_aktuell = Convert.ToInt32(allLines[zeile].Substring(6));

                    while ((!allLines[meineZeile].Contains("LOST")) && (!allLines[meineZeile].Contains("WON")) && (allLines[meineZeile] != "Time Elapsed"))
                    {
                        meineZeile++;
                    }
                    if (allLines[meineZeile].Contains("LOST")) wins_forsaken++;
                    if (allLines[meineZeile].Contains("Time Elapsed") && match_ergebnis == "LOST") wins_forsaken++;
                    
                    pick_forsaken++;
                    tmp_str = line;
                    // name
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    string name = tmp_str.Substring(0, tmp_str.IndexOf("("));
                    Boolean gefunden = false;
                    if (allLines[meineZeile].Contains("Time Elapsed") && match_ergebnis == "LOST" || allLines[meineZeile].Contains("LOST"))
                    {
                        for (int i = 0; i < winner_names.Length; i++)
                        {
                            if (winner_names[i] == name)
                            {
                                winner_wins[i]++;
                                gefunden = true;
                            }
                        }
                        if (!gefunden)
                        {
                            for (int i = 0; i < winner_names.Length; i++)
                            {
                                if (winner_names[i] == null)
                                {
                                    winner_names[i] = name;
                                    winner_wins[i] = 1;
                                    i = winner_names.Length;
                                }

                            }
                        }
                    }
                    // workers
                    for (int i = 0; i < 2; i++)
                    {
                        tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);

                    }
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    forsaken_w[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    if (tmp_str.Substring(1, 1) != " ")
                    {
                        forsaken_w[match_lvl_aktuell] = forsaken_w[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                    }
                    if (forsaken_w[match_lvl_aktuell] > Convert.ToInt32(topworkers.Substring(0, topworkers.IndexOf("(") - 1))) topworkers = (Convert.ToString(forsaken_w[match_lvl_aktuell])) + " (" + name + ")";
                    forsaken_wTotal[match_lvl_aktuell] += forsaken_w[match_lvl_aktuell];
                    forsaken_wOnLvl[match_lvl_aktuell]++;
                    // income
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    forsaken_inc[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {

                        forsaken_inc[match_lvl_aktuell] = forsaken_inc[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    if (forsaken_inc[match_lvl_aktuell] > Convert.ToInt32(topinc.Substring(0, topinc.IndexOf("(") - 1))) topinc = (Convert.ToString(forsaken_inc[match_lvl_aktuell])) + " (" + name + ")";
                    forsaken_incTotal[match_lvl_aktuell] += forsaken_inc[match_lvl_aktuell];
                    forsaken_incOnLvl[match_lvl_aktuell]++;

                    // value
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    forsaken_v[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {
                        forsaken_v[match_lvl_aktuell] = forsaken_v[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    if (forsaken_v[match_lvl_aktuell] > Convert.ToInt32(topvalue.Substring(0, topvalue.IndexOf("(") - 1))) topvalue = (Convert.ToString(forsaken_v[match_lvl_aktuell])) + " (" + name + ")";
                    forsaken_vTotal[match_lvl_aktuell] += forsaken_v[match_lvl_aktuell];
                    forsaken_vOnLvl[match_lvl_aktuell]++;
                    // kills
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    forsaken_hold[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {
                        forsaken_hold[match_lvl_aktuell] = forsaken_hold[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    forsaken_holdTotal[match_lvl_aktuell] += forsaken_hold[match_lvl_aktuell];
                    forsaken_holdOnLvl[match_lvl_aktuell]++;
                    // leaks
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    forsaken_leak[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {
                        forsaken_leak[match_lvl_aktuell] = forsaken_leak[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    forsaken_leakTotal[match_lvl_aktuell] += forsaken_leak[match_lvl_aktuell];
                    forsaken_leakOnLvl[match_lvl_aktuell]++;
                }
                //mm
                if (line.Contains("Mastermind") && custom == false && inZeit == true && line.Contains("(") && !line.Contains("Most") && !line.Contains("Fewest"))
                {
                    //gehe zur aktuellen Zeile
                    for (int i = 0; i < allLines.Length; i++)
                    {
                        if (line == allLines[i]) zeile = i;
                        meineZeile = zeile;
                    }
                    // gehe zu wave
                    while (!allLines[zeile].Contains("Wave:"))
                    {
                        zeile++;
                    }
                    match_lvl_aktuell = Convert.ToInt32(allLines[zeile].Substring(6));
                    
                    while ((!allLines[meineZeile].Contains("LOST")) && (!allLines[meineZeile].Contains("WON")) && (!allLines[meineZeile].Contains("Time Elapsed")))
                    {
                        meineZeile++;
                    }
                    
                    if (allLines[meineZeile].Contains("LOST")) wins_mm++;
                    if (allLines[meineZeile].Contains("Time Elapsed") && match_ergebnis == "LOST") wins_mm++;
                    
                    pick_mm++;
                    tmp_str = line;
                    // name
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    string name = tmp_str.Substring(0, tmp_str.IndexOf("("));
                    Boolean gefunden = false;
                    if (allLines[meineZeile].Contains("Time Elapsed") && match_ergebnis == "LOST" || allLines[meineZeile].Contains("LOST"))
                    {
                        for (int i = 0; i < winner_names.Length; i++)
                        {
                            if (winner_names[i] == name)
                            {
                                winner_wins[i]++;
                                gefunden = true;
                            }
                        }
                        if (!gefunden)
                        {
                            for (int i = 0; i < winner_names.Length; i++)
                            {
                                if (winner_names[i] == null)
                                {
                                    winner_names[i] = name;
                                    winner_wins[i] = 1;
                                    i = winner_names.Length;
                                }

                            }
                        }
                    }
                    // workers
                    for (int i = 0; i < 2; i++)
                    {
                        tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);

                    }
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    mm_w[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    if (tmp_str.Substring(1, 1) != " ")
                    {
                        mm_w[match_lvl_aktuell] = mm_w[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                    }
                    if (mm_w[match_lvl_aktuell] > Convert.ToInt32(topworkers.Substring(0, topworkers.IndexOf("(") - 1))) topworkers = (Convert.ToString(mm_w[match_lvl_aktuell])) + " (" + name + ")";
                    mm_wTotal[match_lvl_aktuell] += mm_w[match_lvl_aktuell];
                    mm_wOnLvl[match_lvl_aktuell]++;
                    // income
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    mm_inc[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {

                        mm_inc[match_lvl_aktuell] = mm_inc[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    if (mm_inc[match_lvl_aktuell] > Convert.ToInt32(topinc.Substring(0, topinc.IndexOf("(") - 1))) topinc = (Convert.ToString(mm_inc[match_lvl_aktuell])) + " (" + name + ")";
                    mm_incTotal[match_lvl_aktuell] += mm_inc[match_lvl_aktuell];
                    mm_incOnLvl[match_lvl_aktuell]++;

                    // value
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    mm_v[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {
                        mm_v[match_lvl_aktuell] = mm_v[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    if (mm_v[match_lvl_aktuell] > Convert.ToInt32(topvalue.Substring(0, topvalue.IndexOf("(") - 1))) topvalue = (Convert.ToString(mm_v[match_lvl_aktuell])) + " (" + name + ")";
                    mm_vTotal[match_lvl_aktuell] += mm_v[match_lvl_aktuell];
                    mm_vOnLvl[match_lvl_aktuell]++;
                    // kills
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    mm_hold[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {
                        mm_hold[match_lvl_aktuell] = mm_hold[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    mm_holdTotal[match_lvl_aktuell] += mm_hold[match_lvl_aktuell];
                    mm_holdOnLvl[match_lvl_aktuell]++;
                    // leaks
                    tmp_str = tmp_str.Substring(tmp_str.IndexOf("│") + 1);
                    while (tmp_str.Substring(0, 1) == " ")
                    {
                        tmp_str = tmp_str.Substring(1);
                    }
                    mm_leak[match_lvl_aktuell] = Convert.ToInt32(tmp_str.Substring(0, 1));
                    while (tmp_str.Substring(1, 1) != " ")
                    {
                        mm_leak[match_lvl_aktuell] = mm_leak[match_lvl_aktuell] * 10 + Convert.ToInt32(tmp_str.Substring(1, 1));
                        tmp_str = tmp_str.Substring(1);
                    }
                    mm_leakTotal[match_lvl_aktuell] += mm_leak[match_lvl_aktuell];
                    mm_leakOnLvl[match_lvl_aktuell]++;
                }
                while (!allLines[zeile].Contains("Wave:"))
                {
                    zeile++;
                }
                if (allLines[meineZeile].Contains("Wave:")) match_lvl_aktuell = Convert.ToInt32(allLines[zeile].Substring(6));


                if (time && line.Contains("Time Elapsed:") && custom == false && inZeit == true && line_davor.Contains("`"))
                {
                    match_time = line.Substring(14);
                    int stunden = Int32.Parse(match_time.Substring(0, match_time.IndexOf(":")));
                    int minuten = Int32.Parse(match_time.Substring(match_time.IndexOf(":")+1));
                    matchtime = stunden + (minuten / 60.00);
                    total_matchtime += matchtime;
                    time = false;
                }

                if (line.Contains("Time Elapsed"))
                {
                    time = true;
                }
                line_davor = line;
            }

            avg_matchtime = total_matchtime / total_games;
            int pick_total = pick_ele + pick_forsaken + pick_grove + pick_mech + pick_mm;
            int[] winner_copy = new int[50000];
            Array.Copy(winner_wins, winner_copy, 50000);
            Array.Sort(winner_copy);
            string[] winner_names_copy = new string[50000];
            Array.Copy(winner_names, winner_names_copy, 50000);
            Array.Sort(winner_copy);
            int playerint_first = winner_copy[49999];
            int playerint_second = winner_copy[49998];
            int playerint_third = winner_copy[49997];
            string playerstring_first = winner_names_copy[0];
            string playerstring_second = winner_names_copy[1];
            string playerstring_third = winner_names_copy[2];
            /*
            for (int i = 0; i < winner_wins.Length; i++)
            {
                if (winner_wins[i] == playerint_mostWins) mvp = playerstring_first + "(" + winner_wins[i] + ")";
                if (winner_wins[i] == playerint_second) mvp2 = playerstring_second + "(" + winner_wins[i] + ")";
                if (winner_wins[i] == playerint_third) mvp3 = playerstring_third + "(" + winner_wins[i] + ")";
            }*/
            mvp = playerstring_first + "(" + playerint_first + ")";
            mvp2 = playerstring_second + "(" + playerint_second + ")";
            mvp3 = playerstring_third + "(" + playerint_third + ")";

            Console.WriteLine(total_games);
            Console.WriteLine(customgames/2);
            Console.WriteLine(pick_total);
            Console.WriteLine(avg_matchtime);
            Console.WriteLine((match_level / Convert.ToDouble(total_games)));
            Console.WriteLine(wins_west);
            Console.WriteLine(wins_east);
            Console.WriteLine(pick_ele);
            Console.WriteLine(pick_grove);
            Console.WriteLine(pick_mech);
            Console.WriteLine(pick_forsaken);
            Console.WriteLine(pick_mm);
            Console.WriteLine(wins_ele);
            Console.WriteLine(wins_grove);
            Console.WriteLine(wins_mech);
            Console.WriteLine(wins_forsaken);
            Console.WriteLine(wins_mm);
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine(level[i]);
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((ele_wTotal[i] / Convert.ToDouble(ele_wOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((ele_incTotal[i] / Convert.ToDouble(ele_incOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((ele_vTotal[i] / Convert.ToDouble(ele_vOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((ele_holdTotal[i] / Convert.ToDouble(ele_holdOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((ele_leakTotal[i] / Convert.ToDouble(ele_leakOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((grove_wTotal[i] / Convert.ToDouble(grove_wOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((grove_incTotal[i] / Convert.ToDouble(grove_incOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((grove_vTotal[i] / Convert.ToDouble(grove_vOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((grove_holdTotal[i] / Convert.ToDouble(grove_holdOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((grove_leakTotal[i] / Convert.ToDouble(grove_leakOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((mech_wTotal[i] / Convert.ToDouble(mech_wOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((mech_incTotal[i] / Convert.ToDouble(mech_incOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((mech_vTotal[i] / Convert.ToDouble(mech_vOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((mech_holdTotal[i] / Convert.ToDouble(mech_holdOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((mech_leakTotal[i] / Convert.ToDouble(mech_leakOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((forsaken_wTotal[i] / Convert.ToDouble(forsaken_wOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((forsaken_incTotal[i] / Convert.ToDouble(forsaken_incOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((forsaken_vTotal[i] / Convert.ToDouble(forsaken_vOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((forsaken_holdTotal[i] / Convert.ToDouble(forsaken_holdOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((forsaken_leakTotal[i] / Convert.ToDouble(forsaken_leakOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((mm_wTotal[i] / Convert.ToDouble(mm_wOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((mm_incTotal[i] / Convert.ToDouble(mm_incOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((mm_vTotal[i] / Convert.ToDouble(mm_vOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((mm_holdTotal[i] / Convert.ToDouble(mm_holdOnLvl[i])));
            }
            for (int i = 1; i < 22; i++)
            {
                Console.WriteLine((mm_leakTotal[i] / Convert.ToDouble(mm_leakOnLvl[i])));
            }
            Console.WriteLine("Most wins: ");
            Console.WriteLine(mvp);
            Console.WriteLine(mvp2);
            Console.WriteLine(mvp3);
            Console.WriteLine("Most workers: " + topworkers);
            Console.WriteLine("Most income: " + topinc);
            Console.WriteLine("Most value: " + topvalue);
            Console.ReadLine();
        }

    }
}
