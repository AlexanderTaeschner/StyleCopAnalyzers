// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Lightup
{
    using System;
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal readonly partial struct RelationalPatternSyntaxWrapper : ISyntaxWrapper<PatternSyntax>
    {
        internal const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.RelationalPatternSyntax";
        private static readonly Type WrappedType;

        private static readonly Func<PatternSyntax, SyntaxToken> OperatorTokenAccessor;
        private static readonly Func<PatternSyntax, ExpressionSyntax> ExpressionAccessor;
        private static readonly Func<PatternSyntax, SyntaxToken, PatternSyntax> WithOperatorTokenAccessor;
        private static readonly Func<PatternSyntax, ExpressionSyntax, PatternSyntax> WithExpressionAccessor;

        private readonly PatternSyntax node;

        static RelationalPatternSyntaxWrapper()
        {
            WrappedType = SyntaxWrapperHelper.GetWrappedType(typeof(RelationalPatternSyntaxWrapper));
            OperatorTokenAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, SyntaxToken>(WrappedType, nameof(OperatorToken));
            ExpressionAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, ExpressionSyntax>(WrappedType, nameof(Expression));
            WithOperatorTokenAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, SyntaxToken>(WrappedType, nameof(OperatorToken));
            WithExpressionAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, ExpressionSyntax>(WrappedType, nameof(Expression));
        }

        private RelationalPatternSyntaxWrapper(PatternSyntax node)
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

        public ExpressionSyntax Expression
        {
            get
            {
                return ExpressionAccessor(this.SyntaxNode);
            }
        }

        public static explicit operator RelationalPatternSyntaxWrapper(SyntaxNode node)
        {
            if (node == null)
            {
                return default;
            }

            if (!IsInstance(node))
            {
                throw new InvalidCastException($"Cannot cast '{node.GetType().FullName}' to '{WrappedTypeName}'");
            }

            return new RelationalPatternSyntaxWrapper((PatternSyntax)node);
        }

        public static implicit operator PatternSyntax(RelationalPatternSyntaxWrapper wrapper)
        {
            return wrapper.node;
        }

        public static bool IsInstance(SyntaxNode node)
        {
            return node != null && LightupHelpers.CanWrapNode(node, WrappedType);
        }

        public RelationalPatternSyntaxWrapper WithOperatorToken(SyntaxToken operatorToken)
        {
            return new RelationalPatternSyntaxWrapper(WithOperatorTokenAccessor(this.SyntaxNode, operatorToken));
        }

        public RelationalPatternSyntaxWrapper WithExpression(ExpressionSyntax expression)
        {
            return new RelationalPatternSyntaxWrapper(WithExpressionAccessor(this.SyntaxNode, expression));
        }
    }
}
