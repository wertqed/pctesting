using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace pctetsting
{
    class ProcessControl
    {
        Process[] proc;

        public void UpdateProcess()
        {
            proc = Process.GetProcesses();
        }
    }
}
