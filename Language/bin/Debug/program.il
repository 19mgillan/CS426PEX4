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
	.locals init(int32 x)

	ldc.i4 5
	stloc x

	ldloc x
	ldc.i4 1
	add
	stloc x

	ldloc x
	call void [mscorlib]System.Console::Write(int32)

	ret
}
