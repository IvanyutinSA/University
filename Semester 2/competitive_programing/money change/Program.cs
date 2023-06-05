var cish = new List<int>();
var failA = new List<int>();
var con = new List<int>();
var failB = new List<int>();
var ei = new List<int>();
StreamReader f = new StreamReader("input.txt");
string s = f.ReadLine();
int nish = Convert.ToInt32(s.Split()[0]);
for (int i = 1; i < nish; i++)
{
    cish.Add(Convert.ToInt32(s.Split()[i]));
}
s = f.ReadLine();
int kish = Convert.ToInt32(s.Split()[0]);
for (int i = 0; i < kish; i++)
{
    failA.Add(Convert.ToInt32(s.Split()[i + 1]));
}
s = f.ReadLine();
int ncon = Convert.ToInt32(s.Split()[0]);
for (int i = 1; i < ncon; i++)
{
    con.Add(Convert.ToInt32(s.Split()[i]));
}
s = f.ReadLine();
int kcon = Convert.ToInt32(s.Split()[0]);
for (int i = 0; i < kcon; i++)
{
    failB.Add(Convert.ToInt32(s.Split()[i]));
}
s = f.ReadLine();
for (int i = 0; i < nish; i++)
{
    ei.Add(Convert.ToInt32(s.Split()[i]));
}

failA.Sort();
failA.Reverse();
failB.Sort();

//исключаем несчастливые числа
for (int i = 0; i < ei.Count - 1; i++)
{
    for (int j = 0; j < failA.Count - 1; j++)
    {
        if (ei[i] >= failA[j])
        {
            ei[i] -= 1;
        }
    }
}
//
//значения мелких единиц
var val = new List<int>(ei);
for (int i = 0; i < val.Count - 1; i++)
{
    for (int j = i + 1; j < cish.Count - 1; i++)
    {
        val[i] *= cish[j];
    }
}
int sval = 0;
string ay = "";
foreach (var i in val)
{
    ay += Convert.ToString(i);

}
sval = Convert.ToInt32(ay);
sval = 141;


var newval = new List<int>();
var ou = new List<int>();

for (int i = con.Count; i > 0; i--)
{

    newval.Add(sval % con[i - 1]);
    sval = sval / con[i - 1];
    if (i == 1)
    {
        newval.Add(sval);
    }

}
newval.Sort();
newval.Reverse();
foreach (int i in newval)
{
    ou.Add(i);
}

for (int i = 0; i < ou.Count - 1; i++)
{
    for (int j = 0; j < failB.Count - 1; j++)
    {
        if (ou[i] >= failB[j])
        {
            ou[i] += 1;
        }
    }
}

foreach (int i in ou)
{
    Console.WriteLine(i);
}
f.Close();
