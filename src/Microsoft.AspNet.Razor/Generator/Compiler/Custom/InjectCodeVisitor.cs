using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.Generator.Compiler.Custom;

namespace Microsoft.AspNet.Razor.Generator.Compiler.CSharp
{
    public class InjectCodeVisitor : CodeVisitor<CSharpCodeWriter>
    {
        public InjectCodeVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
            : base(writer, context)
        {
            Injections = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Injections { get; private set; }

        protected override void Visit(InjectChunk chunk)
        {
            Injections.Add(chunk.InterfaceName, chunk.ValueName);

            Writer.WriteLine(String.Format("public {0} {1} {{ get; private set; }}", chunk.InterfaceName, chunk.ValueName));
        }
    }
}
