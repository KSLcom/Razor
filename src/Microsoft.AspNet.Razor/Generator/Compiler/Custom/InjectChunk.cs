using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Razor.Generator.Compiler.Custom
{
    public class InjectChunk : Chunk
    {
        public string ValueName { get; set; }
        public string InterfaceName { get; set; }
    }
}
