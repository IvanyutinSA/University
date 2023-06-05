using System.Data;
var str = File.ReadAllLines("input.txt");
var num = str[0].Split().Select(x => int.Parse(x)).ToArray();
var N = num[0];
List<string> details = new List<string>();
List<string> bluep = new List<string>();
for(int i = 1; i<N+1; i++)
{
    var temp = str[i].Replace(" ","").ToString();
    details.Add(temp);
}
for(int j = N+1; j<2*N+N+1; j++)
{
    var temp2 = str[j].Replace(" ","").ToString();
    bluep.Add(temp2);
}
bluep.Distinct();
int indexdetail = 1;
int indexprojection = 1;
int numcheck = 0;
int count = 0;
int countrolcheck = 0;
List<string> detail = new List<string>();
List<(string,string,string,int)> projres = new List<(string,string,string,int)>();
List<(string, string, string,int)> simprojres = new List<(string, string, string,int)>();
for (int i = 0; i < details.Count; i++)
{
    string upper = details[i][0..5];
    string closest = details[i][5..10];
    string downer = details[i][10..15];
    string farest = details[i][15..20];
    string simupper = simmetrichny(upper);
    string simclosest = simmetrichny(closest);
    string simdowner = simmetrichny(downer);
    string simfarest = simmetrichny(farest);
    for (int j = 0; j < bluep.Count; j++)
    {
        string upperp = bluep[j][0..5];
        string vdavl = bluep[j][5..10];
        string downp = bluep[j][10..15];
        numcheck = Vrashsravneniye(upper, closest, downer, farest, upperp, vdavl, downp, numcheck);

        if(numcheck == 3)
        {
            projres.Add((upperp, vdavl, downp, indexprojection));
            count++;
        }
        else
        {
            numcheck = 0;
            numcheck = Vrashsimsravneniyr(simupper, simclosest, simdowner, simfarest, upperp, vdavl, downp, numcheck);
            if (numcheck == 3)
            {
                simprojres.Add((upperp, vdavl, downp, indexprojection));
                count++;
            }
        }
        indexprojection++;
    }
    indexdetail++;
    indexprojection = 1;
    numcheck = 0;
}
int idetail = 0;
List<(int, int)> resu = new List<(int, int)>();
for(int i = 0; i<simprojres.Count;i++)
{
   for(int j = 0; j<projres.Count; j++)
   {
        string sim1 = simmetrichny(projres[j].Item1);
        string sim2 = simmetrichny(projres[j].Item2);
        string sim3 = simmetrichny(projres[j].Item3);
        if (String.Equals(simprojres[i].Item1, sim1) && String.Equals(simprojres[i].Item3, sim3))
        {
            idetail++;
         
            resu.Add((projres[j].Item4, simprojres[i].Item4));
        }
   }
}
var resus = resu.Distinct().ToList();
for(int i = 0; i<resus.Count; i++)
{
    Console.WriteLine($"{resus[i].Item2}, {resus[i].Item1}");
}

int Vrashsravneniye(string num1, string num2, string num3, string num4, string up, string inner, string down, int numcheck)
{
    if (String.Equals(num1, up) && String.Equals(num2, inner) && (String.Equals(num3, down)))
    {
        numcheck = 3;
        return numcheck;
    }
    else
    {
        if (String.Equals(num1,up)&& String.Equals(num4,inner)&& String.Equals(num3,down))
        {
            numcheck = 3;
            return numcheck;
        }
        else
        {
            if(String.Equals(num2,up)&&String.Equals(num1,inner)&&String.Equals(num4,down))
            {
                numcheck = 3;
                return numcheck;
            }
            else
            {
                if (String.Equals(num3, up) && String.Equals(num2, inner) && String.Equals(num1, down))
                {
                    numcheck = 3;
                    return numcheck;
                }
                else
                {
                    if(String.Equals(num4, up) && String.Equals(num3, inner) && String.Equals(num2, down))
                    {
                        numcheck = 3;
                        return numcheck;
                    }
                }
            }
        }
        if (String.Equals(num4, up) && String.Equals(num1, inner) && String.Equals(num2, down))
        {
            numcheck = 3;
            return numcheck;
        }
        else
        {
            if(String.Equals(num3, up) && String.Equals(num4, inner) && String.Equals(num1, down))
            {
                numcheck = 3;
                return numcheck;
            }
            else
            {
                if (String.Equals(num2, up) && String.Equals(num3, inner) && String.Equals(num4, down))
                {
                    numcheck = 3;
                    return numcheck;
                }
                else
                {
                    numcheck = -1;
                    return numcheck;
                }
            }
        }
    }
}
int Vrashsimsravneniyr(string num1s, string num2s, string num3s, string num4s, string up, string inner, string down, int numcheck)
{

    if (String.Equals(num1s, up) && String.Equals(num4s, inner) && (String.Equals(num3s, down)))
    {
        numcheck = 3;
        return numcheck;
    }
    else
    {
        if (String.Equals(num1s, up) && String.Equals(num2s, inner) && String.Equals(num3s, down))
        {
            numcheck = 3;
            return numcheck;
        }
        else
        {
            if (String.Equals(num2s, up) && String.Equals(num3s,inner)&&String.Equals(num4s,down))
            {
                numcheck = 3;
                return numcheck;
            }
            else
            {
                if (String.Equals(num3s, up) && String.Equals(num4s, inner) && String.Equals(num1s, down))
                {
                    numcheck = 3;
                    return numcheck;
                }
                else
                {
                    if (String.Equals(num4s, up) && String.Equals(num1s, inner) && String.Equals(num2s, down))
                    {
                        numcheck = 3;
                        return numcheck;
                    }
                }
            }
        }
        if (String.Equals(num2s, up) && String.Equals(num1s, inner) && String.Equals(num4s, down))
        {
            numcheck = 3;
            return numcheck;
        }
        else
        {
            if (String.Equals(num3s, up) && String.Equals(num2s, inner) && String.Equals(num1s, down))
            {
                numcheck = 3;
                return numcheck;
            }
            else
            {
                if (String.Equals(num4s, up) && String.Equals(num3s, inner) && String.Equals(num2s, down))
                {
                    numcheck = 3;
                    return numcheck;
                }
                else
                {
                    numcheck = -1;
                    return numcheck;
                }
            }
        }
    }
}
string simmetrichny(string num)
{
    int middle = 3;
    var box = num.ToCharArray();
    for(int i = 0; i<middle; i++)
    {
        var temp = box[i];
        box[i] = box[box.Length-1-i];
        box[box.Length - 1 - i] = temp;
    }
    string num2 = new string(box);
  
    return num2;
}
