namespace Ara.Tests.Instructions;

public class FSubTests : TestBase
{
    [Test]
    public void SubtractTwoFloats()
    {
        builder.FSub(new FloatValue(3.14f), new FloatValue(2.71f));

        var ir = module.Emit();
        Assert.That(ir, Is.EqualTo(@"define void @test () {
entry:
%""0"" = fsub float 0x40091EB860000000, 0x4005AE1480000000
}"));
    }

    [Test]
    public void ThrowWhenArgumentsHaveDifferentTypes()
    {
        Assert.Throws<ArgumentException>(delegate
        {
            builder.FSub(new IntValue(1), new FloatValue(3.14f));
        });
    }

    [Test]
    public void ThrowWhenArgumentsAreNotFloats()
    {
        Assert.Throws<ArgumentException>(delegate
        {
            builder.FSub(new IntValue(1), new IntValue(1));
        });
    }
}