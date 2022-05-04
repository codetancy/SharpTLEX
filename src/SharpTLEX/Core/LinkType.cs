using OneOf;

namespace SharpTLEX.Core;

public class LinkType : OneOfBase<TLinkType, SLinkType, ALinkType>
{
    protected LinkType(OneOf<TLinkType, SLinkType, ALinkType> input) : base(input)
    {
    }

    public static implicit operator LinkType(TLinkType tLinkType) => new LinkType(tLinkType);
    public static explicit operator TLinkType(LinkType linkType) => linkType.AsT0;

    public static implicit operator LinkType(SLinkType sLinkType) => new LinkType(sLinkType);
    public static explicit operator SLinkType(LinkType linkType) => linkType.AsT1;

    public static implicit operator LinkType(ALinkType aLinkType) => new LinkType(aLinkType);
    public static explicit operator ALinkType(LinkType linkType) => linkType.AsT2;
}
