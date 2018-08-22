using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI.WebControls;
using System.Data;
using wcfKioskoCli; 


using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;

/// <summary>
/// Descripción breve de Generador
/// </summary>
public class KillProcesos
{
	public KillProcesos()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

      public static List<int> getRunningProcesses()
        {
            List<int> ProcessIDs = new List<int>();
            //here we're going to get a list of all running processes on
            //the computer
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (Process.GetCurrentProcess().Id == clsProcess.Id)
                    continue;
                if (clsProcess.ProcessName.Contains("WINWORD"))
                {
                    ProcessIDs.Add(clsProcess.Id);
                }
            }
            return ProcessIDs;
        }

      public static void killProcesses(List<int> processesbeforegen, List<int> processesaftergen)
      {
          foreach (int pidafter in processesaftergen)
          {
              bool processfound = false;
              foreach (int pidbefore in processesbeforegen)
              {
                  if (pidafter == pidbefore)
                  {
                      processfound = true;
                  }
              }

              if (processfound == false)
              {
                  Process clsProcess = Process.GetProcessById(pidafter);
                  clsProcess.Kill();
              }
          }
      }

}