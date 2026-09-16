// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Lightup
{
    using System;
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal readonly partial struct BinaryPatternSyntaxWrapper : ISyntaxWrapper<PatternSyntax>
    {
        internal const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.BinaryPatternSyntax";
        private static readonly Type WrappedType;

        private static readonly Func<PatternSyntax, PatternSyntax> LeftAccessor;
        private static readonly Func<PatternSyntax, SyntaxToken> OperatorTokenAccessor;
        private static readonly Func<PatternSyntax, PatternSyntax> RightAccessor;
        private static readonly Func<PatternSyntax, PatternSyntax, PatternSyntax> WithLeftAccessor;
        private static readonly Func<PatternSyntax, SyntaxToken, PatternSyntax> WithOperatorTokenAccessor;
        private static readonly Func<PatternSyntax, PatternSyntax, PatternSyntax> WithRightAccessor;

        private readonly PatternSyntax node;

        static BinaryPatternSyntaxWrapper()
        {
            WrappedType = SyntaxWrapperHelper.GetWrappedType(typeof(BinaryPatternSyntaxWrapper));
            LeftAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, PatternSyntax>(WrappedType, nameof(Left));
            OperatorTokenAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, SyntaxToken>(WrappedType, nameof(OperatorToken));
            RightAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, PatternSyntax>(WrappedType, nameof(Right));
            WithLeftAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, PatternSyntax>(WrappedType, nameof(Left));
            WithOperatorTokenAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, SyntaxToken>(WrappedType, nameof(OperatorToken));
            WithRightAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, PatternSyntax>(WrappedType, nameof(Right));
        }

        private BinaryPatternSyntaxWrapper(PatternSyntax node)
        {
            this.node = node;
        }

        public PatternSyntax SyntaxNode => this.node;


        public PatternSyntax Left
        {
            get
            {
                return LeftAccessor(this.SyntaxNode);
            }
        }

        public SyntaxToken OperatorToken
        {
            get
            {
                return OperatorTokenAccessor(this.SyntaxNode);
            }
        }

        public PatternSyntax Right
        {
            get
            {
                return RightAccessor(this.SyntaxNode);
            }
        }

        public static explicit operator BinaryPatternSyntaxWrapper(SyntaxNode node)
        {
            if (node == null)
            {
                return default;
            }

            if (!IsInstance(node))
            {
                throw new InvalidCastException($"Cannot cast '{node.GetType().FullName}' to '{WrappedTypeName}'");
            }

            return new BinaryPatternSyntaxWrapper((PatternSyntax)node);
        }

        public static implicit operator PatternSyntax(BinaryPatternSyntaxWrapper wrapper)
        {
            return wrapper.node;
        }

        public static bool IsInstance(SyntaxNode node)
        {
            return node != null && LightupHelpers.CanWrapNode(node, WrappedType);
        }

        public BinaryPatternSyntaxWrapper WithLeft(PatternSyntax left)
        {
            return new BinaryPatternSyntaxWrapper(WithLeftAccessor(this.SyntaxNode, left));
        }

        public BinaryPatternSyntaxWrapper WithOperatorToken(SyntaxToken operatorToken)
        {
            return new BinaryPatternSyntaxWrapper(WithOperatorTokenAccessor(this.SyntaxNode, operatorToken));
        }

        public BinaryPatternSyntaxWrapper WithRight(PatternSyntax right)
        {
            return new BinaryPatternSyntaxWrapper(WithRightAccessor(this.SyntaxNode, right));
        }
    }
}
