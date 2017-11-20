static string GetJsonString()
{
    DateTime.Now.ToString("o"); // zeit
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

    string westResult = Snapshot.PlayerProperties[1].GameResult.ToString().ToUpper(); // west won/lose
    string eastResult = Snapshot.PlayerProperties[5].GameResult.ToString().ToUpper(); // east won/lose

    for (int i = 0; i < PlayerApi.GetAlliesOfPlayer(1).Count; i++)
    {
        ushort player = PlayerApi.GetAlliesOfPlayer(1)[i];
        if (!Snapshot.PlayerProperties[player].IsPlaying()) continue;
        countPlayer++;
        string name = Snapshot.PlayerProperties[player].Name.Get(); // player name
        if (!Snapshot.PlayerProperties[player].IsConnected) // quir or not
            name += "(Q)";
        BackendApi.GetPlayerPostGameValue(player, "legion"); // Legion
        Snapshot.PlayerProperties[player].Workers.Get().ToString(); // Workers
        Snapshot.PlayerProperties[player].Income.Get().ToString(); // Income
        Snapshot.PlayerProperties[player].Value.Get().ToString(); //Value
        Snapshot.PlayerProperties[player].Kills.Get().ToString(); // Kills TODO: Add kills property?
        Snapshot.PlayerProperties[player].Leaks.Get().ToString(); // Leaks  TODO: Add leaks property?


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
    Math.Round((double)sumWorker / countPlayer).ToString(); // Team avg
    Math.Round((double)sumIncome / countPlayer).ToString();
    Math.Round((double)sumValue / countPlayer).ToString();
    Math.Round((double)sumKills / countPlayer).ToString();
    Math.Round((double)sumLeaks / countPlayer).ToString();



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


    for (int i = 0; i < PlayerApi.GetAlliesOfPlayer(5).Count; i++)
    {
        ushort player = PlayerApi.GetAlliesOfPlayer(5)[i];
        if (!Snapshot.PlayerProperties[player].IsPlaying()) continue;
        countPlayer++;
        string name = Snapshot.PlayerProperties[player].Name.Get();
        if (!Snapshot.PlayerProperties[player].IsConnected)
            name += "(Q)";
        BackendApi.GetPlayerPostGameValue(player, "legion");
        Snapshot.PlayerProperties[player].Workers.Get().ToString();
        Snapshot.PlayerProperties[player].Income.Get().ToString();
        Snapshot.PlayerProperties[player].Value.Get().ToString();
        Snapshot.PlayerProperties[player].Kills.Get().ToString(); //TODO: Add kills property?
        Snapshot.PlayerProperties[player].Leaks.Get().ToString(); //TODO: Add leaks property?


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
    Math.Round((double)sumWorker / countPlayer).ToString();
    Math.Round((double)sumIncome / countPlayer).ToString();
    Math.Round((double)sumValue / countPlayer).ToString();
    Math.Round((double)sumKills / countPlayer).ToString();
    Math.Round((double)sumLeaks / countPlayer).ToString();

    // Time elapsed
    int seconds = Extensions.GetSeconds(Snapshot.CurrentTime);
    string timeElapsed = Extensions.GetTimeString(seconds);

    // Wave

    wave


    // MVPs

    mvpIncome;
    mvpList["Income"];
    mvpValue
    mvpList["Value"];
    mvpIncome
    mvpList["Kills"];
    mvpValue
    mvpList["Leaks"];
    
}