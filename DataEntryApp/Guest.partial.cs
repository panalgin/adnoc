using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntryApp
{
    public partial class Guest
    {
        public string FullName { get { return string.Format("{0} {1}", this.Name, this.Surname); } }
    }
}
