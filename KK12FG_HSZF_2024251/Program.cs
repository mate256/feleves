using System.Collections.Generic;
using System.IO;
using KK12FG_HSZF_2024251.Classes;
using Newtonsoft.Json;

List<animal>? animals = JsonConvert.DeserializeObject<List<animal>>(File.ReadAllText("animals.json"));
List<activity>? activities = JsonConvert.DeserializeObject<List<activity>>(File.ReadAllText("activities.json"));

