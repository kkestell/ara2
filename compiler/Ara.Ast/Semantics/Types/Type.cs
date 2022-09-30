using Ara.Ast.Nodes;

namespace Ara.Ast.Semantics.Types;

public abstract record Type
{
    public static Type Parse(TypeRef typeRef)
    {
        return typeRef switch
        {
            ArrayTypeRef       a => ParseArrayTypeRef(a),
            SingleValueTypeRef s => ParseSingleValueTypeRef(s),
            
            _ => throw new Exception()
        };
    }

    static Type ParseArrayTypeRef(ArrayTypeRef typeRef)
    {
        return new ArrayType(Parse(typeRef.Type), typeRef.Size.Value);
    }
    
    static Type ParseSingleValueTypeRef(SingleValueTypeRef typeRef)
    {
        return typeRef.Name switch
        {
            "bool"  => new BooleanType(),
            "float" => new FloatType(),
            "int"   => new IntegerType(),
            "void"  => new VoidType(),
            
            _ => throw new Exception()
        };
    }
}