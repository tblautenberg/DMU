// Small textventure game to pratice "what i know code". I will not look online, or use any gAI for this. Ejoy ^^

using TextVenture;

BDragon Tobias = new("Tobias", 20, 20);
Player Krappa = new("Krappa", 29, 10, 10);

Krappa.DoubleStrike();

Tobias.DragonAbilities.Reverse(); // Smart måde at reverse et array

for (int i = 0; i < Tobias.DragonAbilities.Count; i++)
{
    Console.WriteLine($"The dragon used: {Tobias.DragonAbilities[i]}");
}


// Very experimentinal

// foreach (var instance in Tobias.DragonCombatLog)
// {
//    Console.WriteLine(Tobias.DragonCombatLog);
// }