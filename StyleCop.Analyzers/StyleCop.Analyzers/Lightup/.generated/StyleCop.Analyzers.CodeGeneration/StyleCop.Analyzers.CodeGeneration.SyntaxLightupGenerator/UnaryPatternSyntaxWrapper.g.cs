// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Lightup
{
    using System;
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal readonly partial struct UnaryPatternSyntaxWrapper : ISyntaxWrapper<PatternSyntax>
    {
        internal const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.UnaryPatternSyntax";
        private static readonly Type WrappedType;

        private static readonly Func<PatternSyntax, SyntaxToken> OperatorTokenAccessor;
        private static readonly Func<PatternSyntax, PatternSyntax> PatternAccessor;
        private static readonly Func<PatternSyntax, SyntaxToken, PatternSyntax> WithOperatorTokenAccessor;
        private static readonly Func<PatternSyntax, PatternSyntax, PatternSyntax> WithPatternAccessor;

        private readonly PatternSyntax node;

        static UnaryPatternSyntaxWrapper()
        {
            WrappedType = SyntaxWrapperHelper.GetWrappedType(typeof(UnaryPatternSyntaxWrapper));
            OperatorTokenAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, SyntaxToken>(WrappedType, nameof(OperatorToken));
            PatternAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, PatternSyntax>(WrappedType, nameof(Pattern));
            WithOperatorTokenAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, SyntaxToken>(WrappedType, nameof(OperatorToken));
            WithPatternAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, PatternSyntax>(WrappedType, nameof(Pattern));
        }

        private UnaryPatternSyntaxWrapper(PatternSyntax node)
        {
            this.node = node;
        }

        public PatternSyntax SyntaxNode => this.node;


        public SyntaxToken OperatorToken
        {
            get
            {
                return OperatorTokenAccessor(this.SyntaxNode);
            }
        }

        public PatternSyntax Pattern
        {
            get
            {
                return PatternAccessor(this.SyntaxNode);
            }
        }

        public static explicit operator UnaryPatternSyntaxWrapper(SyntaxNode node)
        {
            if (node == null)
            {
                return default;
            }

            if (!IsInstance(node))
            {
                throw new InvalidCastException($"Cannot cast '{node.GetType().FullName}' to '{WrappedTypeName}'");
            }

            return new UnaryPatternSyntaxWrapper((PatternSyntax)node);
        }

        public static implicit operator PatternSyntax(UnaryPatternSyntaxWrapper wrapper)
        {
            return wrapper.node;
        }

        public static bool IsInstance(SyntaxNode node)
        {
            return node != null && LightupHelpers.CanWrapNode(node, WrappedType);
        }

        public UnaryPatternSyntaxWrapper WithOperatorToken(SyntaxToken operatorToken)
        {
            return new UnaryPatternSyntaxWrapper(WithOperatorTokenAccessor(this.SyntaxNode, operatorToken));
        }

        public UnaryPatternSyntaxWrapper WithPattern(PatternSyntax pattern)
        {
            return new UnaryPatternSyntaxWrapper(WithPatternAccessor(this.SyntaxNode, pattern));
        }
    }
}
