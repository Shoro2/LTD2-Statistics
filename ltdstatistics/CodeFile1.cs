static string GetJsonString()
{
    var sb = new StringBuilder();
    string thumbnail = "";
    int wave = 0;
    if (!int.TryParse(BackendApi.GetPostGameValue("wave"), out wave))
    {
        DeveloperApi.LogWarning("Failed to parse wave. Defaulting to 1");
        wave = 1;
    }

    switch (wave)
    {
        case 1:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/Crab.png";
            break;
        case 2:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/Wale.png";
            break;
        case 3:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/Hopper.png";
            break;
        case 4:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/FlyingChicken.png";
            break;
        case 5:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/Scorpion.png";
            break;
        case 6:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/Rocko.png";
            break;
        case 7:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/Sludge.png";
            break;
        case 8:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/QuillShooter.png";
            break;
        case 9:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/Carapace.png";
            break;
        case 10:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/Granddaddy.png";
            break;
        case 11:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/DireToad.png";
            break;
        case 12:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/Mantis.png";
            break;
        case 13:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/DrillGolem.png";
            break;
        case 14:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/KillerSlug.png";
            break;
        case 15:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/Quadrapus.png";
            break;
        case 16:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/MetalDragon.png";
            break;
        case 17:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/Cardinal.png";
            break;
        case 18:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/Kobra.png";
            break;
        case 19:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/WaleChief.png";
            break;
        case 20:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/Maccabeus.png";
            break;
        case 21:
            thumbnail = "http://beta.legiontd2.com/static/images/textures/Icons/LegionLord.png";
            break;
        default:
            thumbnail = "http://i.imgur.com/OAixxIK.png";
            break;
    }



    sb.AppendLine("{");
    sb.AppendLine("\"embeds\": [{");
    sb.AppendLine("\"title\": \"░░░░░░░▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓█████ Game Finished █████▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒░░░░░░░\",");
    sb.AppendLine("\"color\": 3512341,");
    sb.AppendLine("\"timestamp\": \"" + DateTime.Now.ToString("o") + "\",");
    sb.AppendLine("\"footer\": {");
    sb.AppendLine("\"icon_url\": \"http://beta.legiontd2.com/webhook-uploads/1476985024408/small2.PNG\",");
    sb.AppendLine("\"text\": \"LegionTD2 - Alpha\"");
    sb.AppendLine("},");
    sb.AppendLine("\"thumbnail\": {");
    sb.AppendLine("\"url\": \"" + thumbnail + "\"");
    sb.AppendLine("},");


    /* ##################
     * ###### WEST ######
     * ##################
     */

    int countPlayer = 0;
    int sumWorker = 0;
    int sumIncome = 0;
    int sumValue = 0;
    int sumKills = 0;
    int sumLeaks = 0;

    Dictionary<string, int> mvpList = new Dictionary<string, int>();
    string mvpWorker = "";
    mvpList.Add("Worker", 0);
    string mvpIncome = "";
    mvpList.Add("Income", 0);
    string mvpValue = "";
    mvpList.Add("Value", 0);
    string mvpKills = "";
    mvpList.Add("Kills", 0);
    string mvpLeaks = "";
    mvpList.Add("Leaks", int.MaxValue);

    string westResult = Snapshot.PlayerProperties[1].GameResult.ToString().ToUpper();
    string eastResult = Snapshot.PlayerProperties[5].GameResult.ToString().ToUpper();

    sb.Append("\"description\": ");
    sb.Append("\"");
    //sb.Append("**WON**");
    sb.Append("**" + westResult + "**");
    sb.Append("\\n");
    sb.Append("```Markdown\\n┌──────────────────────┬────────────┬─────────┬────────┬───────┬───────┬───────┐\\n");
    sb.Append("#" + "Name".PadLeft(13) + "│".PadLeft(10) + "Legion".PadLeft(9) + " │ Workers".PadLeft(12) + " │ Income │ Value │ Kills │ Leaks │\\n");
    sb.Append("├──────────────────────┼────────────┼─────────┼────────┼───────┼───────┼───────┤\\n");
    for (int i = 0; i < PlayerApi.GetAlliesOfPlayer(1).Count; i++)
    {
        ushort player = PlayerApi.GetAlliesOfPlayer(1)[i];
        if (!Snapshot.PlayerProperties[player].IsPlaying()) continue;
        countPlayer++;
        string name = Snapshot.PlayerProperties[player].Name.Get();
        if (!Snapshot.PlayerProperties[player].IsConnected)
            name += "(Q)";
        sb.Append("│ " + name.PadRight(20) + " │ ");
        sb.Append(BackendApi.GetPlayerPostGameValue(player, "legion").PadRight(11) + "│ ");
        sb.Append(Snapshot.PlayerProperties[player].Workers.Get().ToString().PadLeft(7) + " │ ");
        sb.Append(Snapshot.PlayerProperties[player].Income.Get().ToString().PadLeft(6) + " │ ");
        sb.Append(Snapshot.PlayerProperties[player].Value.Get().ToString().PadLeft(5) + " │");
        sb.Append(Snapshot.PlayerProperties[player].Kills.Get().ToString().PadLeft(6) + " │"); //TODO: Add kills property?
        sb.Append(Snapshot.PlayerProperties[player].Leaks.Get().ToString().PadLeft(6) + " │"); //TODO: Add leaks property?

        sb.Append("\\n");

        sumWorker += Snapshot.PlayerProperties[player].Workers.Get();
        sumIncome += Snapshot.PlayerProperties[player].Income.Get();
        sumValue += Snapshot.PlayerProperties[player].Value.Get();
        sumKills += Snapshot.PlayerProperties[player].Kills.Get(); //TODO: Add kills property?
        sumLeaks += Snapshot.PlayerProperties[player].Leaks.Get(); //TODO: Add leaks property?

        if (mvpList["Worker"] < Snapshot.PlayerProperties[player].Workers.Get())
        {
            mvpList["Worker"] = Snapshot.PlayerProperties[player].Workers.Get();
            mvpWorker = Snapshot.PlayerProperties[player].Name.Get();
        }
        if (mvpList["Income"] < Snapshot.PlayerProperties[player].Income.Get())
        {
            mvpList["Income"] = Snapshot.PlayerProperties[player].Income.Get();
            mvpIncome = Snapshot.PlayerProperties[player].Name.Get();
        }
        if (mvpList["Value"] < Snapshot.PlayerProperties[player].Value.Get())
        {
            mvpList["Value"] = Snapshot.PlayerProperties[player].Value.Get();
            mvpValue = Snapshot.PlayerProperties[player].Name.Get();
        }
        if (mvpList["Kills"] < Snapshot.PlayerProperties[player].Kills.Get()) //TODO: Add kills property?
        {
            mvpList["Kills"] = Snapshot.PlayerProperties[player].Kills.Get();
            mvpKills = Snapshot.PlayerProperties[player].Name.Get();
        }
        if (mvpList["Leaks"] > Snapshot.PlayerProperties[player].Leaks.Get()) //TODO: Add leaks property?
        {
            mvpList["Leaks"] = Snapshot.PlayerProperties[player].Leaks.Get();
            mvpLeaks = Snapshot.PlayerProperties[player].Name.Get();
        }
    }
    sb.Append("├──────────────────────┴────────────┼─────────┼────────┼───────┼───────┼───────┤\\n");
    sb.Append("│ Team Average: ".PadRight(36) + "│" +
        Math.Round((double)sumWorker / countPlayer).ToString().PadLeft(8) + " │" +
        Math.Round((double)sumIncome / countPlayer).ToString().PadLeft(7) + " │" +
        Math.Round((double)sumValue / countPlayer).ToString().PadLeft(6) + " │" +
        Math.Round((double)sumKills / countPlayer).ToString().PadLeft(6) + " │" +
        Math.Round((double)sumLeaks / countPlayer).ToString().PadLeft(6) + " │");
    sb.Append("\\n└───────────────────────────────────┴─────────┴────────┴───────┴───────┴───────┘\\n");
    sb.Append("```");


    /* ##################
     * ###### EAST ######
     * ##################
     */

    countPlayer = 0; // Replace with number of other players
    sumWorker = 0;
    sumIncome = 0;
    sumValue = 0;
    sumKills = 0;
    sumLeaks = 0;

    //sb.Append("\\n**LOST**\\n");
    sb.Append("\\n**" + eastResult + "**\\n");
    sb.Append("```Markdown\\n┌──────────────────────┬────────────┬─────────┬────────┬───────┬───────┬───────┐\\n");
    sb.Append("#" + "Name".PadLeft(13) + "│".PadLeft(10) + "Legion".PadLeft(9) + " │ Workers".PadLeft(12) + " │ Income │ Value │ Kills │ Leaks │\\n");
    sb.Append("├──────────────────────┼────────────┼─────────┼────────┼───────┼───────┼───────┤\\n");
    for (int i = 0; i < PlayerApi.GetAlliesOfPlayer(5).Count; i++)
    {
        ushort player = PlayerApi.GetAlliesOfPlayer(5)[i];
        if (!Snapshot.PlayerProperties[player].IsPlaying()) continue;
        countPlayer++;
        string name = Snapshot.PlayerProperties[player].Name.Get();
        if (!Snapshot.PlayerProperties[player].IsConnected)
            name += "(Q)";
        sb.Append("│ " + name.PadRight(20) + " │ ");
        sb.Append(BackendApi.GetPlayerPostGameValue(player, "legion").PadRight(11) + "│ ");
        sb.Append(Snapshot.PlayerProperties[player].Workers.Get().ToString().PadLeft(7) + " │ ");
        sb.Append(Snapshot.PlayerProperties[player].Income.Get().ToString().PadLeft(6) + " │ ");
        sb.Append(Snapshot.PlayerProperties[player].Value.Get().ToString().PadLeft(5) + " │");
        sb.Append(Snapshot.PlayerProperties[player].Kills.Get().ToString().PadLeft(6) + " │"); //TODO: Add kills property?
        sb.Append(Snapshot.PlayerProperties[player].Leaks.Get().ToString().PadLeft(6) + " │"); //TODO: Add leaks property?

        sb.Append("\\n");

        sumWorker += Snapshot.PlayerProperties[player].Workers.Get();
        sumIncome += Snapshot.PlayerProperties[player].Income.Get();
        sumValue += Snapshot.PlayerProperties[player].Value.Get();
        sumKills += Snapshot.PlayerProperties[player].Kills.Get(); //TODO: Add kills property?
        sumLeaks += Snapshot.PlayerProperties[player].Leaks.Get(); //TODO: Add leaks property?

        if (mvpList["Worker"] < Snapshot.PlayerProperties[player].Workers.Get())
        {
            mvpList["Worker"] = Snapshot.PlayerProperties[player].Workers.Get();
            mvpWorker = Snapshot.PlayerProperties[player].Name.Get();
        }
        if (mvpList["Income"] < Snapshot.PlayerProperties[player].Income.Get())
        {
            mvpList["Income"] = Snapshot.PlayerProperties[player].Income.Get();
            mvpIncome = Snapshot.PlayerProperties[player].Name.Get();
        }
        if (mvpList["Value"] < Snapshot.PlayerProperties[player].Value.Get())
        {
            mvpList["Value"] = Snapshot.PlayerProperties[player].Value.Get();
            mvpValue = Snapshot.PlayerProperties[player].Name.Get();
        }
        if (mvpList["Kills"] < Snapshot.PlayerProperties[player].Kills.Get()) //TODO: Add kills property?
        {
            mvpList["Kills"] = Snapshot.PlayerProperties[player].Kills.Get();
            mvpKills = Snapshot.PlayerProperties[player].Name.Get();
        }
        if (mvpList["Leaks"] > Snapshot.PlayerProperties[player].Leaks.Get()) //TODO: Add leaks property?
        {
            mvpList["Leaks"] = Snapshot.PlayerProperties[player].Leaks.Get();
            mvpLeaks = Snapshot.PlayerProperties[player].Name.Get();
        }
    }
    sb.Append("├──────────────────────┴────────────┼─────────┼────────┼───────┼───────┼───────┤\\n");
    sb.Append("│ Team Average: ".PadRight(36) + "│" +
        Math.Round((double)sumWorker / countPlayer).ToString().PadLeft(8) + " │" +
        Math.Round((double)sumIncome / countPlayer).ToString().PadLeft(7) + " │" +
        Math.Round((double)sumValue / countPlayer).ToString().PadLeft(6) + " │" +
        Math.Round((double)sumKills / countPlayer).ToString().PadLeft(6) + " │" +
        Math.Round((double)sumLeaks / countPlayer).ToString().PadLeft(6) + " │");
    sb.Append("\\n└───────────────────────────────────┴─────────┴────────┴───────┴───────┴───────┘\\n");
    sb.Append("```");
    sb.AppendLine("\",");


    sb.AppendLine("\"fields\": [");

    // Time elapsed
    int seconds = Extensions.GetSeconds(Snapshot.CurrentTime);
    string timeElapsed = Extensions.GetTimeString(seconds);
    sb.AppendLine("{");
    sb.AppendLine("\"name\": \"Time Elapsed\",");
    sb.AppendLine("\"value\": \"" + timeElapsed + "\","); // Time Elapsed
    sb.AppendLine("\"inline\": true");
    sb.AppendLine("},");

    // Wave
    sb.AppendLine("{");
    sb.AppendLine("\"name\": \"Wave\",");
    sb.AppendLine("\"value\": \"" + wave + "\",");
    sb.AppendLine("\"inline\": true");
    sb.AppendLine("},");

    // MVPs
    sb.AppendLine("{");
    sb.AppendLine("\"name\": \"Captions:\",");
    sb.AppendLine("\"value\": \"(Q): Quit game (Disconnected / closed game at or before end)\",");
    sb.AppendLine("\"inline\": false");
    sb.AppendLine("},");
    sb.AppendLine("{");
    sb.AppendLine("\"name\": \"Most Income\",");
    sb.AppendLine("\"value\": \"" + mvpIncome + " (" + mvpList["Income"] + ") \",");
    sb.AppendLine("\"inline\": false");
    sb.AppendLine("},");
    sb.AppendLine("{");
    sb.AppendLine("\"name\": \"Most Value\",");
    sb.AppendLine("\"value\": \"" + mvpValue + " (" + mvpList["Value"] + ") \",");
    sb.AppendLine("\"inline\": false");
    sb.AppendLine("},");
    sb.AppendLine("{");
    sb.AppendLine("\"name\": \"Most Kills\",");
    sb.AppendLine("\"value\": \"" + mvpIncome + " (" + mvpList["Kills"] + ") \",");
    sb.AppendLine("\"inline\": true");
    sb.AppendLine("},");
    sb.AppendLine("{");
    sb.AppendLine("\"name\": \"Least Leaks\",");
    sb.AppendLine("\"value\": \"" + mvpValue + " (" + mvpList["Leaks"] + ") \",");
    sb.AppendLine("\"inline\": true");
    sb.AppendLine("}");

    sb.AppendLine("]");
    sb.AppendLine("}]");
    sb.AppendLine("}");
    DeveloperApi.Log("Json string: " + sb.ToString());

    return sb.ToString();
}