using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Graph
{
    private int NUM_VERTICES;
    string res;
    Vertex[] vertexList;
    double[,] adjMat;
    int di, den;
    int nVerts; int nTree;
    public Graph(int n)
    {
        NUM_VERTICES = n;
        vertexList = new Vertex[NUM_VERTICES];
        adjMat = new double[NUM_VERTICES, NUM_VERTICES];
        nVerts = 0; nTree = 0;
        for (int j = 0; j < NUM_VERTICES; j++)
            for (int k = 0; k < NUM_VERTICES; k++)
                adjMat[j, k] = 0;
    }
    public void AddVertex(string lab)
    {
        vertexList[nVerts] = new Vertex(lab); nVerts++;
    }
    public void AddEdge(int start, int theEnd, double weight)
    {
        adjMat[start, theEnd] = weight;
    }
    public void ShowAdjMatrix()
    {
        for (int i = 0; i < NUM_VERTICES; i++)
        {
            for (int j = 0; j < NUM_VERTICES; j++)
                Console.Write("{0, 3}", adjMat[i, j]);
            Console.WriteLine();
        }
    }

    int src; int des;
    public string Dijkstra(string k, string d)
    {

        const int MAXINT = 1000000;
        int[] DanhDau = new int[NUM_VERTICES + 1];
        double[] Nhan = new double[NUM_VERTICES + 1];
        int[] Truoc = new int[NUM_VERTICES + 1];
        int XP, i;
        double min;

        for (i = 0; i < NUM_VERTICES; i++)
        {
            if (k == vertexList[i].label)
                di = i;
        }

        for (i = 0; i < NUM_VERTICES; i++)
        {
            if (d == vertexList[i].label)
                den = i;
        }
        src = di;
        des = den;
        for (i = 0; i < NUM_VERTICES; i++)
        {
            Nhan[i] = MAXINT;
            DanhDau[i] = 0;
            Truoc[i] = src;
        }
        Nhan[src] = 0;
        DanhDau[src] = 1;
        XP = src;
        while (XP != des)
        {
            for (int j = 0; j < NUM_VERTICES; j++)
                if (adjMat[XP, j] > 0 && Nhan[j] > adjMat[XP, j] + Nhan[XP] && DanhDau[j] == 0)
                {
                    Nhan[j] = adjMat[XP, j] + Nhan[XP];
                    Truoc[j] = XP;
                }
            min = MAXINT;
            for (int j = 0; j < NUM_VERTICES; j++)
                if (min > Nhan[j] && DanhDau[j] == 0)
                {
                    min = Nhan[j];
                    XP = j;
                }
            DanhDau[XP] = 1;
        }
        // Truy vết đường đi và in kết quả
        List<string> al = new List<string>();
        int[] temp = new int[NUM_VERTICES + 1];
        temp[0] = des;
        temp[1] = Truoc[des];
        i = Truoc[des];
        int count = 2;
        while (i != src)
        {
            i = Truoc[i];
            temp[count] = i;
            count++;
        }
        string res = "";
        for (i = count - 1; i >= 1; i--)
        {
            al.Add(vertexList[temp[i]].label);
        }
        al.Add(vertexList[temp[0]].label);
        for (i = 0; i < al.Count - 1; i++)
            res += al[i] + " --> ";
        res += al[al.Count - 1];
        res += ".   Khoảng cách: " + Math.Round(Nhan[des], 3) + " (đơn vị)";
        return res;
    }
}
