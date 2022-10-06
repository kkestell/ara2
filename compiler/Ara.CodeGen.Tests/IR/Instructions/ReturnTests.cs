using Ara.CodeGen.IR.Values;

namespace Ara.CodeGen.Tests.IR.Instructions;

public class ReturnTests : TestBase
{
    [Test]
    public void ReturnVoid()
    {
        builder.Return();
        
        AssertIr(module.Emit(), @"
            define void @test () {
            entry:
              ret void
            }
        ");
    }
    
    [Test]
    public void ReturnAnInteger()
    {
        builder.Return(new IntegerValue(1));
        
        AssertIr(module.Emit(), @"
            define void @test () {
            entry:
              ret i32 1
            }
        ");
    }
}