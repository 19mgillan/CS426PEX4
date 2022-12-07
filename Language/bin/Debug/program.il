.assembly extern mscorlib {}
.assembly pex4cg
{
	.ver 1:0:1:0
}

.method static void main() cil managed
{
	.maxstack 128
	.entrypoint

	LABEL_IN_WHILE1:
	ldc.i4 1
	brzero LABEL_OUT_WHILE1
	// Declaring Variable y 
	.locals init(int32 y)

	br LABEL_IN_WHILE1
	LABEL_OUT_WHILE1:

	ret
}
