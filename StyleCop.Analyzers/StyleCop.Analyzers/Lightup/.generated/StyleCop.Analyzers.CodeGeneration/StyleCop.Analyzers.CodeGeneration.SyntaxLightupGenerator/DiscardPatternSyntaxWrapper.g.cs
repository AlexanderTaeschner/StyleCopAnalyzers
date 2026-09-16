// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Lightup
{
    using System;
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal readonly partial struct DiscardPatternSyntaxWrapper : ISyntaxWrapper<PatternSyntax>
    {
        internal const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.DiscardPatternSyntax";
        private static readonly Type WrappedType;

        private static readonly Func<PatternSyntax, SyntaxToken> UnderscoreTokenAccessor;
        private static readonly Func<PatternSyntax, SyntaxToken, PatternSyntax> WithUnderscoreTokenAccessor;

        private readonly PatternSyntax node;

        static DiscardPatternSyntaxWrapper()
        {
            WrappedType = SyntaxWrapperHelper.GetWrappedType(typeof(DiscardPatternSyntaxWrapper));
            UnderscoreTokenAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, SyntaxToken>(WrappedType, nameof(UnderscoreToken));
            WithUnderscoreTokenAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, SyntaxToken>(WrappedType, nameof(UnderscoreToken));
        }

        private DiscardPatternSyntaxWrapper(PatternSyntax node)
        {
            this.node = node;
        }

        public PatternSyntax SyntaxNode => this.node;


        public SyntaxToken UnderscoreToken
        {
            get
            {
                return UnderscoreTokenAccessor(this.SyntaxNode);
            }
        }

        public static explicit operator DiscardPatternSyntaxWrapper(SyntaxNode node)
        {
            if (node == null)
            {
                return default;
            }

            if (!IsInstance(node))
            {
                throw new InvalidCastException($"Cannot cast '{node.GetType().FullName}' to '{WrappedTypeName}'");
            }

            return new DiscardPatternSyntaxWrapper((PatternSyntax)node);
        }

        public static implicit operator PatternSyntax(DiscardPatternSyntaxWrapper wrapper)
        {
            return wrapper.node;
        }

        public static bool IsInstance(SyntaxNode node)
        {
            return node != null && LightupHelpers.CanWrapNode(node, WrappedType);
        }

        public DiscardPatternSyntaxWrapper WithUnderscoreToken(SyntaxToken underscoreToken)
        {
            return new DiscardPatternSyntaxWrapper(WithUnderscoreTokenAccessor(this.SyntaxNode, underscoreToken));
        }
    }
}
