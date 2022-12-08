.assembly extern mscorlib {}
.assembly pex4cg
{
	.ver 1:0:1:0
}

.method static void test6 () cil managed
{
	.maxstack 128
	ldstr "IfStatementTest\n"
	call void [mscorlib]System.Console::Write(string)
	// Declaring Variable pass 
	.locals init(string pass)

	ldstr "pass\n"
	stloc pass

	// Declaring Variable fail 
	.locals init(string fail)

	ldstr "fail\n"
	stloc fail

	ldc.r4 1.0
	ldc.r4 1.0
	add
	ldc.r4 3.0
	blt LABEL_EQUIVALENTBLT0
		ldc.i4 0
		br LABEL_CONTINUEBLT0
	LABEL_EQUIVALENTBLT0:
		ldc.i4 1
	LABEL_CONTINUEBLT0:
	brtrue LABEL_IN1_IF1
	LABEL_IN1_IF1:
	ldloc pass
	call void [mscorlib]System.Console::Write(string)
		br LABEL_OUT1_IF1
	LABEL_OUT1_IF1:
	ldc.r4 5.0
	ldc.r4 3.0
	mul
	ldc.i4 1
	bgt LABEL_EQUIVALENTBGT1
		ldc.i4 0
		br LABEL_CONTINUEBGT1
	LABEL_EQUIVALENTBGT1:
		ldc.i4 1
	LABEL_CONTINUEBGT1:
	brtrue LABEL_IN1_IF2
	LABEL_IN1_IF2:
	ldloc pass
	call void [mscorlib]System.Console::Write(string)
		br LABEL_OUT1_IF2
	LABEL_OUT1_IF2:
	 call void test7()
	ret
}
.method static void test7 () cil managed
{
	.maxstack 128
	ldstr "NestedIfStatementTest\n"
	call void [mscorlib]System.Console::Write(string)
	ldc.i4 3
	ldc.i4 2
	bgt LABEL_EQUIVALENTBGT2
		ldc.i4 0
		br LABEL_CONTINUEBGT2
	LABEL_EQUIVALENTBGT2:
		ldc.i4 1
	LABEL_CONTINUEBGT2:
	brtrue LABEL_IN1_IF3
	LABEL_IN1_IF3:
	ldc.i4 5
	ldc.i4 4
	bgt LABEL_EQUIVALENTBGT3
		ldc.i4 0
		br LABEL_CONTINUEBGT3
	LABEL_EQUIVALENTBGT3:
		ldc.i4 1
	LABEL_CONTINUEBGT3:
	brtrue LABEL_IN2_IF3
	LABEL_IN2_IF3:
	ldstr "NestedIfStatementPass\n"
	call void [mscorlib]System.Console::Write(string)
		br LABEL_OUT2_IF3
	LABEL_OUT2_IF3:
		br LABEL_OUT1_IF3
	LABEL_OUT1_IF3:
	ret
}
.method static void test8 () cil managed
{
	.maxstack 128
	ldstr "WhileLoopTest"
	call void [mscorlib]System.Console::Write(string)
	// Declaring Variable i 
	.locals init(int32 i)

	ldc.i4 0
	stloc i

	LABEL_IN_WHILE11:
	ldc.i4 10
	ldloc i
	bgt LABEL_EQUIVALENTBGT4
		ldc.i4 0
		br LABEL_CONTINUEBGT4
	LABEL_EQUIVALENTBGT4:
		ldc.i4 1
	LABEL_CONTINUEBGT4:
	brzero LABEL_OUT_WHILE11
	ldloc i
	call void [mscorlib]System.Console::Write(int32)
	ldloc i
	ldc.i4 1
	add
	stloc i

	br LABEL_IN_WHILE11
	LABEL_OUT_WHILE11:
	ldstr "LoopComplete"
	call void [mscorlib]System.Console::Write(string)
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)
	 call void test9()
	ret
}
.method static void test9 () cil managed
{
	.maxstack 128
	ldstr "NestedWhileLoopTest"
	call void [mscorlib]System.Console::Write(string)
	// Declaring Variable x 
	.locals init(int32 x)

	ldc.i4 0
	stloc x

	// Declaring Variable y 
	.locals init(int32 y)

	ldc.i4 0
	stloc y

	LABEL_IN_WHILE02:
	ldc.i4 3
	ldloc y
	bgt LABEL_EQUIVALENTBGT5
		ldc.i4 0
		br LABEL_CONTINUEBGT5
	LABEL_EQUIVALENTBGT5:
		ldc.i4 1
	LABEL_CONTINUEBGT5:
	brzero LABEL_OUT_WHILE02
	LABEL_IN_WHILE03:
	ldc.i4 3
	ldloc x
	bgt LABEL_EQUIVALENTBGT6
		ldc.i4 0
		br LABEL_CONTINUEBGT6
	LABEL_EQUIVALENTBGT6:
		ldc.i4 1
	LABEL_CONTINUEBGT6:
	brzero LABEL_OUT_WHILE03
	ldstr "x:"
	call void [mscorlib]System.Console::Write(string)
	ldloc x
	call void [mscorlib]System.Console::Write(int32)
	ldstr "y:"
	call void [mscorlib]System.Console::Write(string)
	ldloc y
	call void [mscorlib]System.Console::Write(int32)
	ldloc x
	ldc.i4 1
	add
	stloc x

	br LABEL_IN_WHILE03
	LABEL_OUT_WHILE03:
	ldc.i4 0
	stloc x

	ldloc y
	ldc.i4 1
	add
	stloc y

	br LABEL_IN_WHILE02
	LABEL_OUT_WHILE02:
	ldstr "LoopComplete"
	call void [mscorlib]System.Console::Write(string)
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)
	ret
}
.method static void main() cil managed
{
	.maxstack 128
	.entrypoint

	 call void test6()
	 call void test8()

	ret
}
