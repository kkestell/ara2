namespace Ara.Ast.Semantics.Types;

public record ArrayType(Type Type, int Size) : Type
{
    public override string ToString()
    {
        return $"{Type}[{Size}]";
    }
}