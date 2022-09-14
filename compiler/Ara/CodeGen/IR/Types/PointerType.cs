namespace Ara.CodeGen.IR.Types;

public record PointerType(IrType Type) : IrType
{
    public override string ToIr()
    {
        return "ptr";
    }
}