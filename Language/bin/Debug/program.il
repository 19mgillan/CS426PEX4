.assembly extern mscorlib {}
.assembly pex4cg
{
	.ver 1:0:1:0
}

.method static void main() cil managed
{
	.maxstack 128
	.entrypoint

	ldc.i4 1
	ldc.i4 1
	bge LABEL_EQUIVALENT
		ldc.i4 0
		br LABEL_CONTINUE
	LABEL_EQUIVALENT:
		ldc.i4 1
	LABEL_CONTINUE:
	brtrue LABEL_IN_IF1
	LABEL_IN_IF1:
	// Declaring Variable x 
	.locals init(int32 x)

	ldc.i4 1
	stloc x

	ldc.i4 2
	ldc.i4 2
	add
	brtrue LABEL_IN_IF2
	LABEL_IN_IF2:
	// Declaring Variable y 
	.locals init(int32 y)

		br LABEL_OUT_IF2
	LABEL_OUT_IF2:
		br LABEL_OUT_IF1
	LABEL_OUT_IF1:

	ret
}
