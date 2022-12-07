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
        int if_statements = 0;
        int while_statements = 0;
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

        public override void OutACompareComparison(ACompareComparison node)
        {
            String type = node.GetEquality().ToString();
            String operation = "";

            if (type.Contains("==")){
                operation = "beq";
            }
            else if (type.Contains("<="))
            {
                operation = "ble";
            }
            else if (type.Contains("<"))
            {
                operation = "blt";
            }
            else if (type.Contains(">="))
            {
                operation = "bge";
            }
            else if (type.Contains(">"))
            {
                operation = "bgt";
            }
            
            WriteLine("\t" + operation + " LABEL_EQUIVALENT");
            WriteLine("\t\tldc.i4 0");
            WriteLine("\t\tbr LABEL_CONTINUE");
            WriteLine("\tLABEL_EQUIVALENT:");
            WriteLine("\t\tldc.i4 1");
            WriteLine("\tLABEL_CONTINUE:");
        }
        public override void InAIfStatement(AIfStatement node)
        {
            if_statements += 1;
        }

        public override void OutAIfStatement(AIfStatement node)
        {
            if_statements -= 1;
        }
        public override void CaseAIfStatement(AIfStatement node)
        {
            // Visit if statement and increment number of if statements
            InAIfStatement(node);

            // Evaluate conditional
            node.GetLogical().Apply(this);

            // Generate Unique Labels
            String label1 = "LABEL_IN_IF" + if_statements.ToString();
            String label2 = "LABEL_OUT_IF" + if_statements.ToString();

            //Write IL code
            WriteLine("\tbrtrue " + label1);
            WriteLine("\t" + label1 + ":");

            //Apply code inside if statement
            if(node.GetStatements() != null)
            {
                node.GetStatements().Apply(this);
            }

            // finish up the guy
            WriteLine("\t\tbr " + label2);
            WriteLine("\t" + label2 + ":");


            OutAIfStatement(node);

        }

        public override void InAWhileStatement(AWhileStatement node)
        {
            while_statements += 1;
        }

        public override void OutAWhileStatement(AWhileStatement node)
        {
            while_statements -= 1;
        }

        public override void CaseAWhileStatement(AWhileStatement node)
        {
            InAWhileStatement(node);
            String label1 = "LABEL_IN_WHILE" + while_statements.ToString();
            String label2 = "LABEL_OUT_WHILE" + while_statements.ToString();

            WriteLine("\t" + label1 + ":");
            node.GetLogical().Apply(this);
            WriteLine("\tbrzero " + label2);
            if (node.GetStatements() != null)
            {
                node.GetStatements().Apply(this);
            }
            WriteLine("\tbr " + label1);
            WriteLine("\t" + label2 + ":");

            OutAWhileStatement(node);

        }



    }
}
