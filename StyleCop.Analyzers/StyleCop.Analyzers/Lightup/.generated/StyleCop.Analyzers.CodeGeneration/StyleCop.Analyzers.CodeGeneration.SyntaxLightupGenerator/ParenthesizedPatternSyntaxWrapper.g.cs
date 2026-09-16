// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Lightup
{
    using System;
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal readonly partial struct ParenthesizedPatternSyntaxWrapper : ISyntaxWrapper<PatternSyntax>
    {
        internal const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedPatternSyntax";
        private static readonly Type WrappedType;

        private static readonly Func<PatternSyntax, SyntaxToken> OpenParenTokenAccessor;
        private static readonly Func<PatternSyntax, PatternSyntax> PatternAccessor;
        private static readonly Func<PatternSyntax, SyntaxToken> CloseParenTokenAccessor;
        private static readonly Func<PatternSyntax, SyntaxToken, PatternSyntax> WithOpenParenTokenAccessor;
        private static readonly Func<PatternSyntax, PatternSyntax, PatternSyntax> WithPatternAccessor;
        private static readonly Func<PatternSyntax, SyntaxToken, PatternSyntax> WithCloseParenTokenAccessor;

        private readonly PatternSyntax node;

        static ParenthesizedPatternSyntaxWrapper()
        {
            WrappedType = SyntaxWrapperHelper.GetWrappedType(typeof(ParenthesizedPatternSyntaxWrapper));
            OpenParenTokenAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, SyntaxToken>(WrappedType, nameof(OpenParenToken));
            PatternAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, PatternSyntax>(WrappedType, nameof(Pattern));
            CloseParenTokenAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, SyntaxToken>(WrappedType, nameof(CloseParenToken));
            WithOpenParenTokenAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, SyntaxToken>(WrappedType, nameof(OpenParenToken));
            WithPatternAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, PatternSyntax>(WrappedType, nameof(Pattern));
            WithCloseParenTokenAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, SyntaxToken>(WrappedType, nameof(CloseParenToken));
        }

        private ParenthesizedPatternSyntaxWrapper(PatternSyntax node)
        {
            this.node = node;
        }

        public PatternSyntax SyntaxNode => this.node;


        public SyntaxToken OpenParenToken
        {
            get
            {
                return OpenParenTokenAccessor(this.SyntaxNode);
            }
        }

        public PatternSyntax Pattern
        {
            get
            {
                return PatternAccessor(this.SyntaxNode);
            }
        }

        public SyntaxToken CloseParenToken
        {
            get
            {
                return CloseParenTokenAccessor(this.SyntaxNode);
            }
        }

        public static explicit operator ParenthesizedPatternSyntaxWrapper(SyntaxNode node)
        {
            if (node == null)
            {
                return default;
            }

            if (!IsInstance(node))
            {
                throw new InvalidCastException($"Cannot cast '{node.GetType().FullName}' to '{WrappedTypeName}'");
            }

            return new ParenthesizedPatternSyntaxWrapper((PatternSyntax)node);
        }

        public static implicit operator PatternSyntax(ParenthesizedPatternSyntaxWrapper wrapper)
        {
            return wrapper.node;
        }

        public static bool IsInstance(SyntaxNode node)
        {
            return node != null && LightupHelpers.CanWrapNode(node, WrappedType);
        }

        public ParenthesizedPatternSyntaxWrapper WithOpenParenToken(SyntaxToken openParenToken)
        {
            return new ParenthesizedPatternSyntaxWrapper(WithOpenParenTokenAccessor(this.SyntaxNode, openParenToken));
        }

        public ParenthesizedPatternSyntaxWrapper WithPattern(PatternSyntax pattern)
        {
            return new ParenthesizedPatternSyntaxWrapper(WithPatternAccessor(this.SyntaxNode, pattern));
        }

        public ParenthesizedPatternSyntaxWrapper WithCloseParenToken(SyntaxToken closeParenToken)
        {
            return new ParenthesizedPatternSyntaxWrapper(WithCloseParenTokenAccessor(this.SyntaxNode, closeParenToken));
        }
    }
}
