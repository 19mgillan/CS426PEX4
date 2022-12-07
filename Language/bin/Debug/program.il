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
	pop

	ret
}
