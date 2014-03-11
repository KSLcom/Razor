using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.Parser.SyntaxTree;

namespace Microsoft.AspNet.Razor.Generator.Compiler.Custom
{
    public class InjectCodeGenerator : SpanCodeGenerator
    {
        public override void GenerateCode(Span target, CodeGeneratorContext context)
        {
            var items = target.Content.Trim().Split(' ');

            if (items.Length == 2)
            {
                context.CodeTreeBuilder.AddChunk(new InjectChunk
                {
                    ValueName = items[1],
                    InterfaceName = items[0]
                }, target);
            }
        }
    }
}
