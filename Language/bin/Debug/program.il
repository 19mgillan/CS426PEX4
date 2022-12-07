.assembly extern mscorlib {}
.assembly pex4cg
{
	.ver 1:0:1:0
}

.method static void main() cil managed
{
	.maxstack 128
	.entrypoint

	// Declaring Variable x 
	.locals init(float32 x)

	ldc.r4 5.1
	stloc x

	ldloc x
	ldc.r4 1.0
	add
	stloc x

	ldloc x
	call void [mscorlib]System.Console::Write(float32)

	ret
}
