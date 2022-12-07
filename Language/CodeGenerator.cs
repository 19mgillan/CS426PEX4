using CS426.node;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS426.analysis
{
    internal class CodeGenerator : DepthFirstAdapter
    {
        StreamWriter _output;
        public CodeGenerator(String outputFilename)
        {
            _output = new StreamWriter(outputFilename);

        }

        private void Write(String textToWrite)
        {
            Console.Write(textToWrite);
            _output.Write(textToWrite);


        }

        private void WriteLine(String textToWrite)
        {
            Console.WriteLine(textToWrite);
            _output.WriteLine(textToWrite);


        }

        public override void InAProgram(AProgram node)
        {
            WriteLine(".assembly extern mscorlib {}");
            WriteLine(".assembly pex4cg");
            WriteLine("{\n\t.ver 1:0:1:0\n}\n");

        }

        public override void OutAProgram(AProgram node)
        {
            _output.Close();
            Console.WriteLine("\n\n");
        }

        public override void InAMainBlock(AMainBlock node)
        {
            WriteLine(".method static void main() cil managed");
            WriteLine("{");
            WriteLine("\t.maxstack 128");
            WriteLine("\t.entrypoint\n");

        }

        public override void OutAMainBlock(AMainBlock node)
        {
            WriteLine("\n\tret");
            WriteLine("}");

        }

        public override void OutADeclareStatement(ADeclareStatement node)
        {
            WriteLine("\t// Declaring Variable " + node.GetVarname().ToString());
            Write("\t.locals init(");

            if (node.GetType().Text == "int")
            {
                Write("int32 ");
            }
            else if (node.GetType().Text == "float")
            {
                Write("float32 ");
            }
            else
            {
                Write(node.GetType().Text + " ");
            }

            WriteLine(node.GetVarname().Text + ")\n");
        }

        public override void OutAIntOperand(AIntOperand node)
        {
            WriteLine("\tldc.i4 " + node.GetInteger().Text);
        }

        public override void OutAStrOperand(AStrOperand node)
        {
            WriteLine("\tldstr " + node.GetString().Text);
        }

        public override void OutAFltOperand(AFltOperand node)
        {
            WriteLine("\tldc.r4 " + node.GetFloat().Text);
        }

        public override void OutAVariableOperand(AVariableOperand node)
        {
            WriteLine("\tldloc " + node.GetId().Text);

        }

        public override void OutAAssignStatement(AAssignStatement node)
        {
            WriteLine("\tstloc " + node.GetId().Text + "\n");
        }

        public override void OutAAddExpression(AAddExpression node)
        {
            WriteLine("\tadd");
        }

        public override void OutAMultiplyExpression3(AMultiplyExpression3 node)
        {
            WriteLine("\tmul");
        }

        public override void OutASubtractExpression2(ASubtractExpression2 node)
        {
            WriteLine("\tsub");
        }

        public override void OutADivideExpression4(ADivideExpression4 node)
        {
            WriteLine("\tdiv");
        }

        public override void OutANegativeExpression6(ANegativeExpression6 node)
        {
            WriteLine("\tneg");
        }

        public override void OutAFunctionStatement(AFunctionStatement node)
        {
            if (node.GetId().Text == "printInt")
            {
                WriteLine("\tcall void [mscorlib]System.Console::Write(int32)");
            }
            else if (node.GetId().Text == "printString")
            {
                WriteLine("\tcall void [mscorlib]System.Console::Write(string)");
            }
            else if (node.GetId().Text == "printLine")
            {
                WriteLine("\tldstr \"\\n\"");
                WriteLine("\tcall void [mscorlib]System.Console::Write(string)");
            }
            else if (node.GetId().Text == "printFloat")
            {
                WriteLine("\tcall void [mscorlib]System.Console::Write(float32)");
            }
            else
            {
                WriteLine("\t call void " + node.GetId().Text + "()");
            }
        }

        public override void OutANotLogical3(ANotLogical3 node)
        {
            WriteLine("\tldc.i4 0\nceq");
        }

        public override void OutAAndLogical(AAndLogical node)
        {
            WriteLine("\tand");
        }

        public override void OutAOrLogical2(AOrLogical2 node)
        {
            WriteLine("\tor");
        }

    }
}
