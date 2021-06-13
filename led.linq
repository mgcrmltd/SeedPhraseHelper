void Main()
{
	GenerateCardMix();
	//GenerateRandomWordList(24);
}

public void GenerateRandomWordList(int count)
{
	var words = GetLedgerUniqueWords();
	var r = new Random();
	for(int i = 0; i<count; i++)
	{
		words[r.Next(0,2048)].Dump();
	}
}

public void GenerateCardMix()
{
	var r = new Random(USE_DIGITS_FROM_WHEREVER);

	int randomVal = -1;
	for (var i = 0; i < 24; i++)
	{
		randomVal = r.Next(1, 3);
		if (randomVal == 1)
			Console.WriteLine($"{GetInt(i+1)}: 1       {GetInt(i+1)}: 2");
		else
			Console.WriteLine($"{GetInt(i+1)}: 2       {GetInt(i+1)}: 1");

	}
}

public string GetInt(int val)
{
	return val.ToString("D2");
}
public string[] GetLedgerUniqueWords()
{
	var myClient = new WebClient();
	Stream response = myClient.OpenRead("https://raw.githubusercontent.com/bitcoin/bips/master/bip-0039/english.txt");
	var sr = new StreamReader(response, Encoding.ASCII);
	var content = sr.ReadToEnd();
	response.Close();
	return content.Split('\n');
}
