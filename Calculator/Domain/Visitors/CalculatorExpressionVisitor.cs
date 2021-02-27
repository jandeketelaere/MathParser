﻿using Domain.Expressions;
using System;

namespace Domain.Visitors
{
    public class CalculatorExpressionVisitor : ExpressionVisitor<int>
    {
        public override int Visit(ConstantExpression expression)
        {
            return expression.Value;
        }

        public override int Visit(BinaryExpression expression)
        {
            var left = Visit(expression.Left);
            var right = Visit(expression.Right);

            var result = expression.Type switch
            {
                BinaryExpressionType.Add => left + right,
                BinaryExpressionType.Subtract => left - right,
                _ => throw new NotImplementedException($"No implementation found for type {expression.Type}"),
            };

            return result;
        }
    }
}