using Harmony;
using System;
using UnityEngine;

namespace CellToSingularityHack
{
    internal class Manager : MonoBehaviour
    {
        private int menuX = 10;
        private int menuY = 100;
        private int toolbar = 0;
        private string[] toolbarLabels = { "Currency", "OTHER" };

        private bool enabled_Menu = false;

        private string entropyAmount = "0";
        private string ideaAmount = "0";
        private string darwiniumAmount = "0";
        private string dAmount = "0";

        private void Start()
        {
        }

        private void OnGUI()
        {
            GUI.Box(new Rect(menuX, 70, 300, 30), "");
            toolbar = GUI.Toolbar(new Rect(menuX, 70, 300, 30), toolbar, toolbarLabels);

            if (toolbar == 0)// CURRENCY
            {
                GUI.Box(new Rect(menuX, menuY, 300, 300), "Currency", GUI.skin.window);

                GUI.Label(new Rect(menuX + 25, menuY + 20, 150, 20), "Entropy:");
                entropyAmount = GUI.TextField(new Rect(menuX + 112.5f, menuY + 20, 75, 25), entropyAmount); // User specified entropy

                GUI.Label(new Rect(menuX + 25, menuY + 45, 150, 20), "B:");
                ideaAmount = GUI.TextField(new Rect(menuX + 112.5f, menuY + 45, 75, 25), ideaAmount); // User specified idea

                GUI.Label(new Rect(menuX + 25, menuY + 70, 150, 20), "Darwinium:");
                darwiniumAmount = GUI.TextField(new Rect(menuX + 112.5f, menuY + 70, 75, 25), darwiniumAmount); // User specified darwinium

                GUI.Label(new Rect(menuX + 25, menuY + 95, 150, 20), "D:");
                dAmount = GUI.TextField(new Rect(menuX + 112.5f, menuY + 95, 75, 25), dAmount); // User specified d

                if (GUI.Button(new Rect(menuX = 25, menuY + 125, 250, 30), new GUIContent("Add/Sub Amount", "Add or subtract specified amount to/from respective currency.")))
                {
                    try
                    {
                        if (((Double)PerfectSingleton<Calculator>.instance.bank.a) + (Double.Parse(entropyAmount)) > 0 &&
                            ((Double)PerfectSingleton<Calculator>.instance.bank.b) + (Double.Parse(ideaAmount)) > 0 &&
                            ((Double)PerfectSingleton<Calculator>.instance.bank.c) + (Double.Parse(darwiniumAmount)) > 0 &&
                            ((Double)PerfectSingleton<Calculator>.instance.bank.d) + (Double.Parse(dAmount)) > 0)
                        {
                            PerfectSingleton<Calculator>.instance.bank += new Cry(Double.Parse(entropyAmount), Double.Parse(ideaAmount), Double.Parse(darwiniumAmount), Double.Parse(dAmount));
                        }
                    }
                    catch { }
                }
                else if (GUI.Button(new Rect(menuX = 25, menuY + 160, 250, 30), new GUIContent("Set Amount", "Set respective currency to specified amount.")))
                {
                    try
                    {
                        Cry setTo = new Cry(
                            Double.Parse(entropyAmount) > 0 ? Double.Parse(entropyAmount) : ((Double)PerfectSingleton<Calculator>.instance.bank.a),
                            Double.Parse(ideaAmount) > 0 ? Double.Parse(ideaAmount) : ((Double)PerfectSingleton<Calculator>.instance.bank.b),
                            Double.Parse(darwiniumAmount) > 0 ? Double.Parse(darwiniumAmount) : ((Double)PerfectSingleton<Calculator>.instance.bank.c),
                            Double.Parse(dAmount) > 0 ? Double.Parse(dAmount) : ((Double)PerfectSingleton<Calculator>.instance.bank.d));
                        PerfectSingleton<Calculator>.instance.bank = setTo;
                    }
                    catch { }
                }
            }

            // Tooltip:
            GUI.Label(new Rect(10, 400, 300, 100), GUI.tooltip);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F5)) { enabled_Menu = !enabled_Menu; }
            if (Input.GetKeyDown(KeyCode.F7))
            {
                PerfectSingleton<Calculator>.instance.bank += new Cry(111111, 222222, 333333, 444444);
                FileLog.Log("A: " + (PerfectSingleton<Calculator>.instance.bank.a).ToString());
                FileLog.Log("B: " + (PerfectSingleton<Calculator>.instance.bank.b).ToString());
                FileLog.Log("C: " + (PerfectSingleton<Calculator>.instance.bank.c).ToString());
                FileLog.Log("D: " + (PerfectSingleton<Calculator>.instance.bank.d).ToString());
            }
        }
    }
}

/*
Don't add more than 1E+33
a = entropy
b =
c = premium
d =
 */