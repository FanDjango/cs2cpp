﻿namespace Il2Native.Logic.DOM.Synthesized
{
    using System.Collections.Immutable;
    using DOM2;
    using Implementations;
    using Microsoft.CodeAnalysis;

    public class CCodeCastOperatorDeclaration : CCodeMethodDeclaration
    {
        public CCodeCastOperatorDeclaration(INamedTypeSymbol type)
            : base(new CastOperatorMethod(type))
        {
            MethodBodyOpt = new MethodBody
            {
                Statements =
                {
                    new ReturnStatement
                    {
                        ExpressionOpt = new Cast
                        {
                            Type = type,
                            Operand = new FieldAccess
                            {
                                ReceiverOpt = new ThisReference { Type = type },
                                Field = new FieldImpl { Name = "m_value" }
                            }
                        }       
                    }
                }
            };
        }

        public override void WriteTo(CCodeWriterBase c)
        {
            c.TextSpan("operator");
            c.WhiteSpace();
            c.WriteType(Method.ContainingType);
            c.TextSpan("()");
            MethodBodyOpt.WriteTo(c);
        }

        public class CastOperatorMethod : MethodImpl
        {
            public CastOperatorMethod(INamedTypeSymbol type)
            {
                MethodKind = MethodKind.BuiltinOperator;
                ReceiverType = type;
                ContainingType = type;
                Parameters = ImmutableArray<IParameterSymbol>.Empty;
            }
        }
    }
}
