string[] input = File.ReadAllLines("input.txt");

Traitement traitement = new Traitement(input);

//int res = traitement.Part1();
int res = traitement.Part2();


// string symbols = "!@#$%^&*()_+=-/";


// string test = "";
// foreach(string s in input)
// {
//     test += s;
// }

// test = test.Replace(".", "");
// test = test.Replace("0", "");
// test = test.Replace("1", "");
// test = test.Replace("2", "");
// test = test.Replace("3", "");
// test = test.Replace("4", "");
// test = test.Replace("5", "");
// test = test.Replace("6", "");
// test = test.Replace("7", "");
// test = test.Replace("8", "");
// test = test.Replace("9", "");

// string final = "";
// foreach(char c in test)
// {
//     if(!symbols.Contains(c))
//     {
//         final += c.ToString();
//     }
// }


//Console.WriteLine(test);
Console.WriteLine(res);