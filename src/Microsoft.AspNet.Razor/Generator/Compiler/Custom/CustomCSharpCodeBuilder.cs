using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Razor.Generator.Compiler.CSharp
{
    public class CustomCSharpCodeBuilder : CSharpCodeBuilder
    {
        public CustomCSharpCodeBuilder(CodeGeneratorContext context)
            : base(context)
        {
        }

        protected override void BuildConstructor(CSharpCodeWriter writer)
        {
            var injectionVisitor = new InjectCodeVisitor(writer, Context);

            writer.WriteLine();
            injectionVisitor.Accept(Context.CodeTreeBuilder.CodeTree.Chunks);
            writer.WriteLine();

            writer.WriteLineHiddenDirective();
            using(writer.BuildConstructor("public", Context.ClassName, injectionVisitor.Injections))
            {
                foreach(var injection in injectionVisitor.Injections)
                {
                    writer.WriteLine(String.Format("this.{0} = {0};", injection.Value));
                }
            }
        }
    }
}
